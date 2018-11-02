using Newtonsoft.Json;
using PureCloudPlatform.Client.V2.Api;
using PureCloudPlatform.Client.V2.Client;
using PureCloudPlatform.Client.V2.Extensions;
using PureCloudPlatform.Client.V2.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace DisconnectCalls
{
	public partial class Form1 : Form
	{
		#region Global Vars

		TelephonyProvidersEdgeApi telephonyProvidersEdgeApi = null;
		RoutingApi routingApi = null;
		EdgeInfo currentEdge = null;
		AnalyticsApi analyticsApi = null;
		ConversationsApi conversationsApi = null;
		TokensApi tokensApi = null;
		UsersApi usersApi = null;

		List<AnalyticsConversation> conversationsToDisconnect = new List<AnalyticsConversation>();

		int _LoggedInAgents = 0;
		int _NotRespondingAgents = 0;

		bool loggedIn = false;
		Timer timer = new Timer();

		#endregion

		#region Init

		public Form1()
		{
			InitializeComponent();

			AddLog("Initializing...");

			cmbEnvironment.SelectedIndex = 0;
			dtAnalyticsStart.Value = DateTime.Now.AddDays(-1);
			dtAnalyticsEnd.Value = DateTime.Now;
			btnConnect.Select();

			Application.ApplicationExit += (sender, e) =>
			{
				Disconnect();
			};

			AddLog("Ready. Please enter your Client Id and Client Secret then click on Login.");
		}

		#endregion

		#region PureCloud Connection

		private void btnConnect_Click(object sender, EventArgs e)
		{
			try
			{
				if (string.IsNullOrEmpty(txtClientId.Text) || string.IsNullOrEmpty(txtClientSecret.Text))
				{
					MessageBox.Show("Enter a client id & secret first.");
					return;
				}

				// Connect to PureCloud
				AddLog("Connecting...");
				Configuration.Default.ApiClient.RestClient.BaseUrl = new Uri($"https://api.{cmbEnvironment.SelectedItem.ToString()}");
				var accessTokenInfo = Configuration.Default.ApiClient.PostToken(txtClientId.Text, txtClientSecret.Text);
				Configuration.Default.AccessToken = accessTokenInfo.AccessToken;
				loggedIn = true;
				AddLog($"Connected.");
				AddLog($"Access Token: {accessTokenInfo.AccessToken}", true);

				// Get APIs
				AddLog("Initializing APIs...", true);
				analyticsApi = new AnalyticsApi();
				routingApi = new RoutingApi();
				conversationsApi = new ConversationsApi();
				tokensApi = new TokensApi();
				telephonyProvidersEdgeApi = new TelephonyProvidersEdgeApi();
				AddLog("Finished initializing APIs...", true);

				// Update Controls
				btnConnect.Enabled = false;
				btnDisconnect.Enabled = true;
				gbEdges.Enabled = true;
				gbTroubleshooting.Enabled = true;
				gbAgents.Enabled = true;
				gbTestGhostCall.Enabled = true;
				gbCounters.Enabled = true;

				// Populate Edges
				GetEdges();

				// Get Agents Stats
				AddLog("Starting timer for monitoring agent status", true);
				PullAgentsData();
				timer.Interval = 5000;
				timer.Tick += (object timerSender, EventArgs eventArgs) => { PullAgentsData(); };
				timer.Start();
				AddLog("Timer started", true);
			}
			catch (Exception ex)
			{
				AddLog($"Error in btnConnect_Click: {ex.Message}");
				AddLog($"Detailled error: {ex}", true);
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				btnConnect.Enabled = true;
				btnDisconnect.Enabled = false;
				gbEdges.Enabled = false;
				gbTroubleshooting.Enabled = false;
				gbAgents.Enabled = false;
				gbTestGhostCall.Enabled = false;
				gbCounters.Enabled = false;
				loggedIn = false;
			}
		}

		private void btnDisconnect_Click(object sender, EventArgs e)
		{
			Disconnect();
		}

		private void Disconnect()
		{
			if (!btnDisconnect.Enabled) { return; }
			loggedIn = false;
			AddLog("Disconnecting...");
			StopPullingAgentsData();
			tokensApi.DeleteTokensMe();
			btnConnect.Enabled = true;
			btnDisconnect.Enabled = false;
			gbEdges.Enabled = false;
			gbTroubleshooting.Enabled = false;
			gbAgents.Enabled = false;
			gbTestGhostCall.Enabled = false;
			gbCounters.Enabled = false;
			AddLog("Disconnected");
		}

		#endregion

		#region Agents

		private void PullAgentsData()
		{
			_LoggedInAgents = 0;
			_NotRespondingAgents = 0;

			usersApi = new UsersApi();

			var pageNumber = 1;
			var pageCount = 1;

			AddLog("Getting agents routing status", true);
			do
			{
				var userEntityListing = usersApi.GetUsers(100, pageNumber++, null, null, new List<string>() { "routingStatus", "presence" });
				pageCount = userEntityListing.PageCount.Value;

				_LoggedInAgents += userEntityListing.Entities.Count(u => !u.Presence.PresenceDefinition.SystemPresence.Equals("offline", StringComparison.InvariantCultureIgnoreCase));
				_NotRespondingAgents += userEntityListing.Entities.Count(u => u.RoutingStatus.Status == RoutingStatus.StatusEnum.NotResponding);
			} while (pageNumber <= pageCount && loggedIn);

			AddLog($"Logged in agents: {_LoggedInAgents}, Not Responding Agents: {_NotRespondingAgents}", true);
			lblLoggedInAgentsValue.Text = _LoggedInAgents.ToString();
			lblNotRespondingAgentsValue.Text = _NotRespondingAgents.ToString();
		}

		private void StopPullingAgentsData()
		{
			timer.Stop();
		}

		#endregion

		#region Edges

		private void GetEdges()
		{
			try
			{
				AddLog("Clearing current edges...", true);
				cmbEdges.Items.Clear();
				var edgeEntityListing = telephonyProvidersEdgeApi.GetTelephonyProvidersEdges();
				foreach (var edge in edgeEntityListing.Entities)
				{
					cmbEdges.Items.Add(new EdgeInfo(edge.Id, edge.Name, edge.OnlineStatus.Value == Edge.OnlineStatusEnum.Online || edge.OnlineStatus.Value == Edge.OnlineStatusEnum.OutdatedSdkVersion ? true : false));
				}
				cmbEdges.SelectedIndex = 0;
			}
			catch (Exception ex)
			{
				AddLog($"Error in GetQueues: {ex.Message}");
				AddLog($"Detailled error: {ex}", true);
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void btnRefreshEdges_Click(object sender, EventArgs e)
		{
			GetEdges();
		}

		private void cmbEdges_SelectedIndexChanged(object sender, EventArgs e)
		{
			currentEdge = (EdgeInfo)((ComboBox)sender).SelectedItem;
			AddLog($"Selected Edge: {currentEdge.Id}, {currentEdge.Name}, {currentEdge.Online}", true);
		}

		#endregion

		#region Ghost Calls

		private void btnFindGhostCalls_Click(object sender, EventArgs e)
		{
			conversationsToDisconnect.Clear();

			if (currentEdge == null)
			{
				// Something wrong happened
				AddLog("Please select an edge first.");
				return;
			}

			// Get all active calls conversations
			var conversations = GetActiveConversations();
			AddLog($"Retrieved {conversations.Count} active conversations. Checking each one of them...", true);
			foreach (var conversation in conversations)
			{
				//Last participant with edge id in session that matches should be disconnected
				if (conversation.ConversationEnd != null)
				{
					AddLog($"Conversation {conversation.ConversationId} is ended ({conversation.ConversationEnd}). Ignoring...", true);
					continue; // Conversation is finished, ignore
				}

				// Is this a ghost call?
				var currentConversation = GetSingleAnalyticsConversation(conversation.ConversationId);
				if (currentConversation == null) { continue; }
				if (TestGhostCall(currentConversation))
				{
					AddLog($"  ==> Need to disconnect Conversation: {conversation.ConversationId} ?");

					// Get last participant
					var lastParticipant = conversation.Participants[conversation.Participants.Count - 1];

					// Get latest session with an Edge Id that matches selected edge
					var lastSession = lastParticipant.Sessions.LastOrDefault(s => (s.MediaType == AnalyticsSession.MediaTypeEnum.Voice && !string.IsNullOrEmpty(s.EdgeId)));
					if (lastSession != null && lastSession.EdgeId.Equals(currentEdge.Id))
					{
						// Add to Disconnect List
						conversationsToDisconnect.Add(conversation);
						AddLog($"  This conversation needs to be disconnected ==> Id: {conversation.ConversationId}, Participant: {lastParticipant.ParticipantName} ({lastParticipant.Purpose}), Media Type: {lastSession.MediaType}");
					}
				}
			}
			AddLog($"Found {conversationsToDisconnect.Count} conversations to disconnect on {currentEdge.Name}");
		}

		private void btnDisconnectGhostCalls_Click(object sender, EventArgs e)
		{
			if (conversationsToDisconnect.Count == 0)
			{
				MessageBox.Show("No ghost calls found.");
				return;
			}

			if (MessageBox.Show($"Found {conversationsToDisconnect.Count} conversations to disconnect. Disconnect them now?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
			{
				AddLog("Checking if selected edge is still offline...", true);
				GetEdges();
				if (((EdgeInfo)cmbEdges.SelectedItem).Online != true)
				{
					foreach (var conversation in conversationsToDisconnect)
					{
						DisconnectConversation(conversation.ConversationId);
					}
				}
			}
			conversationsToDisconnect.Clear();
		}

		private List<AnalyticsConversation> GetActiveConversations()
		{
			AddLog("Getting active conversations...", true);
			var conversations = new List<AnalyticsConversation>();
			var pageNumber = 1;
			AnalyticsConversationQueryResponse analyticsConversationQueryResponse = null;

			var dateTimeNowISO = DateTime.UtcNow.ToString("yyyy-MM-ddTHH\\:mm\\:ss.fffZ");
			var dateTimeNowISOMinus1Day = DateTime.UtcNow.AddDays(-1).ToString("yyyy-MM-ddTHH\\:mm\\:ss.fffZ");

			AddLog($"Start Date/Time: {dateTimeNowISOMinus1Day}", true);
			AddLog($"End Date/Time: {dateTimeNowISO}", true);

			do
			{
				var body = new ConversationQuery()
				{
					Interval = $"{dateTimeNowISOMinus1Day}/{dateTimeNowISO}",
					ConversationFilters = new List<AnalyticsQueryFilter>()
				{
					new AnalyticsQueryFilter(
						AnalyticsQueryFilter.TypeEnum.And,
						new List<AnalyticsQueryClause>()
						{
							new AnalyticsQueryClause()
							{
								// Should not be disconnected
								Type = AnalyticsQueryClause.TypeEnum.And,
								Predicates = new List<AnalyticsQueryPredicate>()
								{
									new AnalyticsQueryPredicate()
									{
									   Type = AnalyticsQueryPredicate.TypeEnum.Dimension,
									   Dimension = AnalyticsQueryPredicate.DimensionEnum.Conversationend,
									   _Operator = AnalyticsQueryPredicate.OperatorEnum.Notexists
									}
								}
							}
						}
					)
				},
					SegmentFilters = new List<AnalyticsQueryFilter>()
				{
					new AnalyticsQueryFilter(
						AnalyticsQueryFilter.TypeEnum.And,
						new List<AnalyticsQueryClause>()
						{
							new AnalyticsQueryClause()
							{
								Type = AnalyticsQueryClause.TypeEnum.And,
								Predicates = new List<AnalyticsQueryPredicate>()
								{
									// Should be a call
									new AnalyticsQueryPredicate()
									{
										Type = AnalyticsQueryPredicate.TypeEnum.Dimension,
										Dimension = AnalyticsQueryPredicate.DimensionEnum.Mediatype,
										_Operator = AnalyticsQueryPredicate.OperatorEnum.Matches,
										Value = "voice"
									},
									// Should match selected edge
									new AnalyticsQueryPredicate()
									{
										Type = AnalyticsQueryPredicate.TypeEnum.Dimension,
										Dimension = AnalyticsQueryPredicate.DimensionEnum.Edgeid,
										_Operator = AnalyticsQueryPredicate.OperatorEnum.Matches,
										Value = currentEdge.Id
									}
								}
							}
						}
					)
				},
					Order = ConversationQuery.OrderEnum.Asc,
					OrderBy = ConversationQuery.OrderByEnum.Conversationstart,
					Paging = new PagingSpec()
					{
						PageSize = 100,
						PageNumber = pageNumber++
					}
				};

				analyticsConversationQueryResponse = analyticsApi.PostAnalyticsConversationsDetailsQuery(body);
				AddLog($"Got response: {analyticsConversationQueryResponse.ToString()}", true);

				if (analyticsConversationQueryResponse.Conversations != null)
				{
					AddLog($"Got {analyticsConversationQueryResponse.Conversations.Count} conversations", true);
					foreach (var analyticsConversation in analyticsConversationQueryResponse.Conversations)
					{
						conversations.Add(analyticsConversation);
					}
				}

			} while (analyticsConversationQueryResponse.Conversations != null);

			return conversations;
		}

		private Conversation GetSingleConversation(string conversationId)
		{
			Conversation conversation = null;
			try
			{
				AddLog($"Getting a single conversation: {conversationId}", true);
				conversation = conversationsApi.GetConversation(conversationId);
				AddLog($"Conversation: {conversation.ToString()}", true);
			}
			catch (Exception ex)
			{
				AddLog($"Error while getting conversation {conversationId}: {ex.Message}");
				AddLog($"Detailled error: {ex}", true);
			}
			return conversation;
		}

		private async void DisconnectConversation(string conversationId)
		{
			try
			{
				AddLog($"Disconnecting {conversationId}...");
				var result = await conversationsApi.PostConversationDisconnectAsync(conversationId);
				AddLog($"Conversation {conversationId} disconnected: {result}");
				var currentDisconnectedCallsValue = Convert.ToInt32(lblDisconnectedCallsValue.Text) + 1;
				lblDisconnectedCallsValue.Text = currentDisconnectedCallsValue.ToString();
			}
			catch (Exception ex)
			{
				AddLog($"Error while disconnecting {conversationId}: {ex.Message}");
				AddLog($"Detailled error: {ex}", true);
			}
		}

		#endregion

		#region Log

		private void AddLog(string message, bool verbose = false)
		{
			if (verbose && !chkVerboseLogging.Checked) { return; }
			lstLog.Items.Add($"{DateTime.Now} {message}");
		}

		private void btnClearLog_Click(object sender, EventArgs e)
		{
			lstLog.Items.Clear();
		}

		private void lstLog_DoubleClick(object sender, EventArgs e)
		{
			var selectedString = lstLog.SelectedItem.ToString();
			var selectedConversationId = selectedString.Substring(selectedString.IndexOf("(Conversation: ") + "(Conversation: ".Length, 36);
			Clipboard.SetText(selectedConversationId);
			txtConversationId.Text = selectedConversationId;
			AddLog($"Conversation id {selectedConversationId} copied to the conversation id textboxes");
		}

		private void btnSaveLog_Click(object sender, EventArgs e)
		{
			using (SaveFileDialog saveFileDialog = new SaveFileDialog())
			{
				saveFileDialog.Title = "Save Log File";
				saveFileDialog.Filter = "log files (*.log)|*.log|All files (*.*)|*.*";
				saveFileDialog.FilterIndex = 2;
				saveFileDialog.RestoreDirectory = true;

				if (saveFileDialog.ShowDialog() == DialogResult.OK)
				{
					var streamWriter = new StreamWriter(saveFileDialog.FileName);
					foreach (var item in lstLog.Items)
					{
						streamWriter.WriteLine(item.ToString());
					}
					streamWriter.Close();
					AddLog($"Logs saved in {saveFileDialog.FileName}");
				}
			}
		}

		#endregion

		#region Troubleshooting

		private void btnGetConversationDetails_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(txtConversationId.Text)) { return; }
			try
			{
				AddLog($"Getting conversation details for {txtConversationId.Text}", true);
				var conversation = conversationsApi.GetConversation(txtConversationId.Text);
				var jsonConversation = JsonConvert.SerializeObject(conversation, Formatting.Indented);
				AddLog($"Conversation {txtConversationId.Text} details: {jsonConversation}", true);

				var displayConversation = new DisplayConversation(jsonConversation);
				displayConversation.ShowDialog();
			}
			catch (Exception ex)
			{
				AddLog($"Error while getting conversation {txtConversationId.Text}: {ex.Message}");
				AddLog($"Detailled error: {ex}", true);
			}
		}

		private void btnTestGhostCall_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(txtAnalyticsConversationId.Text)) { return; }
			var currentConversation = GetSingleAnalyticsConversation(txtAnalyticsConversationId.Text);
			if (currentConversation == null) { return; }

			MessageBox.Show($"Ghost call? {TestGhostCall(currentConversation)}");
		}

		private AnalyticsConversation GetSingleAnalyticsConversation(string conversationId)
		{
			var conversations = new List<AnalyticsConversation>();
			AnalyticsConversationQueryResponse analyticsConversationQueryResponse = null;

			// Find conversation by id
			AddLog($"Getting a single Analytics Conversation: {conversationId}", true);

			var interval = $"{dtAnalyticsStart.Value.ToString("yyyy-MM-ddTHH\\:mm\\:ss.fffZ")}/{dtAnalyticsEnd.Value.ToString("yyyy-MM-ddTHH\\:mm\\:ss.fffZ")}";
			AddLog($"Interval: {interval}", true);

			var body = new ConversationQuery()
			{
				Interval = interval,
				ConversationFilters = new List<AnalyticsQueryFilter>()
				{
					new AnalyticsQueryFilter(
						AnalyticsQueryFilter.TypeEnum.And,
						new List<AnalyticsQueryClause>()
						{
							new AnalyticsQueryClause()
							{
								Type = AnalyticsQueryClause.TypeEnum.And,
								Predicates = new List<AnalyticsQueryPredicate>()
								{
									new AnalyticsQueryPredicate()
									{
									   Type = AnalyticsQueryPredicate.TypeEnum.Dimension,
									   Dimension = AnalyticsQueryPredicate.DimensionEnum.Conversationid,
									   _Operator = AnalyticsQueryPredicate.OperatorEnum.Matches,
									   Value = conversationId
									}
								}
							}
						}
					)
				},
				Paging = new PagingSpec()
				{
					PageSize = 25,
					PageNumber = 1
				}
			};

			analyticsConversationQueryResponse = analyticsApi.PostAnalyticsConversationsDetailsQuery(body);
			if (analyticsConversationQueryResponse.Conversations != null && analyticsConversationQueryResponse.Conversations.Count > 0)
			{
				AddLog($"Got {analyticsConversationQueryResponse.Conversations.Count} analytics conversation(s)", true);
				return analyticsConversationQueryResponse.Conversations[0];
			} else 
			{
				MessageBox.Show($"Conversation {conversationId} not found.");
			}
			return null;
		}

		private bool TestGhostCall(AnalyticsConversation conversation)
		{
			// Is this an external/inbound/outbound call on selected edge?
			var participant = conversation.Participants.FirstOrDefault(p => (p.Purpose == AnalyticsParticipant.PurposeEnum.External || p.Purpose == AnalyticsParticipant.PurposeEnum.Inbound || p.Purpose == AnalyticsParticipant.PurposeEnum.Outbound || p.Purpose == AnalyticsParticipant.PurposeEnum.Customer) && p.Sessions.Count(s => s.EdgeId == currentEdge.Id) > 0);
			if (participant == null)
			{
				return false;
			}

			// Is the edge offline?
			if (telephonyProvidersEdgeApi.GetTelephonyProvidersEdge(currentEdge.Id).OnlineStatus == Edge.OnlineStatusEnum.Offline)
			{
				return true;
			}
			return false;
		}

		private void txtConversationId_TextChanged(object sender, EventArgs e)
		{
			linkConversation.Links.Clear();
			if (!string.IsNullOrEmpty(txtConversationId.Text))
			{
				LinkLabel.Link link = new LinkLabel.Link();
				link.LinkData = $"https://apps.{cmbEnvironment.SelectedItem}/directory/#/engage/admin/interactions/{txtConversationId.Text}";
				linkConversation.Links.Add(link);
			}
		}

		private void txtAnalyticsConversationId_TextChanged(object sender, EventArgs e)
		{
			linkConversation2.Links.Clear();
			if (!string.IsNullOrEmpty(txtAnalyticsConversationId.Text))
			{
				LinkLabel.Link link = new LinkLabel.Link();
				link.LinkData = $"https://apps.{cmbEnvironment.SelectedItem}/directory/#/engage/admin/interactions/{txtAnalyticsConversationId.Text}";
				linkConversation2.Links.Add(link);
			}
		}

		private void linkConversation_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			if (linkConversation.Links.Count > 0 && linkConversation.Links[0].LinkData != null)
			{
				Process.Start(linkConversation.Links[0].LinkData.ToString());
			}
		}

		private void linkConversation2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			if (linkConversation2.Links.Count > 0 && linkConversation2.Links[0].LinkData != null)
			{
				Process.Start(linkConversation2.Links[0].LinkData.ToString());
			}
		}

		private void btnDisconnectConversation_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show($"Are you sure you want to disconnect conversation {txtConversationId.Text}?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
			{
				DisconnectConversation(txtConversationId.Text);
			}
		}

		#endregion
	}
}

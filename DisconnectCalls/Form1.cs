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

		#endregion

		#region Init

		public Form1()
		{
			InitializeComponent();

			cmbEnvironment.SelectedIndex = 0;
			dtAnalyticsStart.Value = DateTime.Now.AddDays(-1);
			dtAnalyticsEnd.Value = DateTime.Now;
			btnConnect.Select();

			Application.ApplicationExit += (sender, e) =>
			{
				Disconnect();
			};

			AddLog("Ready.");
			AddLog("Select your environment, enter a client id & secret and click on 'Login' to get started.");
		}

		#endregion

		#region PureCloud Connection

		private void btnConnect_Click(object sender, EventArgs e)
		{
			try
			{
				if (String.IsNullOrEmpty(txtClientId.Text) || String.IsNullOrEmpty(txtClientSecret.Text))
				{
					MessageBox.Show("Enter a client id & secret first.");
					return;
				}

				// Connect to PureCloud
				AddLog("Connecting...");
				Configuration.Default.ApiClient.RestClient.BaseUrl = new Uri($"https://api.{cmbEnvironment.SelectedItem.ToString()}");
				var accessTokenInfo = Configuration.Default.ApiClient.PostToken(txtClientId.Text, txtClientSecret.Text);
				Configuration.Default.AccessToken = accessTokenInfo.AccessToken;
				AddLog($"Connected. Access Token: {accessTokenInfo.AccessToken}");

				// Get APIs
				analyticsApi = new AnalyticsApi();
				routingApi = new RoutingApi();
				conversationsApi = new ConversationsApi();
				tokensApi = new TokensApi();
				telephonyProvidersEdgeApi = new TelephonyProvidersEdgeApi();

				// Update Controls
				btnConnect.Enabled = false;
				btnDisconnect.Enabled = true;
				gbEdges.Enabled = true;
				gbTroubleshooting.Enabled = true;
				gbAgents.Enabled = true;
				gbTestPhantomCall.Enabled = true;

				// Populate Edges
				GetEdges();

				// Get Agents Stats
				StartMonitoringAgents();
				var timer = new Timer();
				timer.Interval = 5000;
				timer.Tick += (object timerSender, EventArgs eventArgs) => { StartMonitoringAgents(); };
				timer.Start();
			}
			catch (Exception ex)
			{
				AddLog($"Error in btnConnect_Click: {ex.Message}");
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				btnConnect.Enabled = true;
				btnDisconnect.Enabled = false;
				gbEdges.Enabled = false;
				gbTroubleshooting.Enabled = false;
				gbAgents.Enabled = false;
				gbTestPhantomCall.Enabled = false;
			}
		}

		private void Timer_Tick(object sender, EventArgs e)
		{
			throw new NotImplementedException();
		}

		private void btnDisconnect_Click(object sender, EventArgs e)
		{
			Disconnect();
		}

		private void Disconnect()
		{
			if (!btnDisconnect.Enabled) { return; }
			AddLog("Disconnecting...");
			tokensApi.DeleteTokensMe();
			btnConnect.Enabled = true;
			btnDisconnect.Enabled = false;
			gbEdges.Enabled = false;
			gbTroubleshooting.Enabled = false;
			gbAgents.Enabled = false;
			gbTestPhantomCall.Enabled = false;
			AddLog("Disconnected");
		}

		#endregion

		#region Agents

		private void StartMonitoringAgents()
		{
			_LoggedInAgents = 0;
			_NotRespondingAgents = 0;

			usersApi = new UsersApi();

			var pageNumber = 1;
			var pageCount = 1;

			do
			{
				var userEntityListing = usersApi.GetUsers(100, pageNumber++, null, null, new List<string>() { "routingStatus", "presence" });
				pageCount = userEntityListing.PageCount.Value;

				_LoggedInAgents += userEntityListing.Entities.Count(u => !u.Presence.PresenceDefinition.SystemPresence.Equals("offline", StringComparison.InvariantCultureIgnoreCase));
				_NotRespondingAgents += userEntityListing.Entities.Count(u => u.RoutingStatus.Status == RoutingStatus.StatusEnum.NotResponding);
			} while (pageNumber <= pageCount);

			lblLoggedInAgentsValue.Text = _LoggedInAgents.ToString();
			lblNotRespondingAgentsValue.Text = _NotRespondingAgents.ToString();
		}

		#endregion

		#region Edges

		private void GetEdges()
		{
			try
			{
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
		}

		#endregion

		#region Disconnect Calls

		private void btnDisconnectAllCalls_Click(object sender, EventArgs e)
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
			foreach (var conversation in conversations)
			{
				//Last participant with edge id in session that matches should be disconnected
				if (conversation.ConversationEnd != null)
				{
					return; // Conversation is finished, ignore
				}

				//// Is this a phantom call?
				//var currentConversation = GetSingleConversation(conversation.ConversationId);
				//if (currentConversation == null) { continue; }
				//if (TestPhantomCall(currentConversation))
				//{
				//	// Add to Disconnect List
				//	conversationsToDisconnect.Add(conversation);
				//	AddLog($"  ==> Need to disconnect Conversation: {conversation.ConversationId}");
				//}

				//// Get last participant
				//var lastParticipant = conversation.Participants[conversation.Participants.Count - 1];

				//// Get latest session with an Edge Id that matches selected edge
				//var lastSession = lastParticipant.Sessions.LastOrDefault(s => (s.MediaType == AnalyticsSession.MediaTypeEnum.Voice && !String.IsNullOrEmpty(s.EdgeId)));
				//if (lastSession != null && lastSession.EdgeId.Equals(currentEdge.Id))
				//{
				//	// Add to Disconnect List
				//	conversationsToDisconnect.Add(conversation);
				//	AddLog($"  ==> Disconnect! (Conversation: {conversation.ConversationId}, Participant: {lastParticipant.ParticipantName} ({lastParticipant.Purpose}), Media Type: {lastSession.MediaType}");
				//}
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
				//Check if the selected edge is STILL offline
				GetEdges();
				if (((EdgeInfo)cmbEdges.SelectedItem).Online != true)
				{
					foreach (var conversation in conversationsToDisconnect)
					{
						DisconnectConversation(conversation.ConversationId);
					}
				}
			}
		}

		private List<AnalyticsConversation> GetActiveConversations()
		{
			var conversations = new List<AnalyticsConversation>();
			var pageNumber = 1;
			AnalyticsConversationQueryResponse analyticsConversationQueryResponse = null;

			var dateTimeNowISO = DateTime.UtcNow.ToString("yyyy-MM-ddTHH\\:mm\\:ss.fffZ");
			var dateTimeNowISOMinus1Day = DateTime.UtcNow.AddDays(-1).ToString("yyyy-MM-ddTHH\\:mm\\:ss.fffZ");

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

				if (analyticsConversationQueryResponse.Conversations != null)
				{
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
				conversation = conversationsApi.GetConversation(conversationId);
			}
			catch (Exception ex)
			{
				AddLog($"Error while getting conversation {conversationId}: {ex.Message}");
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
			}
			catch (Exception ex)
			{
				AddLog($"Error while disconnecting {conversationId}: {ex.Message}");
			}
		}

		#endregion

		#region Log

		private void AddLog(string message)
		{
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
			if (String.IsNullOrEmpty(txtConversationId.Text)) { return; }
			try
			{
				var conversation = conversationsApi.GetConversation(txtConversationId.Text);
				var jsonConversation = JsonConvert.SerializeObject(conversation, Formatting.Indented);

				var displayConversation = new DisplayConversation(jsonConversation);
				displayConversation.ShowDialog();
			}
			catch (Exception ex)
			{
				AddLog($"Error while getting conversation {txtConversationId.Text}: {ex.Message}");
			}
		}

		private void btnTestPhantomCall_Click(object sender, EventArgs e)
		{
			if (String.IsNullOrEmpty(txtAnalyticsConversationId.Text)) { return; }
			var currentConversation = GetSingleAnalyticsConversation(txtAnalyticsConversationId.Text);
			if (currentConversation == null) { return; }

			MessageBox.Show($"Phantom call? {TestPhantomCall(currentConversation)}");
		}

		private AnalyticsConversation GetSingleAnalyticsConversation(string conversationId)
		{
			var conversations = new List<AnalyticsConversation>();
			AnalyticsConversationQueryResponse analyticsConversationQueryResponse = null;

			// Find conversation by id
			var body = new ConversationQuery()
			{
				Interval = $"{dtAnalyticsStart.Value.ToString("yyyy-MM-ddTHH\\:mm\\:ss.fffZ")}/{dtAnalyticsEnd.Value.ToString("yyyy-MM-ddTHH\\:mm\\:ss.fffZ")}",
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
				return analyticsConversationQueryResponse.Conversations[0];
			} else 
			{
				MessageBox.Show($"Conversation {conversationId} not found.");
			}
			return null;
		}

		private bool TestPhantomCall(AnalyticsConversation conversation)
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
			if (!String.IsNullOrEmpty(txtConversationId.Text))
			{
				LinkLabel.Link link = new LinkLabel.Link();
				link.LinkData = $"https://apps.{cmbEnvironment.SelectedItem}/directory/#/engage/admin/interactions/{txtConversationId.Text}";
				linkConversation.Links.Add(link);
			}
		}

		private void txtAnalyticsConversationId_TextChanged(object sender, EventArgs e)
		{
			linkConversation2.Links.Clear();
			if (!String.IsNullOrEmpty(txtAnalyticsConversationId.Text))
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

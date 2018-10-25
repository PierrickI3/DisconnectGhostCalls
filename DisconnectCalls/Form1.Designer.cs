namespace DisconnectCalls
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btnDisconnect = new System.Windows.Forms.Button();
			this.btnConnect = new System.Windows.Forms.Button();
			this.cmbEnvironment = new System.Windows.Forms.ComboBox();
			this.lblEnvironment = new System.Windows.Forms.Label();
			this.txtClientSecret = new System.Windows.Forms.TextBox();
			this.lblClientSecret = new System.Windows.Forms.Label();
			this.txtClientId = new System.Windows.Forms.TextBox();
			this.lblClientId = new System.Windows.Forms.Label();
			this.gbEdges = new System.Windows.Forms.GroupBox();
			this.lblInstructions = new System.Windows.Forms.Label();
			this.btnDisconnectGhostCalls = new System.Windows.Forms.Button();
			this.btnRefreshEdges = new System.Windows.Forms.Button();
			this.btnDisconnectAllCalls = new System.Windows.Forms.Button();
			this.cmbEdges = new System.Windows.Forms.ComboBox();
			this.lblEdges = new System.Windows.Forms.Label();
			this.lstLog = new System.Windows.Forms.ListBox();
			this.btnClearLog = new System.Windows.Forms.Button();
			this.lblConversationId = new System.Windows.Forms.Label();
			this.txtConversationId = new System.Windows.Forms.TextBox();
			this.btnGetConversationDetails = new System.Windows.Forms.Button();
			this.gbTroubleshooting = new System.Windows.Forms.GroupBox();
			this.btnDisconnectConversation = new System.Windows.Forms.Button();
			this.linkConversation = new System.Windows.Forms.LinkLabel();
			this.lblAnalyticsEndDateTime = new System.Windows.Forms.Label();
			this.lblAnalyticsStartDateTime = new System.Windows.Forms.Label();
			this.dtAnalyticsEnd = new System.Windows.Forms.DateTimePicker();
			this.dtAnalyticsStart = new System.Windows.Forms.DateTimePicker();
			this.btnTestPhantomCall = new System.Windows.Forms.Button();
			this.gbAgents = new System.Windows.Forms.GroupBox();
			this.lblLoggedInAgentsValue = new System.Windows.Forms.Label();
			this.lblLoggedInAgents = new System.Windows.Forms.Label();
			this.lblNotRespondingAgentsValue = new System.Windows.Forms.Label();
			this.lblNotRespondingAgents = new System.Windows.Forms.Label();
			this.gbTestPhantomCall = new System.Windows.Forms.GroupBox();
			this.linkConversation2 = new System.Windows.Forms.LinkLabel();
			this.txtAnalyticsConversationId = new System.Windows.Forms.TextBox();
			this.lblAnalyticsConversationId = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.lblDisconnectedCallsValue = new System.Windows.Forms.Label();
			this.lblDisconnectedCalls = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.gbEdges.SuspendLayout();
			this.gbTroubleshooting.SuspendLayout();
			this.gbAgents.SuspendLayout();
			this.gbTestPhantomCall.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.btnDisconnect);
			this.groupBox1.Controls.Add(this.btnConnect);
			this.groupBox1.Controls.Add(this.cmbEnvironment);
			this.groupBox1.Controls.Add(this.lblEnvironment);
			this.groupBox1.Controls.Add(this.txtClientSecret);
			this.groupBox1.Controls.Add(this.lblClientSecret);
			this.groupBox1.Controls.Add(this.txtClientId);
			this.groupBox1.Controls.Add(this.lblClientId);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
			this.groupBox1.Size = new System.Drawing.Size(1812, 246);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "PureCloud Settings";
			// 
			// btnDisconnect
			// 
			this.btnDisconnect.Enabled = false;
			this.btnDisconnect.Location = new System.Drawing.Point(458, 185);
			this.btnDisconnect.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
			this.btnDisconnect.Name = "btnDisconnect";
			this.btnDisconnect.Size = new System.Drawing.Size(150, 44);
			this.btnDisconnect.TabIndex = 7;
			this.btnDisconnect.Text = "Logout";
			this.btnDisconnect.UseVisualStyleBackColor = true;
			this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
			// 
			// btnConnect
			// 
			this.btnConnect.Location = new System.Drawing.Point(168, 185);
			this.btnConnect.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
			this.btnConnect.Name = "btnConnect";
			this.btnConnect.Size = new System.Drawing.Size(150, 44);
			this.btnConnect.TabIndex = 6;
			this.btnConnect.Text = "Login";
			this.btnConnect.UseVisualStyleBackColor = true;
			this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
			// 
			// cmbEnvironment
			// 
			this.cmbEnvironment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbEnvironment.FormattingEnabled = true;
			this.cmbEnvironment.Items.AddRange(new object[] {
            "mypurecloud.de",
            "mypurecloud.ie",
            "mypurecloud.com",
            "mypurecloud.com.au",
            "mypurecloud.jp"});
			this.cmbEnvironment.Location = new System.Drawing.Point(168, 33);
			this.cmbEnvironment.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
			this.cmbEnvironment.Name = "cmbEnvironment";
			this.cmbEnvironment.Size = new System.Drawing.Size(436, 33);
			this.cmbEnvironment.TabIndex = 5;
			// 
			// lblEnvironment
			// 
			this.lblEnvironment.AutoSize = true;
			this.lblEnvironment.Location = new System.Drawing.Point(18, 38);
			this.lblEnvironment.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
			this.lblEnvironment.Name = "lblEnvironment";
			this.lblEnvironment.Size = new System.Drawing.Size(138, 25);
			this.lblEnvironment.TabIndex = 4;
			this.lblEnvironment.Text = "Environment:";
			// 
			// txtClientSecret
			// 
			this.txtClientSecret.Location = new System.Drawing.Point(168, 135);
			this.txtClientSecret.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
			this.txtClientSecret.Name = "txtClientSecret";
			this.txtClientSecret.PasswordChar = '*';
			this.txtClientSecret.Size = new System.Drawing.Size(436, 31);
			this.txtClientSecret.TabIndex = 3;
			this.txtClientSecret.Text = "_aobvCFokyL_67zER6HrY6Yr7q3hPJVC0ykEaIFlaHc";
			// 
			// lblClientSecret
			// 
			this.lblClientSecret.AutoSize = true;
			this.lblClientSecret.Location = new System.Drawing.Point(16, 140);
			this.lblClientSecret.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
			this.lblClientSecret.Name = "lblClientSecret";
			this.lblClientSecret.Size = new System.Drawing.Size(141, 25);
			this.lblClientSecret.TabIndex = 2;
			this.lblClientSecret.Text = "Client Secret:";
			// 
			// txtClientId
			// 
			this.txtClientId.Location = new System.Drawing.Point(168, 85);
			this.txtClientId.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
			this.txtClientId.Name = "txtClientId";
			this.txtClientId.Size = new System.Drawing.Size(436, 31);
			this.txtClientId.TabIndex = 1;
			this.txtClientId.Text = "06fb1dbf-7b95-4759-9779-15cb0928cf6f";
			// 
			// lblClientId
			// 
			this.lblClientId.AutoSize = true;
			this.lblClientId.Location = new System.Drawing.Point(60, 90);
			this.lblClientId.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
			this.lblClientId.Name = "lblClientId";
			this.lblClientId.Size = new System.Drawing.Size(96, 25);
			this.lblClientId.TabIndex = 0;
			this.lblClientId.Text = "Client Id:";
			// 
			// gbEdges
			// 
			this.gbEdges.Controls.Add(this.lblInstructions);
			this.gbEdges.Controls.Add(this.btnDisconnectGhostCalls);
			this.gbEdges.Controls.Add(this.btnRefreshEdges);
			this.gbEdges.Controls.Add(this.btnDisconnectAllCalls);
			this.gbEdges.Controls.Add(this.cmbEdges);
			this.gbEdges.Controls.Add(this.lblEdges);
			this.gbEdges.Enabled = false;
			this.gbEdges.Location = new System.Drawing.Point(0, 258);
			this.gbEdges.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
			this.gbEdges.Name = "gbEdges";
			this.gbEdges.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
			this.gbEdges.Size = new System.Drawing.Size(826, 204);
			this.gbEdges.TabIndex = 1;
			this.gbEdges.TabStop = false;
			this.gbEdges.Text = "PureCloud Edges";
			// 
			// lblInstructions
			// 
			this.lblInstructions.AutoSize = true;
			this.lblInstructions.Location = new System.Drawing.Point(162, 140);
			this.lblInstructions.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
			this.lblInstructions.MaximumSize = new System.Drawing.Size(600, 0);
			this.lblInstructions.Name = "lblInstructions";
			this.lblInstructions.Size = new System.Drawing.Size(567, 50);
			this.lblInstructions.TabIndex = 8;
			this.lblInstructions.Text = "What is a Ghost Call? Active call on an offline edge. If the edge is not offline," +
    " call is not considered a Ghost Call.";
			// 
			// btnDisconnectGhostCalls
			// 
			this.btnDisconnectGhostCalls.Location = new System.Drawing.Point(366, 90);
			this.btnDisconnectGhostCalls.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
			this.btnDisconnectGhostCalls.Name = "btnDisconnectGhostCalls";
			this.btnDisconnectGhostCalls.Size = new System.Drawing.Size(260, 44);
			this.btnDisconnectGhostCalls.TabIndex = 7;
			this.btnDisconnectGhostCalls.Text = "Disconnect Ghost Calls";
			this.btnDisconnectGhostCalls.UseVisualStyleBackColor = true;
			this.btnDisconnectGhostCalls.Click += new System.EventHandler(this.btnDisconnectGhostCalls_Click);
			// 
			// btnRefreshEdges
			// 
			this.btnRefreshEdges.Location = new System.Drawing.Point(638, 35);
			this.btnRefreshEdges.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
			this.btnRefreshEdges.Name = "btnRefreshEdges";
			this.btnRefreshEdges.Size = new System.Drawing.Size(178, 44);
			this.btnRefreshEdges.TabIndex = 6;
			this.btnRefreshEdges.Text = "Refresh Edges";
			this.btnRefreshEdges.UseVisualStyleBackColor = true;
			this.btnRefreshEdges.Click += new System.EventHandler(this.btnRefreshEdges_Click);
			// 
			// btnDisconnectAllCalls
			// 
			this.btnDisconnectAllCalls.Location = new System.Drawing.Point(168, 90);
			this.btnDisconnectAllCalls.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
			this.btnDisconnectAllCalls.Name = "btnDisconnectAllCalls";
			this.btnDisconnectAllCalls.Size = new System.Drawing.Size(186, 44);
			this.btnDisconnectAllCalls.TabIndex = 2;
			this.btnDisconnectAllCalls.Text = "Find Ghost Calls";
			this.btnDisconnectAllCalls.UseVisualStyleBackColor = true;
			this.btnDisconnectAllCalls.Click += new System.EventHandler(this.btnDisconnectAllCalls_Click);
			// 
			// cmbEdges
			// 
			this.cmbEdges.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbEdges.FormattingEnabled = true;
			this.cmbEdges.Location = new System.Drawing.Point(168, 38);
			this.cmbEdges.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
			this.cmbEdges.Name = "cmbEdges";
			this.cmbEdges.Size = new System.Drawing.Size(454, 33);
			this.cmbEdges.TabIndex = 1;
			this.cmbEdges.SelectedIndexChanged += new System.EventHandler(this.cmbEdges_SelectedIndexChanged);
			// 
			// lblEdges
			// 
			this.lblEdges.AutoSize = true;
			this.lblEdges.Location = new System.Drawing.Point(76, 44);
			this.lblEdges.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
			this.lblEdges.Name = "lblEdges";
			this.lblEdges.Size = new System.Drawing.Size(79, 25);
			this.lblEdges.TabIndex = 0;
			this.lblEdges.Text = "Edges:";
			// 
			// lstLog
			// 
			this.lstLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lstLog.FormattingEnabled = true;
			this.lstLog.ItemHeight = 25;
			this.lstLog.Location = new System.Drawing.Point(4, 673);
			this.lstLog.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
			this.lstLog.Name = "lstLog";
			this.lstLog.Size = new System.Drawing.Size(1802, 504);
			this.lstLog.TabIndex = 2;
			this.lstLog.DoubleClick += new System.EventHandler(this.lstLog_DoubleClick);
			// 
			// btnClearLog
			// 
			this.btnClearLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnClearLog.Location = new System.Drawing.Point(1650, 627);
			this.btnClearLog.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
			this.btnClearLog.Name = "btnClearLog";
			this.btnClearLog.Size = new System.Drawing.Size(162, 44);
			this.btnClearLog.TabIndex = 3;
			this.btnClearLog.Text = "Clear Log";
			this.btnClearLog.UseVisualStyleBackColor = true;
			this.btnClearLog.Click += new System.EventHandler(this.btnClearLog_Click);
			// 
			// lblConversationId
			// 
			this.lblConversationId.AutoSize = true;
			this.lblConversationId.Location = new System.Drawing.Point(12, 44);
			this.lblConversationId.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
			this.lblConversationId.Name = "lblConversationId";
			this.lblConversationId.Size = new System.Drawing.Size(168, 25);
			this.lblConversationId.TabIndex = 3;
			this.lblConversationId.Text = "Conversation Id:";
			// 
			// txtConversationId
			// 
			this.txtConversationId.Location = new System.Drawing.Point(192, 38);
			this.txtConversationId.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
			this.txtConversationId.Name = "txtConversationId";
			this.txtConversationId.Size = new System.Drawing.Size(526, 31);
			this.txtConversationId.TabIndex = 4;
			this.txtConversationId.TextChanged += new System.EventHandler(this.txtConversationId_TextChanged);
			// 
			// btnGetConversationDetails
			// 
			this.btnGetConversationDetails.Location = new System.Drawing.Point(192, 88);
			this.btnGetConversationDetails.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
			this.btnGetConversationDetails.Name = "btnGetConversationDetails";
			this.btnGetConversationDetails.Size = new System.Drawing.Size(146, 44);
			this.btnGetConversationDetails.TabIndex = 5;
			this.btnGetConversationDetails.Text = "Get Details";
			this.btnGetConversationDetails.UseVisualStyleBackColor = true;
			this.btnGetConversationDetails.Click += new System.EventHandler(this.btnGetConversationDetails_Click);
			// 
			// gbTroubleshooting
			// 
			this.gbTroubleshooting.Controls.Add(this.btnDisconnectConversation);
			this.gbTroubleshooting.Controls.Add(this.linkConversation);
			this.gbTroubleshooting.Controls.Add(this.lblConversationId);
			this.gbTroubleshooting.Controls.Add(this.btnGetConversationDetails);
			this.gbTroubleshooting.Controls.Add(this.txtConversationId);
			this.gbTroubleshooting.Enabled = false;
			this.gbTroubleshooting.Location = new System.Drawing.Point(838, 258);
			this.gbTroubleshooting.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
			this.gbTroubleshooting.Name = "gbTroubleshooting";
			this.gbTroubleshooting.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
			this.gbTroubleshooting.Size = new System.Drawing.Size(972, 158);
			this.gbTroubleshooting.TabIndex = 4;
			this.gbTroubleshooting.TabStop = false;
			this.gbTroubleshooting.Text = "Troubleshooting";
			// 
			// btnDisconnectConversation
			// 
			this.btnDisconnectConversation.Location = new System.Drawing.Point(542, 88);
			this.btnDisconnectConversation.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
			this.btnDisconnectConversation.Name = "btnDisconnectConversation";
			this.btnDisconnectConversation.Size = new System.Drawing.Size(180, 44);
			this.btnDisconnectConversation.TabIndex = 8;
			this.btnDisconnectConversation.Text = "Disconnect";
			this.btnDisconnectConversation.UseVisualStyleBackColor = true;
			this.btnDisconnectConversation.Click += new System.EventHandler(this.btnDisconnectConversation_Click);
			// 
			// linkConversation
			// 
			this.linkConversation.AutoSize = true;
			this.linkConversation.Location = new System.Drawing.Point(734, 44);
			this.linkConversation.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
			this.linkConversation.Name = "linkConversation";
			this.linkConversation.Size = new System.Drawing.Size(214, 25);
			this.linkConversation.TabIndex = 7;
			this.linkConversation.TabStop = true;
			this.linkConversation.Text = "Monitor in PureCloud";
			this.linkConversation.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkConversation_LinkClicked);
			// 
			// lblAnalyticsEndDateTime
			// 
			this.lblAnalyticsEndDateTime.AutoSize = true;
			this.lblAnalyticsEndDateTime.Location = new System.Drawing.Point(122, 138);
			this.lblAnalyticsEndDateTime.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
			this.lblAnalyticsEndDateTime.Name = "lblAnalyticsEndDateTime";
			this.lblAnalyticsEndDateTime.Size = new System.Drawing.Size(56, 25);
			this.lblAnalyticsEndDateTime.TabIndex = 12;
			this.lblAnalyticsEndDateTime.Text = "End:";
			// 
			// lblAnalyticsStartDateTime
			// 
			this.lblAnalyticsStartDateTime.AutoSize = true;
			this.lblAnalyticsStartDateTime.Location = new System.Drawing.Point(116, 88);
			this.lblAnalyticsStartDateTime.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
			this.lblAnalyticsStartDateTime.Name = "lblAnalyticsStartDateTime";
			this.lblAnalyticsStartDateTime.Size = new System.Drawing.Size(63, 25);
			this.lblAnalyticsStartDateTime.TabIndex = 11;
			this.lblAnalyticsStartDateTime.Text = "Start:";
			// 
			// dtAnalyticsEnd
			// 
			this.dtAnalyticsEnd.CustomFormat = "yyyy-MM-dd HH:mm:ss";
			this.dtAnalyticsEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtAnalyticsEnd.Location = new System.Drawing.Point(192, 133);
			this.dtAnalyticsEnd.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
			this.dtAnalyticsEnd.Name = "dtAnalyticsEnd";
			this.dtAnalyticsEnd.Size = new System.Drawing.Size(268, 31);
			this.dtAnalyticsEnd.TabIndex = 10;
			// 
			// dtAnalyticsStart
			// 
			this.dtAnalyticsStart.CustomFormat = "yyyy-MM-dd HH:mm:ss";
			this.dtAnalyticsStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtAnalyticsStart.Location = new System.Drawing.Point(192, 83);
			this.dtAnalyticsStart.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
			this.dtAnalyticsStart.Name = "dtAnalyticsStart";
			this.dtAnalyticsStart.Size = new System.Drawing.Size(268, 31);
			this.dtAnalyticsStart.TabIndex = 9;
			// 
			// btnTestPhantomCall
			// 
			this.btnTestPhantomCall.Location = new System.Drawing.Point(476, 104);
			this.btnTestPhantomCall.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
			this.btnTestPhantomCall.Name = "btnTestPhantomCall";
			this.btnTestPhantomCall.Size = new System.Drawing.Size(226, 44);
			this.btnTestPhantomCall.TabIndex = 6;
			this.btnTestPhantomCall.Text = "Is this a Ghost Call?";
			this.btnTestPhantomCall.UseVisualStyleBackColor = true;
			this.btnTestPhantomCall.Click += new System.EventHandler(this.btnTestPhantomCall_Click);
			// 
			// gbAgents
			// 
			this.gbAgents.Controls.Add(this.lblLoggedInAgentsValue);
			this.gbAgents.Controls.Add(this.lblLoggedInAgents);
			this.gbAgents.Controls.Add(this.lblNotRespondingAgentsValue);
			this.gbAgents.Controls.Add(this.lblNotRespondingAgents);
			this.gbAgents.Location = new System.Drawing.Point(0, 473);
			this.gbAgents.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
			this.gbAgents.Name = "gbAgents";
			this.gbAgents.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
			this.gbAgents.Size = new System.Drawing.Size(394, 142);
			this.gbAgents.TabIndex = 5;
			this.gbAgents.TabStop = false;
			this.gbAgents.Text = "Agents (refresh every 5 sec.)";
			// 
			// lblLoggedInAgentsValue
			// 
			this.lblLoggedInAgentsValue.AutoSize = true;
			this.lblLoggedInAgentsValue.Location = new System.Drawing.Point(206, 40);
			this.lblLoggedInAgentsValue.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
			this.lblLoggedInAgentsValue.Name = "lblLoggedInAgentsValue";
			this.lblLoggedInAgentsValue.Size = new System.Drawing.Size(47, 25);
			this.lblLoggedInAgentsValue.TabIndex = 3;
			this.lblLoggedInAgentsValue.Text = "N/A";
			// 
			// lblLoggedInAgents
			// 
			this.lblLoggedInAgents.AutoSize = true;
			this.lblLoggedInAgents.Location = new System.Drawing.Point(78, 40);
			this.lblLoggedInAgents.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
			this.lblLoggedInAgents.Name = "lblLoggedInAgents";
			this.lblLoggedInAgents.Size = new System.Drawing.Size(113, 25);
			this.lblLoggedInAgents.TabIndex = 2;
			this.lblLoggedInAgents.Text = "Logged In:";
			// 
			// lblNotRespondingAgentsValue
			// 
			this.lblNotRespondingAgentsValue.AutoSize = true;
			this.lblNotRespondingAgentsValue.Location = new System.Drawing.Point(206, 79);
			this.lblNotRespondingAgentsValue.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
			this.lblNotRespondingAgentsValue.Name = "lblNotRespondingAgentsValue";
			this.lblNotRespondingAgentsValue.Size = new System.Drawing.Size(47, 25);
			this.lblNotRespondingAgentsValue.TabIndex = 1;
			this.lblNotRespondingAgentsValue.Text = "N/A";
			// 
			// lblNotRespondingAgents
			// 
			this.lblNotRespondingAgents.AutoSize = true;
			this.lblNotRespondingAgents.Location = new System.Drawing.Point(20, 79);
			this.lblNotRespondingAgents.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
			this.lblNotRespondingAgents.Name = "lblNotRespondingAgents";
			this.lblNotRespondingAgents.Size = new System.Drawing.Size(172, 25);
			this.lblNotRespondingAgents.TabIndex = 0;
			this.lblNotRespondingAgents.Text = "Not Responding:";
			// 
			// gbTestPhantomCall
			// 
			this.gbTestPhantomCall.Controls.Add(this.linkConversation2);
			this.gbTestPhantomCall.Controls.Add(this.txtAnalyticsConversationId);
			this.gbTestPhantomCall.Controls.Add(this.lblAnalyticsConversationId);
			this.gbTestPhantomCall.Controls.Add(this.btnTestPhantomCall);
			this.gbTestPhantomCall.Controls.Add(this.lblAnalyticsEndDateTime);
			this.gbTestPhantomCall.Controls.Add(this.lblAnalyticsStartDateTime);
			this.gbTestPhantomCall.Controls.Add(this.dtAnalyticsEnd);
			this.gbTestPhantomCall.Controls.Add(this.dtAnalyticsStart);
			this.gbTestPhantomCall.Enabled = false;
			this.gbTestPhantomCall.Location = new System.Drawing.Point(838, 429);
			this.gbTestPhantomCall.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
			this.gbTestPhantomCall.Name = "gbTestPhantomCall";
			this.gbTestPhantomCall.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
			this.gbTestPhantomCall.Size = new System.Drawing.Size(974, 187);
			this.gbTestPhantomCall.TabIndex = 13;
			this.gbTestPhantomCall.TabStop = false;
			this.gbTestPhantomCall.Text = "Ghost Call Test";
			// 
			// linkConversation2
			// 
			this.linkConversation2.AutoSize = true;
			this.linkConversation2.Location = new System.Drawing.Point(734, 38);
			this.linkConversation2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
			this.linkConversation2.Name = "linkConversation2";
			this.linkConversation2.Size = new System.Drawing.Size(214, 25);
			this.linkConversation2.TabIndex = 13;
			this.linkConversation2.TabStop = true;
			this.linkConversation2.Text = "Monitor in PureCloud";
			this.linkConversation2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkConversation2_LinkClicked);
			// 
			// txtAnalyticsConversationId
			// 
			this.txtAnalyticsConversationId.Location = new System.Drawing.Point(192, 33);
			this.txtAnalyticsConversationId.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
			this.txtAnalyticsConversationId.Name = "txtAnalyticsConversationId";
			this.txtAnalyticsConversationId.Size = new System.Drawing.Size(526, 31);
			this.txtAnalyticsConversationId.TabIndex = 9;
			this.txtAnalyticsConversationId.TextChanged += new System.EventHandler(this.txtAnalyticsConversationId_TextChanged);
			// 
			// lblAnalyticsConversationId
			// 
			this.lblAnalyticsConversationId.AutoSize = true;
			this.lblAnalyticsConversationId.Location = new System.Drawing.Point(12, 38);
			this.lblAnalyticsConversationId.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
			this.lblAnalyticsConversationId.Name = "lblAnalyticsConversationId";
			this.lblAnalyticsConversationId.Size = new System.Drawing.Size(168, 25);
			this.lblAnalyticsConversationId.TabIndex = 9;
			this.lblAnalyticsConversationId.Text = "Conversation Id:";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.lblDisconnectedCallsValue);
			this.groupBox2.Controls.Add(this.lblDisconnectedCalls);
			this.groupBox2.Location = new System.Drawing.Point(406, 474);
			this.groupBox2.Margin = new System.Windows.Forms.Padding(6);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Padding = new System.Windows.Forms.Padding(6);
			this.groupBox2.Size = new System.Drawing.Size(420, 142);
			this.groupBox2.TabIndex = 6;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Counters";
			// 
			// lblDisconnectedCallsValue
			// 
			this.lblDisconnectedCallsValue.AutoSize = true;
			this.lblDisconnectedCallsValue.Location = new System.Drawing.Point(223, 38);
			this.lblDisconnectedCallsValue.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
			this.lblDisconnectedCallsValue.Name = "lblDisconnectedCallsValue";
			this.lblDisconnectedCallsValue.Size = new System.Drawing.Size(24, 25);
			this.lblDisconnectedCallsValue.TabIndex = 3;
			this.lblDisconnectedCallsValue.Text = "0";
			// 
			// lblDisconnectedCalls
			// 
			this.lblDisconnectedCalls.AutoSize = true;
			this.lblDisconnectedCalls.Location = new System.Drawing.Point(12, 38);
			this.lblDisconnectedCalls.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
			this.lblDisconnectedCalls.Name = "lblDisconnectedCalls";
			this.lblDisconnectedCalls.Size = new System.Drawing.Size(199, 25);
			this.lblDisconnectedCalls.TabIndex = 2;
			this.lblDisconnectedCalls.Text = "Disconnected calls:";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1812, 1194);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.gbAgents);
			this.Controls.Add(this.gbTestPhantomCall);
			this.Controls.Add(this.gbTroubleshooting);
			this.Controls.Add(this.btnClearLog);
			this.Controls.Add(this.lstLog);
			this.Controls.Add(this.gbEdges);
			this.Controls.Add(this.groupBox1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Form1";
			this.Text = "Disconnect Edge Calls - Use with Caution!";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.gbEdges.ResumeLayout(false);
			this.gbEdges.PerformLayout();
			this.gbTroubleshooting.ResumeLayout(false);
			this.gbTroubleshooting.PerformLayout();
			this.gbAgents.ResumeLayout(false);
			this.gbAgents.PerformLayout();
			this.gbTestPhantomCall.ResumeLayout(false);
			this.gbTestPhantomCall.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.ComboBox cmbEnvironment;
		private System.Windows.Forms.Label lblEnvironment;
		private System.Windows.Forms.TextBox txtClientSecret;
		private System.Windows.Forms.Label lblClientSecret;
		private System.Windows.Forms.TextBox txtClientId;
		private System.Windows.Forms.Label lblClientId;
		private System.Windows.Forms.Button btnDisconnect;
		private System.Windows.Forms.Button btnConnect;
		private System.Windows.Forms.GroupBox gbEdges;
		private System.Windows.Forms.ComboBox cmbEdges;
		private System.Windows.Forms.Label lblEdges;
		private System.Windows.Forms.ListBox lstLog;
		private System.Windows.Forms.Button btnDisconnectAllCalls;
		private System.Windows.Forms.Button btnClearLog;
		private System.Windows.Forms.Button btnGetConversationDetails;
		private System.Windows.Forms.TextBox txtConversationId;
		private System.Windows.Forms.Label lblConversationId;
		private System.Windows.Forms.Button btnRefreshEdges;
		private System.Windows.Forms.GroupBox gbTroubleshooting;
		private System.Windows.Forms.Button btnTestPhantomCall;
		private System.Windows.Forms.LinkLabel linkConversation;
		private System.Windows.Forms.Button btnDisconnectConversation;
		private System.Windows.Forms.Button btnDisconnectGhostCalls;
		private System.Windows.Forms.DateTimePicker dtAnalyticsStart;
		private System.Windows.Forms.Label lblAnalyticsEndDateTime;
		private System.Windows.Forms.Label lblAnalyticsStartDateTime;
		private System.Windows.Forms.DateTimePicker dtAnalyticsEnd;
		private System.Windows.Forms.GroupBox gbAgents;
		private System.Windows.Forms.Label lblNotRespondingAgentsValue;
		private System.Windows.Forms.Label lblNotRespondingAgents;
		private System.Windows.Forms.Label lblLoggedInAgentsValue;
		private System.Windows.Forms.Label lblLoggedInAgents;
		private System.Windows.Forms.Label lblInstructions;
		private System.Windows.Forms.GroupBox gbTestPhantomCall;
		private System.Windows.Forms.TextBox txtAnalyticsConversationId;
		private System.Windows.Forms.Label lblAnalyticsConversationId;
		private System.Windows.Forms.LinkLabel linkConversation2;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label lblDisconnectedCallsValue;
		private System.Windows.Forms.Label lblDisconnectedCalls;
	}
}


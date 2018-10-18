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
			this.btnSaveLog = new System.Windows.Forms.Button();
			this.chkVerboseLogging = new System.Windows.Forms.CheckBox();
			this.groupBox1.SuspendLayout();
			this.gbEdges.SuspendLayout();
			this.gbTroubleshooting.SuspendLayout();
			this.gbAgents.SuspendLayout();
			this.gbTestPhantomCall.SuspendLayout();
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
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(906, 128);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "PureCloud Settings";
			// 
			// btnDisconnect
			// 
			this.btnDisconnect.Enabled = false;
			this.btnDisconnect.Location = new System.Drawing.Point(229, 96);
			this.btnDisconnect.Name = "btnDisconnect";
			this.btnDisconnect.Size = new System.Drawing.Size(75, 23);
			this.btnDisconnect.TabIndex = 7;
			this.btnDisconnect.Text = "Logout";
			this.btnDisconnect.UseVisualStyleBackColor = true;
			this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
			// 
			// btnConnect
			// 
			this.btnConnect.Location = new System.Drawing.Point(84, 96);
			this.btnConnect.Name = "btnConnect";
			this.btnConnect.Size = new System.Drawing.Size(75, 23);
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
            "mypurecloud.com",
            "mypurecloud.com.au",
            "mypurecloud.de",
            "mypurecloud.ie",
            "mypurecloud.jp"});
			this.cmbEnvironment.Location = new System.Drawing.Point(84, 17);
			this.cmbEnvironment.Name = "cmbEnvironment";
			this.cmbEnvironment.Size = new System.Drawing.Size(220, 21);
			this.cmbEnvironment.TabIndex = 5;
			// 
			// lblEnvironment
			// 
			this.lblEnvironment.AutoSize = true;
			this.lblEnvironment.Location = new System.Drawing.Point(9, 20);
			this.lblEnvironment.Name = "lblEnvironment";
			this.lblEnvironment.Size = new System.Drawing.Size(69, 13);
			this.lblEnvironment.TabIndex = 4;
			this.lblEnvironment.Text = "Environment:";
			// 
			// txtClientSecret
			// 
			this.txtClientSecret.Location = new System.Drawing.Point(84, 70);
			this.txtClientSecret.Name = "txtClientSecret";
			this.txtClientSecret.PasswordChar = '*';
			this.txtClientSecret.Size = new System.Drawing.Size(220, 20);
			this.txtClientSecret.TabIndex = 3;
			// 
			// lblClientSecret
			// 
			this.lblClientSecret.AutoSize = true;
			this.lblClientSecret.Location = new System.Drawing.Point(8, 73);
			this.lblClientSecret.Name = "lblClientSecret";
			this.lblClientSecret.Size = new System.Drawing.Size(70, 13);
			this.lblClientSecret.TabIndex = 2;
			this.lblClientSecret.Text = "Client Secret:";
			// 
			// txtClientId
			// 
			this.txtClientId.Location = new System.Drawing.Point(84, 44);
			this.txtClientId.Name = "txtClientId";
			this.txtClientId.Size = new System.Drawing.Size(220, 20);
			this.txtClientId.TabIndex = 1;
			// 
			// lblClientId
			// 
			this.lblClientId.AutoSize = true;
			this.lblClientId.Location = new System.Drawing.Point(30, 47);
			this.lblClientId.Name = "lblClientId";
			this.lblClientId.Size = new System.Drawing.Size(48, 13);
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
			this.gbEdges.Location = new System.Drawing.Point(0, 134);
			this.gbEdges.Name = "gbEdges";
			this.gbEdges.Size = new System.Drawing.Size(413, 106);
			this.gbEdges.TabIndex = 1;
			this.gbEdges.TabStop = false;
			this.gbEdges.Text = "PureCloud Edges";
			// 
			// lblInstructions
			// 
			this.lblInstructions.AutoSize = true;
			this.lblInstructions.Location = new System.Drawing.Point(81, 73);
			this.lblInstructions.MaximumSize = new System.Drawing.Size(300, 0);
			this.lblInstructions.Name = "lblInstructions";
			this.lblInstructions.Size = new System.Drawing.Size(282, 26);
			this.lblInstructions.TabIndex = 8;
			this.lblInstructions.Text = "What is a Ghost Call? Active call on an offline edge. If the edge is not offline," +
    " call is not considered a Ghost Call.";
			// 
			// btnDisconnectGhostCalls
			// 
			this.btnDisconnectGhostCalls.Location = new System.Drawing.Point(183, 47);
			this.btnDisconnectGhostCalls.Name = "btnDisconnectGhostCalls";
			this.btnDisconnectGhostCalls.Size = new System.Drawing.Size(130, 23);
			this.btnDisconnectGhostCalls.TabIndex = 7;
			this.btnDisconnectGhostCalls.Text = "Disconnect Ghost Calls";
			this.btnDisconnectGhostCalls.UseVisualStyleBackColor = true;
			this.btnDisconnectGhostCalls.Click += new System.EventHandler(this.btnDisconnectGhostCalls_Click);
			// 
			// btnRefreshEdges
			// 
			this.btnRefreshEdges.Location = new System.Drawing.Point(319, 18);
			this.btnRefreshEdges.Name = "btnRefreshEdges";
			this.btnRefreshEdges.Size = new System.Drawing.Size(89, 23);
			this.btnRefreshEdges.TabIndex = 6;
			this.btnRefreshEdges.Text = "Refresh Edges";
			this.btnRefreshEdges.UseVisualStyleBackColor = true;
			this.btnRefreshEdges.Click += new System.EventHandler(this.btnRefreshEdges_Click);
			// 
			// btnDisconnectAllCalls
			// 
			this.btnDisconnectAllCalls.Location = new System.Drawing.Point(84, 47);
			this.btnDisconnectAllCalls.Name = "btnDisconnectAllCalls";
			this.btnDisconnectAllCalls.Size = new System.Drawing.Size(93, 23);
			this.btnDisconnectAllCalls.TabIndex = 2;
			this.btnDisconnectAllCalls.Text = "Find Ghost Calls";
			this.btnDisconnectAllCalls.UseVisualStyleBackColor = true;
			this.btnDisconnectAllCalls.Click += new System.EventHandler(this.btnDisconnectAllCalls_Click);
			// 
			// cmbEdges
			// 
			this.cmbEdges.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbEdges.FormattingEnabled = true;
			this.cmbEdges.Location = new System.Drawing.Point(84, 20);
			this.cmbEdges.Name = "cmbEdges";
			this.cmbEdges.Size = new System.Drawing.Size(229, 21);
			this.cmbEdges.TabIndex = 1;
			this.cmbEdges.SelectedIndexChanged += new System.EventHandler(this.cmbEdges_SelectedIndexChanged);
			// 
			// lblEdges
			// 
			this.lblEdges.AutoSize = true;
			this.lblEdges.Location = new System.Drawing.Point(38, 23);
			this.lblEdges.Name = "lblEdges";
			this.lblEdges.Size = new System.Drawing.Size(40, 13);
			this.lblEdges.TabIndex = 0;
			this.lblEdges.Text = "Edges:";
			// 
			// lstLog
			// 
			this.lstLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lstLog.FormattingEnabled = true;
			this.lstLog.Location = new System.Drawing.Point(2, 350);
			this.lstLog.Name = "lstLog";
			this.lstLog.Size = new System.Drawing.Size(903, 264);
			this.lstLog.TabIndex = 2;
			this.lstLog.DoubleClick += new System.EventHandler(this.lstLog_DoubleClick);
			// 
			// btnClearLog
			// 
			this.btnClearLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnClearLog.Location = new System.Drawing.Point(825, 326);
			this.btnClearLog.Name = "btnClearLog";
			this.btnClearLog.Size = new System.Drawing.Size(81, 23);
			this.btnClearLog.TabIndex = 3;
			this.btnClearLog.Text = "Clear Log";
			this.btnClearLog.UseVisualStyleBackColor = true;
			this.btnClearLog.Click += new System.EventHandler(this.btnClearLog_Click);
			// 
			// lblConversationId
			// 
			this.lblConversationId.AutoSize = true;
			this.lblConversationId.Location = new System.Drawing.Point(6, 23);
			this.lblConversationId.Name = "lblConversationId";
			this.lblConversationId.Size = new System.Drawing.Size(84, 13);
			this.lblConversationId.TabIndex = 3;
			this.lblConversationId.Text = "Conversation Id:";
			// 
			// txtConversationId
			// 
			this.txtConversationId.Location = new System.Drawing.Point(96, 20);
			this.txtConversationId.Name = "txtConversationId";
			this.txtConversationId.Size = new System.Drawing.Size(265, 20);
			this.txtConversationId.TabIndex = 4;
			this.txtConversationId.TextChanged += new System.EventHandler(this.txtConversationId_TextChanged);
			// 
			// btnGetConversationDetails
			// 
			this.btnGetConversationDetails.Location = new System.Drawing.Point(96, 46);
			this.btnGetConversationDetails.Name = "btnGetConversationDetails";
			this.btnGetConversationDetails.Size = new System.Drawing.Size(73, 23);
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
			this.gbTroubleshooting.Location = new System.Drawing.Point(419, 134);
			this.gbTroubleshooting.Name = "gbTroubleshooting";
			this.gbTroubleshooting.Size = new System.Drawing.Size(486, 82);
			this.gbTroubleshooting.TabIndex = 4;
			this.gbTroubleshooting.TabStop = false;
			this.gbTroubleshooting.Text = "Troubleshooting";
			// 
			// btnDisconnectConversation
			// 
			this.btnDisconnectConversation.Location = new System.Drawing.Point(271, 46);
			this.btnDisconnectConversation.Name = "btnDisconnectConversation";
			this.btnDisconnectConversation.Size = new System.Drawing.Size(90, 23);
			this.btnDisconnectConversation.TabIndex = 8;
			this.btnDisconnectConversation.Text = "Disconnect";
			this.btnDisconnectConversation.UseVisualStyleBackColor = true;
			this.btnDisconnectConversation.Click += new System.EventHandler(this.btnDisconnectConversation_Click);
			// 
			// linkConversation
			// 
			this.linkConversation.AutoSize = true;
			this.linkConversation.Location = new System.Drawing.Point(367, 23);
			this.linkConversation.Name = "linkConversation";
			this.linkConversation.Size = new System.Drawing.Size(105, 13);
			this.linkConversation.TabIndex = 7;
			this.linkConversation.TabStop = true;
			this.linkConversation.Text = "Monitor in PureCloud";
			this.linkConversation.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkConversation_LinkClicked);
			// 
			// lblAnalyticsEndDateTime
			// 
			this.lblAnalyticsEndDateTime.AutoSize = true;
			this.lblAnalyticsEndDateTime.Location = new System.Drawing.Point(61, 72);
			this.lblAnalyticsEndDateTime.Name = "lblAnalyticsEndDateTime";
			this.lblAnalyticsEndDateTime.Size = new System.Drawing.Size(29, 13);
			this.lblAnalyticsEndDateTime.TabIndex = 12;
			this.lblAnalyticsEndDateTime.Text = "End:";
			// 
			// lblAnalyticsStartDateTime
			// 
			this.lblAnalyticsStartDateTime.AutoSize = true;
			this.lblAnalyticsStartDateTime.Location = new System.Drawing.Point(58, 46);
			this.lblAnalyticsStartDateTime.Name = "lblAnalyticsStartDateTime";
			this.lblAnalyticsStartDateTime.Size = new System.Drawing.Size(32, 13);
			this.lblAnalyticsStartDateTime.TabIndex = 11;
			this.lblAnalyticsStartDateTime.Text = "Start:";
			// 
			// dtAnalyticsEnd
			// 
			this.dtAnalyticsEnd.CustomFormat = "yyyy-MM-dd HH:mm:ss";
			this.dtAnalyticsEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtAnalyticsEnd.Location = new System.Drawing.Point(96, 69);
			this.dtAnalyticsEnd.Name = "dtAnalyticsEnd";
			this.dtAnalyticsEnd.Size = new System.Drawing.Size(136, 20);
			this.dtAnalyticsEnd.TabIndex = 10;
			// 
			// dtAnalyticsStart
			// 
			this.dtAnalyticsStart.CustomFormat = "yyyy-MM-dd HH:mm:ss";
			this.dtAnalyticsStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtAnalyticsStart.Location = new System.Drawing.Point(96, 43);
			this.dtAnalyticsStart.Name = "dtAnalyticsStart";
			this.dtAnalyticsStart.Size = new System.Drawing.Size(136, 20);
			this.dtAnalyticsStart.TabIndex = 9;
			// 
			// btnTestPhantomCall
			// 
			this.btnTestPhantomCall.Location = new System.Drawing.Point(238, 54);
			this.btnTestPhantomCall.Name = "btnTestPhantomCall";
			this.btnTestPhantomCall.Size = new System.Drawing.Size(113, 23);
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
			this.gbAgents.Location = new System.Drawing.Point(0, 246);
			this.gbAgents.Name = "gbAgents";
			this.gbAgents.Size = new System.Drawing.Size(413, 74);
			this.gbAgents.TabIndex = 5;
			this.gbAgents.TabStop = false;
			this.gbAgents.Text = "Agents (refresh every 5 sec.)";
			// 
			// lblLoggedInAgentsValue
			// 
			this.lblLoggedInAgentsValue.AutoSize = true;
			this.lblLoggedInAgentsValue.Location = new System.Drawing.Point(103, 21);
			this.lblLoggedInAgentsValue.Name = "lblLoggedInAgentsValue";
			this.lblLoggedInAgentsValue.Size = new System.Drawing.Size(27, 13);
			this.lblLoggedInAgentsValue.TabIndex = 3;
			this.lblLoggedInAgentsValue.Text = "N/A";
			// 
			// lblLoggedInAgents
			// 
			this.lblLoggedInAgents.AutoSize = true;
			this.lblLoggedInAgents.Location = new System.Drawing.Point(39, 21);
			this.lblLoggedInAgents.Name = "lblLoggedInAgents";
			this.lblLoggedInAgents.Size = new System.Drawing.Size(58, 13);
			this.lblLoggedInAgents.TabIndex = 2;
			this.lblLoggedInAgents.Text = "Logged In:";
			// 
			// lblNotRespondingAgentsValue
			// 
			this.lblNotRespondingAgentsValue.AutoSize = true;
			this.lblNotRespondingAgentsValue.Location = new System.Drawing.Point(103, 41);
			this.lblNotRespondingAgentsValue.Name = "lblNotRespondingAgentsValue";
			this.lblNotRespondingAgentsValue.Size = new System.Drawing.Size(27, 13);
			this.lblNotRespondingAgentsValue.TabIndex = 1;
			this.lblNotRespondingAgentsValue.Text = "N/A";
			// 
			// lblNotRespondingAgents
			// 
			this.lblNotRespondingAgents.AutoSize = true;
			this.lblNotRespondingAgents.Location = new System.Drawing.Point(10, 41);
			this.lblNotRespondingAgents.Name = "lblNotRespondingAgents";
			this.lblNotRespondingAgents.Size = new System.Drawing.Size(87, 13);
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
			this.gbTestPhantomCall.Location = new System.Drawing.Point(419, 223);
			this.gbTestPhantomCall.Name = "gbTestPhantomCall";
			this.gbTestPhantomCall.Size = new System.Drawing.Size(487, 97);
			this.gbTestPhantomCall.TabIndex = 13;
			this.gbTestPhantomCall.TabStop = false;
			this.gbTestPhantomCall.Text = "Ghost Call Test";
			// 
			// linkConversation2
			// 
			this.linkConversation2.AutoSize = true;
			this.linkConversation2.Location = new System.Drawing.Point(367, 20);
			this.linkConversation2.Name = "linkConversation2";
			this.linkConversation2.Size = new System.Drawing.Size(105, 13);
			this.linkConversation2.TabIndex = 13;
			this.linkConversation2.TabStop = true;
			this.linkConversation2.Text = "Monitor in PureCloud";
			this.linkConversation2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkConversation2_LinkClicked);
			// 
			// txtAnalyticsConversationId
			// 
			this.txtAnalyticsConversationId.Location = new System.Drawing.Point(96, 17);
			this.txtAnalyticsConversationId.Name = "txtAnalyticsConversationId";
			this.txtAnalyticsConversationId.Size = new System.Drawing.Size(265, 20);
			this.txtAnalyticsConversationId.TabIndex = 9;
			this.txtAnalyticsConversationId.TextChanged += new System.EventHandler(this.txtAnalyticsConversationId_TextChanged);
			// 
			// lblAnalyticsConversationId
			// 
			this.lblAnalyticsConversationId.AutoSize = true;
			this.lblAnalyticsConversationId.Location = new System.Drawing.Point(6, 20);
			this.lblAnalyticsConversationId.Name = "lblAnalyticsConversationId";
			this.lblAnalyticsConversationId.Size = new System.Drawing.Size(84, 13);
			this.lblAnalyticsConversationId.TabIndex = 9;
			this.lblAnalyticsConversationId.Text = "Conversation Id:";
			// 
			// btnSaveLog
			// 
			this.btnSaveLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSaveLog.Location = new System.Drawing.Point(738, 326);
			this.btnSaveLog.Name = "btnSaveLog";
			this.btnSaveLog.Size = new System.Drawing.Size(81, 23);
			this.btnSaveLog.TabIndex = 14;
			this.btnSaveLog.Text = "Save Log";
			this.btnSaveLog.UseVisualStyleBackColor = true;
			this.btnSaveLog.Click += new System.EventHandler(this.btnSaveLog_Click);
			// 
			// chkVerboseLogging
			// 
			this.chkVerboseLogging.AutoSize = true;
			this.chkVerboseLogging.Location = new System.Drawing.Point(626, 330);
			this.chkVerboseLogging.Name = "chkVerboseLogging";
			this.chkVerboseLogging.Size = new System.Drawing.Size(106, 17);
			this.chkVerboseLogging.TabIndex = 15;
			this.chkVerboseLogging.Text = "Verbose Logging";
			this.chkVerboseLogging.UseVisualStyleBackColor = true;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(906, 621);
			this.Controls.Add(this.chkVerboseLogging);
			this.Controls.Add(this.btnSaveLog);
			this.Controls.Add(this.gbAgents);
			this.Controls.Add(this.gbTestPhantomCall);
			this.Controls.Add(this.gbTroubleshooting);
			this.Controls.Add(this.btnClearLog);
			this.Controls.Add(this.lstLog);
			this.Controls.Add(this.gbEdges);
			this.Controls.Add(this.groupBox1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
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
			this.ResumeLayout(false);
			this.PerformLayout();

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
		private System.Windows.Forms.Button btnSaveLog;
		private System.Windows.Forms.CheckBox chkVerboseLogging;
	}
}


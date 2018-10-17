namespace DisconnectCalls
{
	partial class DisplayConversation
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
			this.txtConversation = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// txtConversation
			// 
			this.txtConversation.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtConversation.Location = new System.Drawing.Point(0, 0);
			this.txtConversation.Multiline = true;
			this.txtConversation.Name = "txtConversation";
			this.txtConversation.ReadOnly = true;
			this.txtConversation.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtConversation.Size = new System.Drawing.Size(629, 513);
			this.txtConversation.TabIndex = 0;
			// 
			// DisplayConversation
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(629, 513);
			this.Controls.Add(this.txtConversation);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "DisplayConversation";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Conversation";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txtConversation;
	}
}
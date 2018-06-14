namespace LookAlive
{
	partial class FrmLookAlive
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLookAlive));
			this.txtTargetName = new System.Windows.Forms.TextBox();
			this.lblEnterName = new System.Windows.Forms.Label();
			this.btnLookAlive = new System.Windows.Forms.Button();
			this.monitorIcon = new System.Windows.Forms.NotifyIcon(this.components);
			this.monitorContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.responseTimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.changeTargetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.label1 = new System.Windows.Forms.Label();
			this.txtPingPeriod = new System.Windows.Forms.TextBox();
			this.btnHelp = new System.Windows.Forms.Button();
			this.checkNotify = new System.Windows.Forms.CheckBox();
			this.monitorContextMenu.SuspendLayout();
			this.SuspendLayout();
			// 
			// txtTargetName
			// 
			this.txtTargetName.Location = new System.Drawing.Point(12, 25);
			this.txtTargetName.Name = "txtTargetName";
			this.txtTargetName.Size = new System.Drawing.Size(203, 21);
			this.txtTargetName.TabIndex = 0;
			this.txtTargetName.TextChanged += new System.EventHandler(this.txtTargetName_TextChanged);
			// 
			// lblEnterName
			// 
			this.lblEnterName.AutoSize = true;
			this.lblEnterName.BackColor = System.Drawing.Color.Transparent;
			this.lblEnterName.Location = new System.Drawing.Point(13, 8);
			this.lblEnterName.Name = "lblEnterName";
			this.lblEnterName.Size = new System.Drawing.Size(200, 13);
			this.lblEnterName.TabIndex = 1;
			this.lblEnterName.Text = "Enter hostname / IP address to monitor:";
			this.lblEnterName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// btnLookAlive
			// 
			this.btnLookAlive.Enabled = false;
			this.btnLookAlive.Location = new System.Drawing.Point(12, 100);
			this.btnLookAlive.Name = "btnLookAlive";
			this.btnLookAlive.Size = new System.Drawing.Size(173, 23);
			this.btnLookAlive.TabIndex = 1;
			this.btnLookAlive.Text = "Look Alive";
			this.btnLookAlive.UseVisualStyleBackColor = true;
			this.btnLookAlive.Click += new System.EventHandler(this.btnLookAlive_Click);
			// 
			// monitorIcon
			// 
			this.monitorIcon.ContextMenuStrip = this.monitorContextMenu;
			this.monitorIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("monitorIcon.Icon")));
			this.monitorIcon.Text = "Look Alive";
			this.monitorIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.monitorIcon_MouseClick);
			// 
			// monitorContextMenu
			// 
			this.monitorContextMenu.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.monitorContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.responseTimeToolStripMenuItem,
            this.toolStripSeparator1,
            this.changeTargetToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.exitToolStripMenuItem});
			this.monitorContextMenu.Name = "monitorContextMenu";
			this.monitorContextMenu.Size = new System.Drawing.Size(172, 98);
			// 
			// responseTimeToolStripMenuItem
			// 
			this.responseTimeToolStripMenuItem.Name = "responseTimeToolStripMenuItem";
			this.responseTimeToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
			this.responseTimeToolStripMenuItem.Text = "&Response times...";
			this.responseTimeToolStripMenuItem.Click += new System.EventHandler(this.responseTimeToolStripMenuItem_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(168, 6);
			// 
			// changeTargetToolStripMenuItem
			// 
			this.changeTargetToolStripMenuItem.Name = "changeTargetToolStripMenuItem";
			this.changeTargetToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
			this.changeTargetToolStripMenuItem.Text = "&Change target...";
			this.changeTargetToolStripMenuItem.Click += new System.EventHandler(this.changeTargetToolStripMenuItem_Click);
			// 
			// aboutToolStripMenuItem
			// 
			this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			this.aboutToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
			this.aboutToolStripMenuItem.Text = "&About";
			this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
			this.exitToolStripMenuItem.Text = "E&xit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.Location = new System.Drawing.Point(14, 54);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(164, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = "Period between pings (seconds):";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// txtPingPeriod
			// 
			this.txtPingPeriod.Location = new System.Drawing.Point(178, 51);
			this.txtPingPeriod.Name = "txtPingPeriod";
			this.txtPingPeriod.Size = new System.Drawing.Size(37, 21);
			this.txtPingPeriod.TabIndex = 2;
			this.txtPingPeriod.Text = "1";
			// 
			// btnHelp
			// 
			this.btnHelp.Image = global::LookAlive.Properties.Resources.help;
			this.btnHelp.Location = new System.Drawing.Point(191, 100);
			this.btnHelp.Name = "btnHelp";
			this.btnHelp.Size = new System.Drawing.Size(24, 23);
			this.btnHelp.TabIndex = 4;
			this.btnHelp.UseVisualStyleBackColor = true;
			this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
			// 
			// notificationCheck
			// 
			this.checkNotify.AutoSize = true;
			this.checkNotify.BackgroundImage = global::LookAlive.Properties.Resources.background;
			this.checkNotify.Checked = true;
			this.checkNotify.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkNotify.Location = new System.Drawing.Point(16, 76);
			this.checkNotify.Name = "notificationCheck";
			this.checkNotify.Size = new System.Drawing.Size(206, 17);
			this.checkNotify.TabIndex = 5;
			this.checkNotify.Text = "Notifiy when host availability changes";
			this.checkNotify.UseVisualStyleBackColor = true;
			// 
			// FrmLookAlive
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImage = global::LookAlive.Properties.Resources.background;
			this.ClientSize = new System.Drawing.Size(227, 135);
			this.Controls.Add(this.checkNotify);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtPingPeriod);
			this.Controls.Add(this.lblEnterName);
			this.Controls.Add(this.btnHelp);
			this.Controls.Add(this.btnLookAlive);
			this.Controls.Add(this.txtTargetName);
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FrmLookAlive";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Look Alive";
			this.Load += new System.EventHandler(this.FrmLookAlive_Load);
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmLookAlive_FormClosing);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmLookAlive_KeyDown);
			this.monitorContextMenu.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txtTargetName;
		private System.Windows.Forms.Label lblEnterName;
		private System.Windows.Forms.Button btnLookAlive;
		private System.Windows.Forms.NotifyIcon monitorIcon;
		private System.Windows.Forms.ContextMenuStrip monitorContextMenu;
		private System.Windows.Forms.ToolStripMenuItem changeTargetToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem responseTimeToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPingPeriod;
		private System.Windows.Forms.Button btnHelp;
		private System.Windows.Forms.CheckBox checkNotify;
	}
}


namespace LookAlive
{
	partial class FrmAbout
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAbout));
			this.btnOK = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.linkLabel1 = new System.Windows.Forms.LinkLabel();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.helpText = new System.Windows.Forms.RichTextBox();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// btnOK
			// 
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnOK.Location = new System.Drawing.Point(498, 197);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 23);
			this.btnOK.TabIndex = 0;
			this.btnOK.Text = "&OK";
			this.btnOK.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(12, 10);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(114, 16);
			this.label1.TabIndex = 1;
			this.label1.Text = "Look Alive v1.24";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.BackColor = System.Drawing.Color.Transparent;
			this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(480, 159);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(94, 13);
			this.label4.TabIndex = 1;
			this.label4.Text = "Copyright © 2010";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.textBox2);
			this.groupBox1.Controls.Add(this.textBox1);
			this.groupBox1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox1.Location = new System.Drawing.Point(12, 336);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(561, 112);
			this.groupBox1.TabIndex = 3;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Example";
			// 
			// textBox2
			// 
			this.textBox2.BackColor = System.Drawing.Color.White;
			this.textBox2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBox2.Location = new System.Drawing.Point(13, 47);
			this.textBox2.Multiline = true;
			this.textBox2.Name = "textBox2";
			this.textBox2.ReadOnly = true;
			this.textBox2.Size = new System.Drawing.Size(534, 51);
			this.textBox2.TabIndex = 4;
			this.textBox2.Text = resources.GetString("textBox2.Text");
			// 
			// textBox1
			// 
			this.textBox1.BackColor = System.Drawing.Color.White;
			this.textBox1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBox1.Location = new System.Drawing.Point(13, 20);
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.Size = new System.Drawing.Size(534, 21);
			this.textBox1.TabIndex = 3;
			this.textBox1.Text = "LookAlive.exe www.google.com 5 yellow \"{!cmd,/c echo {time} {state} >> c:\\temp\\lo" +
				"g_{hostname_ip}.txt}\"";
			// 
			// linkLabel1
			// 
			this.linkLabel1.AutoSize = true;
			this.linkLabel1.Location = new System.Drawing.Point(497, 174);
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.Size = new System.Drawing.Size(76, 13);
			this.linkLabel1.TabIndex = 4;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Tag = "http://zornsoftware.talsit.info/?page_id=37&did=3";
			this.linkLabel1.Text = "Zorn Software";
			this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pictureBox1.Image = global::LookAlive.Properties.Resources.about_icon;
			this.pictureBox1.Location = new System.Drawing.Point(459, 34);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(114, 114);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pictureBox1.TabIndex = 5;
			this.pictureBox1.TabStop = false;
			// 
			// helpText
			// 
			this.helpText.AcceptsTab = true;
			this.helpText.BackColor = System.Drawing.Color.White;
			this.helpText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.helpText.Location = new System.Drawing.Point(12, 34);
			this.helpText.Name = "helpText";
			this.helpText.ReadOnly = true;
			this.helpText.Size = new System.Drawing.Size(435, 296);
			this.helpText.TabIndex = 6;
			this.helpText.Text = "";
			// 
			// FrmAbout
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnOK;
			this.ClientSize = new System.Drawing.Size(585, 459);
			this.Controls.Add(this.helpText);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.linkLabel1);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnOK);
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FrmAbout";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "About Look Alive";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.LinkLabel linkLabel1;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.RichTextBox helpText;
	}
}
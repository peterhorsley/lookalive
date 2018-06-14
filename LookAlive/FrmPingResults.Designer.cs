namespace LookAlive
{
	partial class FrmPingResults
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPingResults));
			this.txtResults = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// txtResults
			// 
			this.txtResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtResults.BackColor = System.Drawing.Color.Black;
			this.txtResults.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtResults.Cursor = System.Windows.Forms.Cursors.Arrow;
			this.txtResults.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtResults.ForeColor = System.Drawing.Color.Lime;
			this.txtResults.Location = new System.Drawing.Point(12, 12);
			this.txtResults.Multiline = true;
			this.txtResults.Name = "txtResults";
			this.txtResults.ReadOnly = true;
			this.txtResults.Size = new System.Drawing.Size(252, 708);
			this.txtResults.TabIndex = 0;
			// 
			// FrmPingResults
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Yellow;
			this.ClientSize = new System.Drawing.Size(276, 732);
			this.Controls.Add(this.txtResults);
			this.DoubleBuffered = true;
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ForeColor = System.Drawing.Color.White;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Location = new System.Drawing.Point(100, 100);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FrmPingResults";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Ping Results";
			this.TransparencyKey = System.Drawing.Color.Yellow;
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmPingResults_FormClosing);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txtResults;
	}
}
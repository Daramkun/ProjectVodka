namespace ProjectVodka
{
	partial class BrushEdit
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose ( bool disposing )
		{
			if ( disposing && ( components != null ) )
			{
				components.Dispose ();
			}
			base.Dispose ( disposing );
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent ()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.trkBrushSize = new System.Windows.Forms.TrackBar();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.lblColorPreview = new System.Windows.Forms.Label();
			this.numBlue = new System.Windows.Forms.NumericUpDown();
			this.numGreen = new System.Windows.Forms.NumericUpDown();
			this.numRed = new System.Windows.Forms.NumericUpDown();
			this.numAlpha = new System.Windows.Forms.NumericUpDown();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.chkDynamicColor = new System.Windows.Forms.CheckBox();
			this.chkDynamicSize = new System.Windows.Forms.CheckBox();
			((System.ComponentModel.ISupportInitialize)(this.trkBrushSize)).BeginInit();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numBlue)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numGreen)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numRed)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numAlpha)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 23);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(69, 12);
			this.label1.TabIndex = 0;
			this.label1.Text = "브러시 크기";
			// 
			// trkBrushSize
			// 
			this.trkBrushSize.Location = new System.Drawing.Point(87, 12);
			this.trkBrushSize.Maximum = 16;
			this.trkBrushSize.Minimum = 1;
			this.trkBrushSize.Name = "trkBrushSize";
			this.trkBrushSize.Size = new System.Drawing.Size(111, 45);
			this.trkBrushSize.TabIndex = 1;
			this.trkBrushSize.Value = 1;
			this.trkBrushSize.Scroll += new System.EventHandler(this.trkBrushSize_Scroll);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.lblColorPreview);
			this.groupBox1.Controls.Add(this.numBlue);
			this.groupBox1.Controls.Add(this.numGreen);
			this.groupBox1.Controls.Add(this.numRed);
			this.groupBox1.Controls.Add(this.numAlpha);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Location = new System.Drawing.Point(12, 63);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(186, 178);
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "브러시 색상";
			// 
			// lblColorPreview
			// 
			this.lblColorPreview.BackColor = System.Drawing.Color.Black;
			this.lblColorPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblColorPreview.ForeColor = System.Drawing.Color.White;
			this.lblColorPreview.Location = new System.Drawing.Point(18, 141);
			this.lblColorPreview.Name = "lblColorPreview";
			this.lblColorPreview.Size = new System.Drawing.Size(156, 22);
			this.lblColorPreview.TabIndex = 8;
			this.lblColorPreview.Text = "색상 미리보기";
			this.lblColorPreview.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.lblColorPreview.BackColorChanged += new System.EventHandler(this.lblColorPreview_BackColorChanged);
			// 
			// numBlue
			// 
			this.numBlue.Location = new System.Drawing.Point(51, 109);
			this.numBlue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
			this.numBlue.Name = "numBlue";
			this.numBlue.Size = new System.Drawing.Size(123, 21);
			this.numBlue.TabIndex = 7;
			this.numBlue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.numBlue.ValueChanged += new System.EventHandler(this.numAlpha_ValueChanged);
			// 
			// numGreen
			// 
			this.numGreen.Location = new System.Drawing.Point(51, 82);
			this.numGreen.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
			this.numGreen.Name = "numGreen";
			this.numGreen.Size = new System.Drawing.Size(123, 21);
			this.numGreen.TabIndex = 6;
			this.numGreen.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.numGreen.ValueChanged += new System.EventHandler(this.numAlpha_ValueChanged);
			// 
			// numRed
			// 
			this.numRed.Location = new System.Drawing.Point(51, 55);
			this.numRed.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
			this.numRed.Name = "numRed";
			this.numRed.Size = new System.Drawing.Size(123, 21);
			this.numRed.TabIndex = 5;
			this.numRed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.numRed.ValueChanged += new System.EventHandler(this.numAlpha_ValueChanged);
			// 
			// numAlpha
			// 
			this.numAlpha.Location = new System.Drawing.Point(51, 28);
			this.numAlpha.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
			this.numAlpha.Name = "numAlpha";
			this.numAlpha.Size = new System.Drawing.Size(123, 21);
			this.numAlpha.TabIndex = 4;
			this.numAlpha.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.numAlpha.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
			this.numAlpha.ValueChanged += new System.EventHandler(this.numAlpha_ValueChanged);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(16, 111);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(29, 12);
			this.label5.TabIndex = 3;
			this.label5.Text = "파랑";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(16, 84);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(29, 12);
			this.label4.TabIndex = 2;
			this.label4.Text = "초록";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(16, 57);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(29, 12);
			this.label3.TabIndex = 1;
			this.label3.Text = "빨강";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(16, 30);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(29, 12);
			this.label2.TabIndex = 0;
			this.label2.Text = "알파";
			// 
			// chkDynamicColor
			// 
			this.chkDynamicColor.AutoSize = true;
			this.chkDynamicColor.Checked = true;
			this.chkDynamicColor.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkDynamicColor.Location = new System.Drawing.Point(14, 257);
			this.chkDynamicColor.Name = "chkDynamicColor";
			this.chkDynamicColor.Size = new System.Drawing.Size(172, 16);
			this.chkDynamicColor.TabIndex = 3;
			this.chkDynamicColor.Text = "필압에 따라 색상 농도 변화";
			this.chkDynamicColor.UseVisualStyleBackColor = true;
			this.chkDynamicColor.CheckedChanged += new System.EventHandler(this.chkDynamicColor_CheckedChanged);
			// 
			// chkDynamicSize
			// 
			this.chkDynamicSize.AutoSize = true;
			this.chkDynamicSize.Checked = true;
			this.chkDynamicSize.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkDynamicSize.Location = new System.Drawing.Point(14, 288);
			this.chkDynamicSize.Name = "chkDynamicSize";
			this.chkDynamicSize.Size = new System.Drawing.Size(184, 16);
			this.chkDynamicSize.TabIndex = 4;
			this.chkDynamicSize.Text = "필압에 따라 브러시 크기 변화";
			this.chkDynamicSize.UseVisualStyleBackColor = true;
			this.chkDynamicSize.CheckedChanged += new System.EventHandler(this.chkDynamicSize_CheckedChanged);
			// 
			// BrushEdit
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(210, 322);
			this.Controls.Add(this.chkDynamicSize);
			this.Controls.Add(this.chkDynamicColor);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.trkBrushSize);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "BrushEdit";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.Text = "브러시 편집";
			this.Load += new System.EventHandler(this.BrushEdit_Load);
			((System.ComponentModel.ISupportInitialize)(this.trkBrushSize)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numBlue)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numGreen)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numRed)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numAlpha)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TrackBar trkBrushSize;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.NumericUpDown numBlue;
		private System.Windows.Forms.NumericUpDown numGreen;
		private System.Windows.Forms.NumericUpDown numRed;
		private System.Windows.Forms.NumericUpDown numAlpha;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label lblColorPreview;
		private System.Windows.Forms.CheckBox chkDynamicColor;
		private System.Windows.Forms.CheckBox chkDynamicSize;
	}
}
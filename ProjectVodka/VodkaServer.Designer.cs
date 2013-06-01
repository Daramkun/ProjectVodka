namespace ProjectVodka
{
	partial class VodkaServer
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
			this.label2 = new System.Windows.Forms.Label();
			this.cmbIp = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.lstConnected = new System.Windows.Forms.ListBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btnStart = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.numWidth = new System.Windows.Forms.NumericUpDown();
			this.numHeight = new System.Windows.Forms.NumericUpDown();
			this.label6 = new System.Windows.Forms.Label();
			this.txtPassword = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numWidth)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numHeight)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("맑은 고딕", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.label1.Location = new System.Drawing.Point(12, 28);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(221, 32);
			this.label1.TabIndex = 0;
			this.label1.Text = "Vodka Server v1.0";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.label2.Location = new System.Drawing.Point(125, 59);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(103, 15);
			this.label2.TabIndex = 1;
			this.label2.Text = "Daramkun\'s NEST";
			// 
			// cmbIp
			// 
			this.cmbIp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbIp.Font = new System.Drawing.Font("맑은 고딕", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.cmbIp.FormattingEnabled = true;
			this.cmbIp.Items.AddRange(new object[] {
            "== IP 주소 =="});
			this.cmbIp.Location = new System.Drawing.Point(18, 88);
			this.cmbIp.Name = "cmbIp";
			this.cmbIp.Size = new System.Drawing.Size(210, 21);
			this.cmbIp.TabIndex = 2;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("맑은 고딕", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.label3.Location = new System.Drawing.Point(15, 121);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(40, 13);
			this.label3.TabIndex = 3;
			this.label3.Text = "접속자";
			// 
			// lstConnected
			// 
			this.lstConnected.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.lstConnected.FormattingEnabled = true;
			this.lstConnected.ItemHeight = 15;
			this.lstConnected.Location = new System.Drawing.Point(18, 137);
			this.lstConnected.Name = "lstConnected";
			this.lstConnected.Size = new System.Drawing.Size(210, 79);
			this.lstConnected.TabIndex = 4;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label7);
			this.groupBox1.Controls.Add(this.txtPassword);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.numHeight);
			this.groupBox1.Controls.Add(this.numWidth);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Font = new System.Drawing.Font("맑은 고딕", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.groupBox1.Location = new System.Drawing.Point(239, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(226, 164);
			this.groupBox1.TabIndex = 5;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "서버 설정";
			// 
			// btnStart
			// 
			this.btnStart.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.btnStart.Location = new System.Drawing.Point(239, 182);
			this.btnStart.Name = "btnStart";
			this.btnStart.Size = new System.Drawing.Size(226, 34);
			this.btnStart.TabIndex = 6;
			this.btnStart.Text = "서버 시작";
			this.btnStart.UseVisualStyleBackColor = true;
			this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(18, 32);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(55, 13);
			this.label4.TabIndex = 0;
			this.label4.Text = "가로 크기";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(18, 62);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(55, 13);
			this.label5.TabIndex = 1;
			this.label5.Text = "세로 크기";
			// 
			// numWidth
			// 
			this.numWidth.Location = new System.Drawing.Point(79, 30);
			this.numWidth.Maximum = new decimal(new int[] {
            4096,
            0,
            0,
            0});
			this.numWidth.Minimum = new decimal(new int[] {
            256,
            0,
            0,
            0});
			this.numWidth.Name = "numWidth";
			this.numWidth.Size = new System.Drawing.Size(127, 22);
			this.numWidth.TabIndex = 2;
			this.numWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.numWidth.Value = new decimal(new int[] {
            640,
            0,
            0,
            0});
			// 
			// numHeight
			// 
			this.numHeight.Location = new System.Drawing.Point(79, 60);
			this.numHeight.Maximum = new decimal(new int[] {
            4096,
            0,
            0,
            0});
			this.numHeight.Minimum = new decimal(new int[] {
            256,
            0,
            0,
            0});
			this.numHeight.Name = "numHeight";
			this.numHeight.Size = new System.Drawing.Size(127, 22);
			this.numHeight.TabIndex = 3;
			this.numHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.numHeight.Value = new decimal(new int[] {
            480,
            0,
            0,
            0});
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(22, 115);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(51, 13);
			this.label6.TabIndex = 4;
			this.label6.Text = "패스워드";
			// 
			// txtPassword
			// 
			this.txtPassword.Location = new System.Drawing.Point(79, 112);
			this.txtPassword.Name = "txtPassword";
			this.txtPassword.Size = new System.Drawing.Size(127, 22);
			this.txtPassword.TabIndex = 5;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("맑은 고딕", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.label7.Location = new System.Drawing.Point(15, 137);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(200, 12);
			this.label7.TabIndex = 6;
			this.label7.Text = "패스워드를 설정하지 않으면 공개 서버가 됩니다";
			// 
			// VodkaServer
			// 
			this.AcceptButton = this.btnStart;
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(486, 233);
			this.Controls.Add(this.btnStart);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.lstConnected);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.cmbIp);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.Name = "VodkaServer";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Vodka Server";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numWidth)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numHeight)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox cmbIp;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ListBox lstConnected;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button btnStart;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.NumericUpDown numHeight;
		private System.Windows.Forms.NumericUpDown numWidth;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox txtPassword;
		private System.Windows.Forms.Label label7;
	}
}
namespace ProjectVodka
{
	partial class Vodka
	{
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 사용 중인 모든 리소스를 정리합니다.
		/// </summary>
		/// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
		protected override void Dispose ( bool disposing )
		{
			if ( disposing && ( components != null ) )
			{
				components.Dispose ();
			}
			base.Dispose ( disposing );
		}

		#region Windows Form 디자이너에서 생성한 코드

		/// <summary>
		/// 디자이너 지원에 필요한 메서드입니다.
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
		/// </summary>
		private void InitializeComponent ()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Vodka));
			this.ofdDialog = new System.Windows.Forms.OpenFileDialog();
			this.sfdDialog = new System.Windows.Forms.SaveFileDialog();
			this.SuspendLayout();
			// 
			// Vodka
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(502, 446);
			this.Cursor = System.Windows.Forms.Cursors.Cross;
			this.DoubleBuffered = true;
			this.HelpButton = true;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Vodka";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.Vodka_HelpButtonClicked);
			this.Activated += new System.EventHandler(this.Vodka_Activated);
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Vodka_FormClosing);
			this.ResizeEnd += new System.EventHandler(this.Vodka_ResizeEnd);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.Vodka_Paint);
			this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Vodka_KeyUp);
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Vodka_MouseDown);
			this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Vodka_MouseMove);
			this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Vodka_MouseUp);
			this.Resize += new System.EventHandler(this.Vodka_Resize);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.OpenFileDialog ofdDialog;
		private System.Windows.Forms.SaveFileDialog sfdDialog;

	}
}


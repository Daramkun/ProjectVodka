using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProjectVodka
{
	public partial class BrushEdit : Form
	{
		Vodka m_vodka;

		public BrushEdit ( Vodka vodka )
		{
			InitializeComponent ();

			m_vodka = vodka;

			trkBrushSize.Value = m_vodka.BrushSize;

			Color color = m_vodka.BrushColor;
			numAlpha.Value = color.A;
			numRed.Value = color.R;
			numGreen.Value = color.G;
			numBlue.Value = color.B;

			if ( m_vodka.Context == null )
			{
				chkDynamicColor.Enabled = chkDynamicSize.Enabled = false;
			}
			else
			{
				chkDynamicColor.Checked = m_vodka.IsDynamicColorAlpha;
				chkDynamicSize.Checked = m_vodka.IsDynamicBrushSize;
			}
		}

		private void BrushEdit_Load ( object sender, EventArgs e )
		{
			Left = m_vodka.Left + m_vodka.Width;
			Top = m_vodka.Top;
		}

		private void trkBrushSize_Scroll ( object sender, EventArgs e )
		{
			m_vodka.BrushSize = trkBrushSize.Value;
		}

		private void numAlpha_ValueChanged ( object sender, EventArgs e )
		{
			m_vodka.BrushColor = Color.FromArgb ( alpha: ( int ) numAlpha.Value,
				red: ( int ) numRed.Value, green: ( int ) numGreen.Value,
				blue: ( int ) numBlue.Value );
			lblColorPreview.BackColor = m_vodka.BrushColor;
		}

		private void lblColorPreview_BackColorChanged ( object sender, EventArgs e )
		{
			lblColorPreview.ForeColor = Color.FromArgb (
				alpha: 255 - lblColorPreview.BackColor.A,
				red: 255 - ( int ) lblColorPreview.BackColor.R,
				green: 255 - ( int ) lblColorPreview.BackColor.G,
				blue: 255 - ( int ) lblColorPreview.BackColor.B
				);
		}

		private void chkDynamicColor_CheckedChanged ( object sender, EventArgs e )
		{
			m_vodka.IsDynamicColorAlpha = chkDynamicColor.Checked;
		}

		private void chkDynamicSize_CheckedChanged ( object sender, EventArgs e )
		{
			m_vodka.IsDynamicBrushSize = chkDynamicSize.Checked;
		}
	}
}

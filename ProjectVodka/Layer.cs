using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;

namespace ProjectVodka
{
	/// <summary>
	/// 레이어
	/// </summary>
	[Serializable]
	public class Layer
	{
		Bitmap m_layerData;
		[NonSerialized]
		Graphics m_layerGraphics;
		bool m_isVisible;

		/// <summary>
		/// 레이어 비트맵
		/// </summary>
		public Bitmap Bitmap { get { return m_layerData; } }
		/// <summary>
		/// 레이어 비트맵 드로어
		/// </summary>
		public Graphics Graphics { get { return m_layerGraphics; } }
		/// <summary>
		/// 레이어가 화면에 보여지는 여부
		/// </summary>
		public bool IsVisible { get { return m_isVisible; } }

		public Layer ( int width, int height )
		{
			m_layerData = new Bitmap ( width, height );
			m_layerGraphics = Graphics.FromImage ( m_layerData );
			SetGraphicsOptions ( m_layerGraphics );
			m_isVisible = true;
		}

		public Layer ( Bitmap bitmap )
		{
			m_layerData = bitmap;
			m_layerGraphics = Graphics.FromImage ( m_layerData );
			SetGraphicsOptions ( m_layerGraphics );
			m_isVisible = true;
		}

		/// <summary>
		/// 레이어 크기 변경
		/// </summary>
		/// <param name="width">가로 크기</param>
		/// <param name="height">세로 크기</param>
		public void Resize ( int width, int height )
		{
			m_layerGraphics.Dispose ();
			Bitmap temp = new Bitmap ( width, height );
			m_layerGraphics = Graphics.FromImage ( temp );
			SetGraphicsOptions ( m_layerGraphics );

			m_layerGraphics.DrawImageUnscaled ( m_layerData, 0, 0 );

			m_layerData.Dispose ();
			m_layerData = temp;
		}

		/// <summary>
		/// 실행 직렬화로 인해 날아간 드로어 새로 생성
		/// </summary>
		public void RemakeGraphics ()
		{
			m_layerGraphics = Graphics.FromImage ( m_layerData );
			SetGraphicsOptions ( m_layerGraphics );
		}

		/// <summary>
		/// 드로어 설정
		/// </summary>
		/// <param name="g">GDI+ 그래픽스 드로어</param>
		private void SetGraphicsOptions ( Graphics g )
		{
			g.CompositingQuality = CompositingQuality.HighQuality;
			g.InterpolationMode = InterpolationMode.HighQualityBicubic;
			g.SmoothingMode = SmoothingMode.HighQuality;
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectVodka
{
	/// <summary>
	/// 실행 타입
	/// </summary>
	public enum DoType
	{
		/// <summary>
		/// 창 크기 변경
		/// </summary>
		SizeChange,
		/// <summary>
		/// 그리기
		/// </summary>
		Drawing,
	}

	/// <summary>
	/// 실행
	/// </summary>
	public class Do
	{
		DoType m_doType;
		byte [] m_doDatas;

		int m_sizeWidth, m_sizeHeight;

		/// <summary>
		/// 실행 타입
		/// </summary>
		public DoType DoType { get { return m_doType; } set { m_doType = value; } }
		/// <summary>
		/// 실행 데이터
		/// </summary>
		public byte [] DoDatas { get { return m_doDatas; } set { m_doDatas = value; } }
		/// <summary>
		/// 변경되기 전 가로 크기
		/// </summary>
		public int LastSizeChangedWidth { get { return m_sizeWidth; } set { m_sizeWidth = value; } }
		/// <summary>
		/// 변경되기 전 세로 크기
		/// </summary>
		public int LastSizeChangedHeight { get { return m_sizeHeight; } set { m_sizeHeight = value; } }

		public Do ( byte [] doDatas )
		{
			m_doType = DoType.Drawing;
			m_doDatas = doDatas;
		}

		public Do ( byte [] doDatas, int width, int height )
		{
			m_doType = DoType.SizeChange;
			m_doDatas = doDatas;
			m_sizeWidth = width; m_sizeHeight = height;
		}
	}
}

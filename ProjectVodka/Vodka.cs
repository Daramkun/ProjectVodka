using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Drawing.Imaging;
using ProjectVodka.Properties;

namespace ProjectVodka
{
	/// <summary>
	/// 보드카 매인 창
	/// </summary>
	public partial class Vodka : Form
	{
		#region Member Variables
		WinTabContext m_wintabContext;
		BrushEdit m_brushEdit;
		VodkaServer m_vodkaServer;

		#region Undo/Redo
		BinaryFormatter bf = new BinaryFormatter ();
		Stack<Do> m_undoStack = new Stack<Do> ();
		Stack<Do> m_redoStack = new Stack<Do> ();
		#endregion

		#region Layers
		List<Layer> m_layers = new List<Layer> ();
		int m_selectedLayer = 0;
		#endregion

		#region Brushes
		Color m_brushColor = Color.Black;
		float m_brushSize = 0.5f;
		bool m_hasBrushConsist = true, m_hasBrushDynamicSize = true;
		#endregion

		#region Mouse & Tablet
		int m_tabletPressure = 0, m_tabletMaxPressure = 1;
		Point m_lastMousePos;
		int m_lastTabletPressure;
		bool m_isEraser = false;
		bool m_isMouseDown = false;
		#endregion

		#region Save State
		bool m_isSaved = true;
		string m_savedPath = "";
		#endregion



		int m_currentWidth = 800, m_currentHeight = 600;
		bool m_checkLayer = false;

		#endregion

		#region Member Properties
		/// <summary>
		/// 레이어 목록
		/// </summary>
		public List<Layer> Layers { get { return m_layers; } }
		/// <summary>
		/// 편집중인 레이어
		/// </summary>
		public int SelectedLayer { get { return m_selectedLayer; } set { m_selectedLayer = value; } }

		/// <summary>
		/// 브러시 색상
		/// </summary>
		public Color BrushColor { get { return m_brushColor; } set { m_brushColor = value; } }
		/// <summary>
		/// 색상 필압 변화
		/// </summary>
		public bool IsDynamicColorAlpha { get { return m_hasBrushConsist; } set { m_hasBrushConsist = value; } }
		/// <summary>
		/// 크기 필압 변화
		/// </summary>
		public bool IsDynamicBrushSize { get { return m_hasBrushDynamicSize; } set { m_hasBrushDynamicSize = value; } }
		/// <summary>
		/// 기본 브러시 크기
		/// </summary>
		public int BrushSize { get { return ( int ) ( m_brushSize * 2 ); } set { m_brushSize = value / 2.0f; } }
		/// <summary>
		/// 현재 타블렛 필압
		/// </summary>
		public int TabletPressure { get { return m_tabletPressure; } }

		public WinTabContext Context { get { return m_wintabContext; } }
		#endregion

		#region Function Methods
		/// <summary>
		/// 새 레이어 추가
		/// </summary>
		public void AddNewLayer ()
		{
			AddUndoList ();
			m_layers.Add ( new Layer ( ClientSize.Width, ClientSize.Height ) );
			m_isSaved = false;
			RefreshTitle ();
		}

		/// <summary>
		/// 현재 활성화된 레이어 제거
		/// </summary>
		public void RemoveLayer ()
		{
			AddUndoList ();
			m_layers.RemoveAt ( m_selectedLayer );
			m_isSaved = false;
			RefreshTitle ();
		}

		/// <summary>
		/// 제목표시줄 새로고침
		/// </summary>
		private void RefreshTitle ()
		{
			Text = String.Format (
				"{0}[ 가로: {1}, 세로: {2} ] - [ {3}/{4} 레이어 편집 중 ] - Daramkun's NEST 프로젝트 보드카",
				( m_isSaved ) ? "" : "*",
				ClientSize.Width, ClientSize.Height, m_selectedLayer + 1, m_layers.Count );
		}

		/// <summary>
		/// 실행 취소 리스트에 현재 상태 저장
		/// </summary>
		private void AddUndoList ()
		{
			MemoryStream mem = new MemoryStream ();
			bf.Serialize ( mem, m_layers );
			m_undoStack.Push ( new Do ( mem.ToArray () ) );
			mem.Dispose ();
			m_isSaved = false;
		}

		/// <summary>
		/// 실행 취소
		/// </summary>
		private void RecoveryUndoList ()
		{
			if ( m_undoStack.Count == 0 ) return;
			AddRedoList ();
			MemoryStream mem = new MemoryStream ( m_undoStack.Peek ().DoDatas );
			m_layers = bf.Deserialize ( mem ) as List<Layer>;
			foreach ( Layer layer in m_layers )
				layer.RemakeGraphics ();
			mem.Dispose ();
			m_undoStack.Pop ();
		}

		/// <summary>
		/// 다시 실행 리스트에 현재 상태 저장
		/// </summary>
		private void AddRedoList ()
		{
			MemoryStream mem = new MemoryStream ();
			bf.Serialize ( mem, m_layers );
			m_redoStack.Push ( new Do ( mem.ToArray () ) );
			mem.Dispose ();
			m_isSaved = false;
		}

		/// <summary>
		/// 다시 실행
		/// </summary>
		private void RecoveryRedoList ()
		{
			if ( m_redoStack.Count == 0 ) return;
			AddUndoList ();
			MemoryStream mem = new MemoryStream ( m_redoStack.Peek ().DoDatas );
			m_layers = bf.Deserialize ( mem ) as List<Layer>;
			foreach ( Layer layer in m_layers )
				layer.RemakeGraphics ();
			mem.Dispose ();
			m_redoStack.Pop ();
		}

		/// <summary>
		/// 현재 선택된 레이어 번호 범위 교정
		/// </summary>
		private void LayerCorrection ()
		{
			if ( m_selectedLayer < 0 )
				m_selectedLayer = 0;
			if ( m_selectedLayer >= m_layers.Count )
				m_selectedLayer = m_layers.Count - 1;
		}

		/// <summary>
		/// 불러오기/저장하기 파일 형식 체크
		/// </summary>
		/// <param name="filename">체크할 파일 형식</param>
		/// <returns></returns>
		private bool CheckFileFormat ( string filename )
		{
			string [] temp = filename.Split ( '.' );
			switch ( temp [ temp.Length - 1 ].ToLower () )
			{
				case "jpg":
				case "jpeg":
				case "bmp":
				case "png":
				case "gif":
				case "tif":
				case "tiff":
					return false;
				case "vodka":
				case "vdk":
					return true;
				default:
					throw new Exception ( "잘못된 파일 형식입니다." );
			}
		}

		/// <summary>
		/// 저장 상태 확인
		/// </summary>
		/// <returns>저장 상태</returns>
		private bool CheckSaveState ()
		{
			if ( m_isSaved ) return true;
			else
			{
				switch ( MessageBox.Show ( "현재까지 작업한 데이터를 저장하시겠습니까?",
					"프로젝트 보드카", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question ) )
				{
					case DialogResult.Yes:
						return FileSave ();
					case DialogResult.No:
						return true;
					default:
						return false;
				}
			}
		}

		/// <summary>
		/// 편집중인 데이터 초기화
		/// </summary>
		/// <returns>초기화 성공 여부</returns>
		private bool NewFile ()
		{
			m_layers = new List<Layer> ();
			AddNewLayer ();
			ClientSize = new Size ( 800, 600 );
			m_selectedLayer = 0;
			m_isSaved = true;
			m_savedPath = "";

			return true;
		}

		/// <summary>
		/// 데이터 불러오기
		/// </summary>
		/// <param name="filename">불러올 파일 이름</param>
		/// <returns>불러오기 성공 여부</returns>
		private bool LoadFile ( string filename )
		{
			if ( CheckFileFormat ( filename ) )
			{
				using ( FileStream fs = new FileStream ( filename, FileMode.Open, FileAccess.Read ) )
				{
					BinaryReader br = new BinaryReader ( fs );
					if ( br.ReadUInt16 () != 0xDEAD )
					{
						return false;
					}
					if ( br.ReadByte () != 1 )
					{
						return false;
					}
					int width = br.ReadInt32 (), height = br.ReadInt32 ();
					ClientSize = new Size ( width, height );

					m_layers = bf.Deserialize ( fs ) as List<Layer>;
					foreach ( Layer layer in m_layers )
						layer.RemakeGraphics ();
				}
			}
			else
			{
				try
				{
					Bitmap bmp = Bitmap.FromFile ( filename ) as Bitmap;
					Layer layer = new Layer ( bmp );
					m_layers.Add ( layer );
				}
				catch { return false; }
			}

			return true;
		}

		/// <summary>
		/// 데이터 저장하기
		/// </summary>
		/// <param name="filename">저장할 파일 경로</param>
		/// <returns>저장하기 성공 여부</returns>
		private bool SaveFile ( string filename )
		{
			if ( CheckFileFormat ( filename ) )
			{
				using ( FileStream fs = new FileStream ( filename, FileMode.Create, FileAccess.Write ) )
				{
					BinaryWriter bw = new BinaryWriter ( fs );
					bw.Write ( ( ushort ) 0xDEAD );
					bw.Write ( ( byte ) 1 );

					bw.Write ( ClientSize.Width );
					bw.Write ( ClientSize.Height );

					bf.Serialize ( fs, m_layers );
				}
			}
			else
			{
				try
				{
					if ( m_layers.Count > 1 )
						if ( MessageBox.Show ( "레이어를 모두 통합하여 저장하게 됩니다.\n계속 저장하시겠습니까?",
							"프로젝트 보드카", MessageBoxButtons.YesNo, MessageBoxIcon.Question ) == DialogResult.No )
							return false;

					Bitmap temp = new Bitmap ( ClientSize.Width, ClientSize.Height );
					Graphics tempGraphics = Graphics.FromImage ( temp );
					foreach ( Layer layer in m_layers )
						if ( layer.IsVisible )
							tempGraphics.DrawImageUnscaled ( layer.Bitmap, 0, 0 );
					temp.Save ( filename );

					m_layers.Clear ();
					m_layers.Add ( new Layer ( temp ) );
					m_selectedLayer = 0;
				}
				catch { return false; }
			}

			return true;
		}
		#endregion

		#region File I/O Methods
		public void FileNew ()
		{
			if ( !CheckSaveState () ) return;

			NewFile ();

			Invalidate ();
			RefreshTitle ();
		}

		public void FileOpen ()
		{
			if ( !CheckSaveState () ) return;

			if ( ofdDialog.ShowDialog () == DialogResult.Cancel ) return;
			LoadFile ( m_savedPath = ofdDialog.FileName );
			m_isSaved = true;

			Invalidate ();
			RefreshTitle ();
		}

		public bool FileSave ()
		{
			if ( m_savedPath == "" ) return FileSaveAs ();
			SaveFile ( m_savedPath );
			m_isSaved = true;
			return true;
		}

		public bool FileSaveAs ()
		{
			if ( sfdDialog.ShowDialog () == DialogResult.Cancel ) return false;
			SaveFile ( m_savedPath = sfdDialog.FileName );
			m_isSaved = true;
			return true;
		}

		#endregion

		#region Drawing Methods
		/// <summary>
		/// 필압률 계산
		/// </summary>
		/// <param name="tabletPressure">필압</param>
		/// <returns>필압률 (0.0 ~ 2.0)</returns>
		private float CalculatePressurePercent ( int tabletPressure )
		{
			if ( tabletPressure == 0 ) return 1;
			return tabletPressure / ( m_tabletMaxPressure / 2.0f );
		}

		/// <summary>
		/// 브러시 색상 계산
		/// </summary>
		/// <param name="tabletPressure">필압</param>
		/// <returns>필압에 따라 알파값 적용된 브러시 색상</returns>
		private Color CalculateBrushColor ( int tabletPressure )
		{
			// 지우개 모드일 경우 투명색
			if ( m_isEraser ) return Color.Transparent;
			// 필압에 의한 브러시 크기 변환이 꺼져 있을 경우 브러시 색상 반환
			if ( !m_hasBrushConsist ) return m_brushColor;

			// 알파값 계산
			int alpha = ( int ) ( m_brushColor.A * CalculatePressurePercent ( tabletPressure ) );
			if ( alpha > 255 ) alpha = 255;
			if ( alpha < 0 ) alpha = 0;
			return Color.FromArgb ( alpha, m_brushColor );
		}

		/// <summary>
		/// 점 출력
		/// </summary>
		/// <param name="g">드로어</param>
		/// <param name="point">점 위치</param>
		/// <param name="tabletPressure">필압</param>
		private void DrawPoint ( Graphics g, PointF point, int tabletPressure )
		{
			float radius = m_brushSize;
			if ( m_hasBrushDynamicSize ) radius *= CalculatePressurePercent ( tabletPressure );

			using ( SolidBrush brush = new SolidBrush ( CalculateBrushColor ( tabletPressure ) ) )
			{
				// 지우개 모드의 경우 덮어 쓰기
				if ( m_isEraser ) g.CompositingMode = CompositingMode.SourceCopy;

				// 타원 출력
				g.FillEllipse ( brush, point.X - radius, point.Y - radius, radius * 2, radius * 2 );
				g.CompositingMode = CompositingMode.SourceOver;
			}
		}

		/// <summary>
		/// 선 그리기
		/// </summary>
		/// <param name="g">드로어</param>
		/// <param name="p">시작점</param>
		/// <param name="p2">끝점</param>
		private void DrawLine ( Graphics g, PointF p, PointF p2 )
		{
			int iDeltaX, iDeltaY;
			int iError = 0;
			int iDeltaError;
			int iX, iY;
			int iStepX, iStepY;

			iDeltaX = ( int ) ( p2.X - p.X );
			iDeltaY = ( int ) ( p2.Y - p.Y );

			if ( iDeltaX < 0 ) { iDeltaX = -iDeltaX; iStepX = -1; }
			else iStepX = 1;

			if ( iDeltaY < 0 ) { iDeltaY = -iDeltaY; iStepY = -1; }
			else iStepY = 1;

			float differenceValue;
			float addminValue = 0;
			float dynamicSizeValue = m_lastTabletPressure;

			if ( iDeltaX > iDeltaY )
			{
				iDeltaError = ( ( int ) iDeltaY ) << 1;
				iY = ( int ) p.Y;

				differenceValue = ( p.X - p2.X ) / iStepX;
				addminValue = ( ( m_tabletPressure - m_lastTabletPressure ) / m_tabletMaxPressure / 2.0f ) / differenceValue;

				for ( iX = ( int ) p.X; iX != p2.X; iX += iStepX )
				{
					DrawPoint ( g, new PointF ( iX, iY ), ( int ) dynamicSizeValue );
					if ( m_hasBrushDynamicSize ) dynamicSizeValue += addminValue;
					iError += iDeltaError;

					if ( iError >= iDeltaX )
					{
						iY += iStepY;
						iError -= ( ( int ) iDeltaX ) << 1;
					}
				}
			}
			else
			{
				iDeltaError = ( ( int ) iDeltaX ) << 1;
				iX = ( int ) p.X;

				differenceValue = ( p.Y - p2.Y ) / iStepY;
				addminValue = ( ( m_tabletPressure - m_lastTabletPressure ) / m_tabletMaxPressure / 2.0f ) / differenceValue;

				for ( iY = ( int ) p.Y; iY != p2.Y; iY += iStepY )
				{
					DrawPoint ( g, new PointF ( iX, iY ), ( int ) dynamicSizeValue );
					if ( m_hasBrushDynamicSize ) dynamicSizeValue += addminValue;
					iError += iDeltaError;

					if ( iError >= iDeltaY )
					{
						iX += iStepX;
						iError -= ( ( int ) iDeltaY ) << 1;
					}
				}
			}
		}
		#endregion

		#region Constructors
		public Vodka ()
		{
			InitializeComponent ();
			ClientSize = new Size ( 800, 600 );

			AddNewLayer ();
			m_layers [ 0 ].Graphics.Clear ( Color.White );
			m_isSaved = true;
			m_undoStack.Clear ();

			RefreshTitle ();

			ofdDialog.Filter = sfdDialog.Filter =
				String.Format ( "{0}|{1}",
				"지원하는 모든 이미지 파일(*.png;*.bmp;*.jpg;*.tif)|*.png;*.bmp;*.jpg;*.tif",
				"보드카 레이어 이미지 파일(*.vodka;*.vdk)|*.vodka;*.vdk" );

			m_wintabContext = new WinTabContext ();
			m_wintabContext.Open ( Handle, false );
		}

		public Vodka ( string filename )
		{
			InitializeComponent ();

			if ( !LoadFile ( filename ) )
			{
				MessageBox.Show ( "파일을 읽을 수 없었습니다!", "프로젝트 보드카" );
				Close ();
				return;
			}

			m_isSaved = true;

			ofdDialog.Filter = sfdDialog.Filter =
				String.Format ( "{0}|{1}",
				"지원하는 모든 이미지 파일(*.png;*.bmp;*.jpg;*.tif)|*.png;*.bmp;*.jpg;*.tif",
				"보드카 레이어 이미지 파일(*.vodka;*.vdk)|*.vodka;*.vdk" );

			m_wintabContext = new WinTabContext ();
			m_wintabContext.Open ( Handle, false );
		}
		#endregion

		#region Event Handlers
		private void Vodka_Activated ( object sender, EventArgs e )
		{
			if ( m_wintabContext != null )
			{
				m_wintabContext.Enabled = true;
				m_tabletMaxPressure = WinTab.DeviceNPressure.axMax;
			}
		}

		private void Vodka_Resize ( object sender, EventArgs e )
		{
			RefreshTitle ();
		}

		private void Vodka_ResizeEnd ( object sender, EventArgs e )
		{
			if ( m_currentWidth == ClientSize.Width && m_currentHeight == ClientSize.Height ) return;

			if ( MessageBox.Show ( "크기를 조정하면 실행 취소 및 다시 실행을 할 수 없습니다.\n 그래도 크기를 변경하시겠습니까?",
				"프로젝트 보드카", MessageBoxButtons.YesNo, MessageBoxIcon.Warning ) == DialogResult.No )
			{
				ClientSize = new Size ( m_currentWidth, m_currentHeight );
				return;
			}

			RefreshTitle ();
			foreach ( Layer layer in m_layers )
				layer.Resize ( m_currentWidth = ClientSize.Width, m_currentHeight = ClientSize.Height );
			Invalidate ();
		}

		private void Vodka_HelpButtonClicked ( object sender, CancelEventArgs e )
		{
			MessageBox.Show ( String.Format (
				"{0}\n{1}\n{2}\n{3}\n{4}\n{5}\n{6}\n{7}\n{8}\n{9}\n{10}\n{11}\n{12}\n{13}\n{14}\n{15}\n{16}",
				"---- 파일 관리 ----",
				"N키 : 새로 만들기",
				"O키 : 기존 파일 열기",
				"S키 : 현재 편집 내용 저장\n",

				"---- 작업 관리 ----",
				"Z키 : 실행 취소",
				"Y키 : 다시 실행\n",

				"---- 레이어 관리 ----",
				"↑키 : 얕은 레이어로 이동",
				"↓키 : 깊은 레이어로 이동",
				"A키 : 레이어 추가",
				"D키 : 레이어 제거",
				"V키 : 현재 레이어 확인\n",

				"---- 색 및 브러시 관리 ----",
				"B키 : 색 및 브러시 설정, 기타 설정\n",

				"---- 기타 ----",
				"H키 : 프로그램 정보 보기"
				),
				"프로젝트 보드카" );
			e.Cancel = true;
		}

		private void Vodka_KeyUp ( object sender, KeyEventArgs e )
		{
			switch ( e.KeyCode )
			{
				case Keys.N:
					FileNew ();
					break;
				case Keys.O:
					FileOpen ();
					break;
				case Keys.S:
					FileSave ();
					break;

				case Keys.Z:
					RecoveryUndoList ();
					LayerCorrection ();

					Invalidate ();
					RefreshTitle ();
					break;
				case Keys.Y:
					RecoveryRedoList ();
					LayerCorrection ();

					Invalidate ();
					RefreshTitle ();
					break;

				case Keys.Up:
					m_selectedLayer++;
					LayerCorrection ();

					Invalidate ();
					RefreshTitle ();
					break;
				case Keys.Down:
					m_selectedLayer--;
					LayerCorrection ();

					Invalidate ();
					RefreshTitle ();
					break;
				case Keys.A:
					AddNewLayer ();

					Invalidate ();
					RefreshTitle ();
					break;
				case Keys.D:
					if ( MessageBox.Show ( "정말로 현재 레이어를 삭제하시겠습니까?",
						"프로젝트 보드카", MessageBoxButtons.YesNo, MessageBoxIcon.Warning )
						== DialogResult.No ) break;
					if ( m_layers.Count == 1 )
					{
						MessageBox.Show ( "레이어가 한 개만 있을 경우 삭제할 수 없습니다.", "프로젝트 보드카" );
						break;
					}
					RemoveLayer ();

					LayerCorrection ();

					Invalidate ();
					RefreshTitle ();
					break;
				case Keys.V:
					m_checkLayer = !m_checkLayer;
					Invalidate ();
					break;

				case Keys.B:
					if ( m_brushEdit == null || m_brushEdit.IsDisposed )
						m_brushEdit = new BrushEdit ( this );
					m_brushEdit.Hide ();
					m_brushEdit.Show ( this );
					break;

				case Keys.Home:
					if ( m_vodkaServer == null || m_vodkaServer.IsDisposed )
						m_vodkaServer = new VodkaServer ();
					m_vodkaServer.Hide ();
					m_vodkaServer.Show ( this );
					break;

				case Keys.H:
					new AboutBox ().ShowDialog ();
					break;
			}
		}

		private void Vodka_MouseDown ( object sender, MouseEventArgs e )
		{
			AddUndoList ();
			m_lastMousePos = new Point ( e.X, e.Y );
			m_lastTabletPressure = m_tabletPressure;
			m_isMouseDown = true;
		}

		private void Vodka_MouseMove ( object sender, MouseEventArgs e )
		{
			if ( m_isMouseDown )
			{
				DrawLine ( m_layers [ m_selectedLayer ].Graphics, m_lastMousePos, new PointF ( e.X, e.Y ) );
				m_lastMousePos = new Point ( e.X, e.Y );
				m_lastTabletPressure = m_tabletPressure;
				Invalidate ();
			}
		}

		private void Vodka_MouseUp ( object sender, MouseEventArgs e )
		{
			m_isMouseDown = false;
			m_isSaved = false;
			Invalidate ();
			RefreshTitle ();
		}

		private void Vodka_Paint ( object sender, PaintEventArgs e )
		{
			e.Graphics.Clear ( Color.White );

			e.Graphics.CompositingQuality = CompositingQuality.HighSpeed;
			e.Graphics.InterpolationMode = InterpolationMode.Low;
			e.Graphics.SmoothingMode = SmoothingMode.HighSpeed;

			int transparentSize = Resources.Transparent.Width;
			for ( int i = 0; i < ClientSize.Width / transparentSize + 1; i++ )
				for ( int j = 0; j < ClientSize.Height / transparentSize + 1; j++ )
				{
					if ( e.ClipRectangle.IntersectsWith ( new Rectangle ( i * transparentSize, j * transparentSize,
						transparentSize, transparentSize ) ) )
					{
						e.Graphics.DrawImageUnscaled ( Resources.Transparent,
							i * transparentSize, j * transparentSize );
					}
				}

			foreach ( Layer layer in m_layers )
			{
				if ( m_checkLayer && ( m_layers [ m_selectedLayer ] != layer ) )
				{
					ColorMatrix colorMatrix = new ColorMatrix ( new float [] []{
																new float[]{1.0f, 0.0f, 0.0f, 0.0f, 0.0f},
																new float[]{0.0f, 1.0f, 0.0f, 0.0f, 0.0f},
																new float[]{0.0f, 0.0f, 1.0f, 0.0f, 0.0f},
																new float[]{0.0f, 0.0f, 0.0f, 0.2f, 0.0f},
																new float[]{0.0f, 0.0f, 0.0f, 0.0f, 1.0f }
															} );
					ImageAttributes attr = new ImageAttributes ();
					attr.SetColorMatrix ( colorMatrix );
					e.Graphics.DrawImage ( layer.Bitmap, new Rectangle ( 0, 0, layer.Bitmap.Width, layer.Bitmap.Height ),
						0, 0, layer.Bitmap.Width, layer.Bitmap.Height, GraphicsUnit.Pixel, attr );
				}
				else
				{
					e.Graphics.DrawImageUnscaled ( layer.Bitmap, 0, 0 );
				}
			}
		}

		private void Vodka_FormClosing ( object sender, FormClosingEventArgs e )
		{
			if ( !CheckSaveState () ) e.Cancel = true;
		}
		#endregion

		#region Window Procedure
		protected unsafe override void WndProc ( ref Message m )
		{
			bool isPacketEventAlive = false;
			try
			{
				switch ( m.Msg )
				{
					case WinTab.WT_PACKET:
						{

							if ( m_wintabContext != null )
							{
								PacketEventArgs e = new PacketEventArgs ();
								WinTab.WTPacket ( m.LParam, ( uint ) m.WParam, &( e.pkts ) );

								if ( ( e.pkts.pkChanged & WTPKT.NORMAL_PRESSURE ) != 0 )
									m_tabletPressure = e.pkts.pkNormalPressure;
								if ( ( e.pkts.pkChanged & WTPKT.STATUS ) != 0 )
									m_isEraser = ( e.pkts.pkStatus & ( int ) PacketStatus.INVERT ) != 0;
								isPacketEventAlive = true;
							}
						}
						break;
				}
			}
			catch { }
			finally
			{
				if ( !isPacketEventAlive )
					base.WndProc ( ref m );
			}
		}
		#endregion
	}
}
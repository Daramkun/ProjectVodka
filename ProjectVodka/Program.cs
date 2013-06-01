using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ProjectVodka
{
	static class Program
	{
		/// <summary>
		/// 해당 응용 프로그램의 주 진입점입니다.
		/// </summary>
		[STAThread]
		static void Main ()
		{
			try
			{
				Application.EnableVisualStyles ();
				Application.SetCompatibleTextRenderingDefault ( false );
				Application.Run ( new Vodka () );
			}
			catch
			{
				MessageBox.Show ( String.Format("{0}\n{1}","오류가 발생하여 부득이하게 프로그램을 종료합니다.", 
					"오류가 발생한 것에 심히 유감을 표하며, 어떤 경유로 오류가 발생했는지 알려주시면 빠른 시일 내에 고쳐보도록 노력하겠습니다."), 
					"프로젝트 보드카" );
			}
		}
	}
}

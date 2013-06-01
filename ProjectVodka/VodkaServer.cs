using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace ProjectVodka
{
	public partial class VodkaServer : Form
	{
		Socket m_listenSocket;

		public VodkaServer ()
		{
			InitializeComponent ();

			IPAddress [] addr = Dns.GetHostAddresses ( Dns.GetHostName () );
			foreach ( IPAddress adr in addr )
				if ( adr.AddressFamily == AddressFamily.InterNetwork )
					cmbIp.Items.Add ( adr.ToString () );
			cmbIp.SelectedIndex = 0;
		}

		private void btnStart_Click ( object sender, EventArgs e )
		{
			m_listenSocket = new Socket ( AddressFamily.InterNetwork,
				SocketType.Stream, ProtocolType.Tcp );

		}
	}
}

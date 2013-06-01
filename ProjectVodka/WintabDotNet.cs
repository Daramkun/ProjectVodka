using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ProjectVodka
{
	using HCTX = IntPtr;
	using BOOL = Int32;

	public static partial class WinTab
	{
		public const int WT_DEFBASE = 0x7FF0;
		public const int WT_MAXOFFSET = 0xF;

		public const int WT_PACKET = WT_DEFBASE + 0;
		public const int WT_CTXOPEN = WT_DEFBASE + 1;
		public const int WT_CTXCLOSE = WT_DEFBASE + 2;
		public const int WT_CTXUPDATE = WT_DEFBASE + 3;
		public const int WT_CTXOVERLAP = WT_DEFBASE + 4;
		public const int WT_PROXIMITY = WT_DEFBASE + 5;
		public const int WT_INFOCHANGE = WT_DEFBASE + 6;
		public const int WT_CSRCHANGE = WT_DEFBASE + 7;
		public const int WT_MAX = WT_DEFBASE + WT_MAXOFFSET;

		public const int LCNAMELEN = 40;
		public const WTPKT WTPKT_ALL_WITHOUT_XY =
			WTPKT.STATUS | WTPKT.CHANGED |
			WTPKT.CURSOR | WTPKT.BUTTONS | 
			WTPKT.NORMAL_PRESSURE;
	};

	[Flags]
	public enum WTPKT : uint {
		CONTEXT = 0x0001,
		STATUS = 0x0002,
		TIME = 0x0004,
		CHANGED = 0x0008,
		SERIAL_NUMBER = 0x0010,
		CURSOR = 0x0020,
		BUTTONS = 0x0040,
		X = 0x0080,
		Y = 0x0100,
		Z = 0x0200,
		NORMAL_PRESSURE = 0x0400,
		TANGENT_PRESSURE = 0x0800,
		ORIENTATION = 0x1000,
		ROTATION = 0x2000
	};

	[StructLayout ( LayoutKind.Sequential )]
	public struct AXIS
	{
		public int axMin;
		public int axMax;
		public uint axUnits;
		public Int32 axResolution;
	};

	public enum UnitSpecifies
	{
		NONE = 0,
		INCHES = 1,
		CENTIMETERS = 2,
		CIRCLE = 3
	};

	public enum SystemButton
	{
		NONE = 0x00,
		LCLICK = 0x01,
		LDBLCLICK = 0x02,
		LDRAG = 0x03,
		RCLICK = 0x04,
		RDBLCLICK = 0x05,
		RDRAG = 0x06,
		MCLICK = 0x07,
		MDBLCLICK = 0x08,
		MDRAG = 0x09,

		PTCLICK = 0x10,
		PTDBLCLICK = 0x20,
		PTDRAG = 0x30,
		PNCLICK = 0x40,
		PNDBLCLICK = 0x50,
		PNDRAG = 0x60,
		P1CLICK = 0x70,
		P1DBLCLICK = 0x80,
		P1DRAG = 0x90,
		P2CLICK = 0xA0,
		P2DBLCLICK = 0xB0,
		P2DRAG = 0xC0,
		P3CLICK = 0xD0,
		P3DBLCLICK = 0xE0,
		P3DRAG = 0xF0,
	};

	[Flags]
	public enum HardwareCapabilities
	{
		INTEGRATED = 0x0001,
		TOUCH = 0x0002,
		HARDPROX = 0x0004,
		PHYSID_CURSORS = 0x0008,
	};

	[Flags]
	public enum CursorCapabilities
	{
		MULTIMODE = 0x0001,
		AGGREGATE = 0x0002,
		INVERT = 0x0004,
	};

	public enum InfoCategory : uint
	{
		NONE = 0,
		INTERFACE = 1,
		STATUS = 2,
		DEFCONTEXT = 3,
		DEFSYSCTX = 4,
		DEVICES = 100,
		CURSORS = 200,
		EXTENSIONS = 300,
		DDCTXS = 400,
		DSCTXS = 500
	};

	public struct InfoIndex
	{
		public enum INTERFACE
		{
			WINTABID = 1,
			SPECVERSION = 2,
			IMPLVERSION = 3,
			NDEVICES = 4,
			NCURSORS = 5,
			NCONTEXTS = 6,
			CTXOPTIONS = 7,
			CTXSAVESIZE = 8,
			NEXTENSIONS = 9,
			NMANAGERS = 10,
			MAX = 10
		}

		public enum STATUS
		{
			CONTEXTS = 1,
			SYSCTXS = 2,
			PKTRATE = 3,
			PKTDATA = 4,
			MANAGERS = 5,
			SYSTEM = 6,
			BUTTONUSE = 7,
			SYSBTNUSE = 8,
			MAX = 8
		}

		public enum CONTEXT
		{
			NAME = 1,
			OPTIONS = 2,
			STATUS = 3,
			LOCKS = 4,
			MSGBASE = 5,
			DEVICE = 6,
			PKTRATE = 7,
			PKTDATA = 8,
			PKTMODE = 9,
			MOVEMASK = 10,
			BTNDNMASK = 11,
			BTNUPMASK = 12,
			INORGX = 13,
			INORGY = 14,
			INORGZ = 15,
			INEXTX = 16,
			INEXTY = 17,
			INEXTZ = 18,
			OUTORGX = 19,
			OUTORGY = 20,
			OUTORGZ = 21,
			OUTEXTX = 22,
			OUTEXTY = 23,
			OUTEXTZ = 24,
			SENSX = 25,
			SENSY = 26,
			SENSZ = 27,
			SYSMODE = 28,
			SYSORGX = 29,
			SYSORGY = 30,
			SYSEXTX = 31,
			SYSEXTY = 32,
			SYSSENSX = 33,
			SYSSENSY = 34,
			MAX = 34
		}

		public enum DEVICE
		{
			NAME = 1,
			HARDWARE = 2,
			NCSRTYPES = 3,
			FIRSTCSR = 4,
			PKTRATE = 5,
			PKTDATA = 6,
			PKTMODE = 7,
			CSRDATA = 8,
			XMARGIN = 9,
			YMARGIN = 10,
			ZMARGIN = 11,
			X = 12,
			Y = 13,
			Z = 14,
			NPRESSURE = 15,
			TPRESSURE = 16,
			ORIENTATION = 17,
			ROTATION = 18,
			PNPID = 19,
			MAX = 19
		}

		public enum CURSOR
		{
			NAME = 1,
			ACTIVE = 2,
			PKTDATA = 3,
			BUTTONS = 4,
			BUTTONBITS = 5,
			BTNNAMES = 6,
			BUTTONMAP = 7,
			SYSBTNMAP = 8,
			NPBUTTON = 9,
			NPBTNMARKS = 10,
			NPRESPONSE = 11,
			TPBUTTON = 12,
			TPBTNMARKS = 13,
			TPRESPONSE = 14,
			PHYSID = 15,
			MODE = 16,
			MINPKTDATA = 17,
			MINBUTTONS = 18,
			CAPABILITIES = 19,
			MAX = 19
		}

		public enum EXTENSION
		{
			NAME = 1,
			TAG = 2,
			MASK = 3,
			SIZE = 4,
			AXES = 5,
			DEFAULT = 6,
			DEFCONTEXT = 7,
			DEFSYSCTX = 8,
			CURSORS = 9,
			MAX = 109
		}
	};

	[StructLayout ( LayoutKind.Sequential )]
	unsafe public struct LOGCONTEXT
	{
		public fixed char lcName [ WinTab.LCNAMELEN ];
		public ContextOption lcOptions;
		public uint lcStatus;
		public uint lcLocks;
		public uint lcMsgBase;
		public uint lcDevice;
		public uint lcPktRate;
		public WTPKT lcPktData;
		public WTPKT lcPktMode;
		public WTPKT lcMoveMask;
		public uint lcBtnDnMask;
		public uint lcBtnUpMask;
		public int lcInOrgX;
		public int lcInOrgY;
		public int lcInOrgZ;
		public int lcInExtX;
		public int lcInExtY;
		public int lcInExtZ;
		public int lcOutOrgX;
		public int lcOutOrgY;
		public int lcOutOrgZ;
		public int lcOutExtX;
		public int lcOutExtY;
		public int lcOutExtZ;
		public Int32 lcSensX;
		public Int32 lcSensY;
		public Int32 lcSensZ;
		public int lcSysMode;
		public int lcSysOrgX;
		public int lcSysOrgY;
		public int lcSysExtX;
		public int lcSysExtY;
		public Int32 lcSysSensX;
		public Int32 lcSysSensY;
	}

	[Flags]
	public enum ContextOption : uint
	{
		DEFAULT = 0x0000,
		SYSTEM = 0x0001,
		PEN = 0x0002,
		MESSAGES = 0x0004,
		CSRMESSAGES = 0x0008,
		MGNINSIDE = 0x4000,
		MARGIN = 0x8000,

		OFFMODE = 0x10000,
	};

	[Flags]
	public enum ContextStatus
	{
		DISABLED = 0x0001,
		OBSCURED = 0x0002,
		ONTOP = 0x0004,
	};

	[Flags]
	public enum ContextLock
	{
		INSIZE = 0x0001,
		INASPECT = 0x0002,
		SENSITIVITY = 0x0004,
		MARGIN = 0x0008,
		SYSOUT = 0x0010
	};

	[Flags]
	public enum PacketStatus
	{
		PROXIMITY = 0x0001,
		QUEUE_ERR = 0x0002,
		MARGIN = 0x0004,
		GRAB = 0x0008,
		INVERT = 0x0010
	}

	[StructLayout ( LayoutKind.Sequential )]
	public struct ORIENTATION
	{
		public int orAzimuth;
		public int orAltitude;
		public int orTwist;
	}

	[StructLayout ( LayoutKind.Sequential )]
	public struct ROTATION
	{
		public int roPitch;
		public int roRoll;
		public int roYaw;
	}

	public enum RelativeButton
	{
		NONE = 0,
		UP = 1,
		DOWN = 2
	};

	public enum WTDeviceConfig
	{
		NONE = 0,
		CANCEL = 1,
		OK = 2,
		RESTART = 3
	};

	public enum WTHook
	{
		PLAYBACK = 1,
		RECORD = 2
	};

	public enum WTHookConfig
	{
		GETLPLPFN = -3,
		LPLPFNNEXT = -2,
		LPFNNEXT = -1,
		ACTION = 0,
		GETNEXT = 1,
		SKIP = 2
	};

	public enum WTX
	{
		OBT = 0,
		FKEYS = 1,
		TILT = 2,
		CSRMASK = 3,
		XBTNMASK = 4,
	};

	[StructLayout ( LayoutKind.Sequential )]
	public unsafe struct XBTNMASK
	{
		public fixed byte xBtnDnMask [ 32 ];
		public fixed byte xBtnUpMask [ 32 ];
	};

	[StructLayout ( LayoutKind.Sequential )]
	public struct TILT
	{
		public int tiltX;
		public int tiltY;
	};

	static unsafe public partial class WinTab
	{
        [DllImport("WinTab32.dll",EntryPoint="WTOpenW")]
        public static extern IntPtr _WTOpen(IntPtr hWnd, void* lpLogCtx,BOOL fEnable);
        [DllImport("WinTab32.dll",EntryPoint="WTClose")]
        public static extern int _WTClose(HCTX hCTX);
        [DllImport("WinTab32.dll",EntryPoint="WTInfoW")]
        public static extern uint _WTInfo(uint nCategory,uint nIndex,void* pBuf);
        [DllImport("WinTab32.dll",EntryPoint="WTPacket")]
        public static extern int _WTPacket(HCTX hCTX,uint wSerial,void* pBuf);
        [DllImport("WinTab32.dll",EntryPoint="WTEnable")]
        public static extern int _WTEnable(HCTX hCTX,BOOL fEnable);
        [DllImport("WinTab32.dll",EntryPoint="WTOverlap")]
        public static extern int _WTOverlap(HCTX hCTX,BOOL fEnable);
        [DllImport("WinTab32.dll",EntryPoint="WTConfig")]
        public static extern int _WTConfig(HCTX hCTX,IntPtr hWnd);

		public static HCTX WTOpen ( IntPtr hWnd, void* lpLogCtx, BOOL fEnable )
		{
			HCTX ret = _WTOpen ( hWnd, lpLogCtx, fEnable );
			if ( ret == IntPtr.Zero ) { throw new Exception ( "WTOpen failed." ); }
			return ret;
		}

		public static void WTClose ( HCTX hCTX )
		{
			if ( _WTClose ( hCTX ) == 0 ) { throw new Exception ( "WTClose failed." ); }
		}

		public static uint WTInfo ( InfoCategory nCategory, uint nIndex, void* pBuf )
		{
			uint ret = _WTInfo ( ( uint ) nCategory, nIndex, pBuf );
			if ( ret == 0 ) { throw new Exception ( "WTInfo failed." ); }
			return ret;
		}

		public static void WTPacket ( HCTX hCTX, uint wSerial, void* pBuf )
		{
			if ( _WTPacket ( hCTX, wSerial, pBuf ) == 0 ) { throw new Exception ( "WTPacket failed. (Packet queue is empty?)" ); }
		}

		public static void WTEnable ( HCTX hCTX, BOOL fEnable )
		{
			if ( _WTEnable ( hCTX, fEnable ) == 0 ) { throw new Exception ( "WTEnable failed." ); }
		}

		public static void WTOverlap ( HCTX hCTX, BOOL fEnable )
		{
			if ( _WTOverlap ( hCTX, fEnable ) == 0 ) { throw new Exception ( "WTOverlap failed." ); }
		}

		public static bool WTConfig ( HCTX hCTX, IntPtr hWnd )
		{
			return _WTConfig ( hCTX, hWnd ) != 0;
		}

		[DllImport ( "User32.dll" )]
		public static extern int GetSystemMetrics ( int nIndex );
	};

	[StructLayout ( LayoutKind.Sequential )]
	public struct PACKET
	{
		public uint pkStatus;
		public WTPKT pkChanged;
		public uint pkCursor;
		public uint pkButtons;
		public int pkNormalPressure;
	};

	public static partial class WinTab
	{
		private static unsafe uint GetInfoUInt ( InfoCategory cat, uint idx )
		{
			uint p;
			WTInfo ( cat, idx, &p );
			return p;
		}

		private static unsafe uint [] GetInfoUInts ( InfoCategory cat, uint idx, uint count )
		{
			uint [] r = new uint [ count ];
			fixed ( uint* p = r )
			{
				WTInfo ( cat, idx, p );
			}
			return r;
		}

		private static unsafe ushort GetInfoWord ( InfoCategory cat, uint idx )
		{
			ushort p;
			WTInfo ( cat, idx, &p );
			return p;
		}

		private static unsafe byte GetInfoByte ( InfoCategory cat, uint idx )
		{
			byte p;
			WTInfo ( cat, idx, &p );
			return p;
		}

		private static unsafe byte [] GetInfoBytes ( InfoCategory cat, uint idx, uint bytes )
		{
			byte [] r = new byte [ bytes ];
			fixed ( byte* p = r )
			{
				WTInfo ( cat, idx, p );
			}
			return r;
		}

		private static unsafe string GetInfoString ( InfoCategory cat, uint idx )
		{
			char* buf = stackalloc char [ 128 ];
			WTInfo ( cat, idx, buf );
			return new string ( buf );
		}

		private static unsafe string [] GetInfoStrings ( InfoCategory cat, uint idx )
		{
			char [] buf = new char [ 256 ];
			char [] cbuf = new char [ 256 ];
			ArrayList r = new ArrayList ();

			fixed ( char* p = buf )
			{
				uint f = WTInfo ( cat, idx, p );
				int lp = 0;
				for ( int i = 0; i < buf.Length - 1; i++ )
				{
					if ( p [ i ] == '\0' )
					{
						cbuf.Initialize ();
						Array.Copy ( buf, lp, cbuf, 0, i - lp );
						r.Insert ( 0, new string ( cbuf ) );
						lp = 0;

						if ( p [ i + 1 ] == '\0' ) { break; }
					}
					else { lp++; }
				}
			}
			return ( string [] ) r.ToArray ( typeof ( string [] ) );
		}

		private static unsafe AXIS GetInfoAxis ( InfoCategory cat, uint idx )
		{
			AXIS p;
			WTInfo ( cat, idx, &p );
			return p;
		}

		private static unsafe AXIS [] GetInfoAxisA ( InfoCategory cat, uint idx, int c )
		{
			AXIS [] buf = new AXIS [ 3 ];
			fixed ( AXIS* p = buf ) { WTInfo ( cat, idx, p ); }
			return buf;
		}

		public static string WinTabID
		{
			get { return GetInfoString ( InfoCategory.INTERFACE, ( uint ) InfoIndex.INTERFACE.WINTABID ); }
		}

		public static ushort SpecVersion
		{
			get { return GetInfoWord ( InfoCategory.INTERFACE, ( uint ) InfoIndex.INTERFACE.SPECVERSION ); }
		}

		public static ushort ImplVersion
		{
			get { return GetInfoWord ( InfoCategory.INTERFACE, ( uint ) InfoIndex.INTERFACE.IMPLVERSION ); }
		}

		public static uint SupportedDevices
		{
			get { return GetInfoUInt ( InfoCategory.INTERFACE, ( uint ) InfoIndex.INTERFACE.NDEVICES ); }
		}

		public static uint SupportedCursors
		{
			get { return GetInfoUInt ( InfoCategory.INTERFACE, ( uint ) InfoIndex.INTERFACE.NCURSORS ); }
		}

		public static uint SupportedContexts
		{
			get { return GetInfoUInt ( InfoCategory.INTERFACE, ( uint ) InfoIndex.INTERFACE.NCONTEXTS ); }
		}

		public static uint ContextOptions
		{
			get { return GetInfoUInt ( InfoCategory.INTERFACE, ( uint ) InfoIndex.INTERFACE.CTXOPTIONS ); }
		}

		public static uint ContextSaveSize
		{
			get { return GetInfoUInt ( InfoCategory.INTERFACE, ( uint ) InfoIndex.INTERFACE.CTXSAVESIZE ); }
		}

		public static uint Extensions
		{
			get { return GetInfoUInt ( InfoCategory.INTERFACE, ( uint ) InfoIndex.INTERFACE.NEXTENSIONS ); }
		}

		public static uint Managers
		{
			get { return GetInfoUInt ( InfoCategory.INTERFACE, ( uint ) InfoIndex.INTERFACE.NMANAGERS ); }
		}

		public static string DeviceName
		{
			get { return GetInfoString ( InfoCategory.DEVICES, ( uint ) InfoIndex.DEVICE.NAME ); }
		}

		public static HardwareCapabilities DeviceCapabilities
		{
			get { return ( HardwareCapabilities ) GetInfoUInt ( InfoCategory.DEVICES, ( uint ) InfoIndex.DEVICE.HARDWARE ); }
		}

		public static uint DeviceCursorTypes
		{
			get { return GetInfoUInt ( InfoCategory.DEVICES, ( uint ) InfoIndex.DEVICE.NCSRTYPES ); }
		}

		public static uint DeviceFirstCursor
		{
			get { return GetInfoUInt ( InfoCategory.DEVICES, ( uint ) InfoIndex.DEVICE.FIRSTCSR ); }
		}

		public static uint DevicePacketRate
		{
			get { return GetInfoUInt ( InfoCategory.DEVICES, ( uint ) InfoIndex.DEVICE.PKTRATE ); }
		}

		public static WTPKT DevicePacketData
		{
			get { return ( WTPKT ) GetInfoUInt ( InfoCategory.DEVICES, ( uint ) InfoIndex.DEVICE.PKTDATA ); }
		}

		public static WTPKT DevicePacketMode
		{
			get { return ( WTPKT ) GetInfoUInt ( InfoCategory.DEVICES, ( uint ) InfoIndex.DEVICE.PKTMODE ); }
		}

		public static WTPKT DeviceCursorData
		{
			get { return ( WTPKT ) GetInfoUInt ( InfoCategory.DEVICES, ( uint ) InfoIndex.DEVICE.CSRDATA ); }
		}

		public static uint DeviceXMargin
		{
			get { return GetInfoUInt ( InfoCategory.DEVICES, ( uint ) InfoIndex.DEVICE.XMARGIN ); }
		}

		public static uint DeviceYMargin
		{
			get { return GetInfoUInt ( InfoCategory.DEVICES, ( uint ) InfoIndex.DEVICE.YMARGIN ); }
		}

		public static uint DeviceZMargin
		{
			get { return GetInfoUInt ( InfoCategory.DEVICES, ( uint ) InfoIndex.DEVICE.ZMARGIN ); }
		}

		public static AXIS DeviceX
		{
			get { return GetInfoAxis ( InfoCategory.DEVICES, ( uint ) InfoIndex.DEVICE.X ); }
		}

		public static AXIS DeviceY
		{
			get { return GetInfoAxis ( InfoCategory.DEVICES, ( uint ) InfoIndex.DEVICE.Y ); }
		}

		public static AXIS DeviceZ
		{
			get { return GetInfoAxis ( InfoCategory.DEVICES, ( uint ) InfoIndex.DEVICE.Z ); }
		}

		public static AXIS DeviceNPressure
		{
			get { return GetInfoAxis ( InfoCategory.DEVICES, ( uint ) InfoIndex.DEVICE.NPRESSURE ); }
		}

		public static AXIS DeviceTPressure
		{
			get { return GetInfoAxis ( InfoCategory.DEVICES, ( uint ) InfoIndex.DEVICE.TPRESSURE ); }
		}

		public static AXIS [] DeviceOrientation
		{
			get { return GetInfoAxisA ( InfoCategory.DEVICES, ( uint ) InfoIndex.DEVICE.ORIENTATION, 3 ); }
		}

		public static AXIS [] DeviceRotation
		{
			get { return GetInfoAxisA ( InfoCategory.DEVICES, ( uint ) InfoIndex.DEVICE.ROTATION, 3 ); }
		}

		public static string DevicePnPID
		{
			get { return GetInfoString ( InfoCategory.DEVICES, ( uint ) InfoIndex.DEVICE.PNPID ); }
		}

		public static string CursorName
		{
			get { return GetInfoString ( InfoCategory.CURSORS, ( uint ) InfoIndex.CURSOR.NAME ); }
		}

		public static bool CursorIsActive
		{
			get { return GetInfoUInt ( InfoCategory.CURSORS, ( uint ) InfoIndex.CURSOR.ACTIVE ) != 0; }
		}

		public static WTPKT CursorPacketData
		{
			get { return ( WTPKT ) GetInfoUInt ( InfoCategory.CURSORS, ( uint ) InfoIndex.CURSOR.PKTDATA ); }
		}

		public static byte CursorButtons
		{
			get { return GetInfoByte ( InfoCategory.CURSORS, ( uint ) InfoIndex.CURSOR.BUTTONS ); }
		}

		public static byte CursorRawButton
		{
			get { return GetInfoByte ( InfoCategory.CURSORS, ( uint ) InfoIndex.CURSOR.BUTTONBITS ); }
		}

		public static string [] CursorButtonNames
		{
			get { return GetInfoStrings ( InfoCategory.CURSORS, ( uint ) InfoIndex.CURSOR.BTNNAMES ); }
		}

		public static byte [] CursorButtonNumberMap
		{
			get { return GetInfoBytes ( InfoCategory.CURSORS, ( uint ) InfoIndex.CURSOR.BUTTONMAP, 32 ); }
		}

		public static byte [] CursorSystemActionCodeMap
		{
			get { return GetInfoBytes ( InfoCategory.CURSORS, ( uint ) InfoIndex.CURSOR.SYSBTNMAP, 32 ); }
		}

		public static byte CursorNPressureButton
		{
			get { return GetInfoByte ( InfoCategory.CURSORS, ( uint ) InfoIndex.CURSOR.NPBUTTON ); }
		}

		public static uint [] CursorNPressureButtonMark
		{
			get { return GetInfoUInts ( InfoCategory.CURSORS, ( uint ) InfoIndex.CURSOR.NPBUTTON, 2 ); }
		}

		public static uint [] CursorNPressureResponce
		{
			get { return GetInfoUInts ( InfoCategory.CURSORS, ( uint ) InfoIndex.CURSOR.NPRESPONSE, 512 ); }
		}

		public static byte CursorTPressureButton
		{
			get { return GetInfoByte ( InfoCategory.CURSORS, ( uint ) InfoIndex.CURSOR.NPBUTTON ); }
		}

		public static uint [] CursorTPressureButtonMark
		{
			get { return GetInfoUInts ( InfoCategory.CURSORS, ( uint ) InfoIndex.CURSOR.NPBUTTON, 2 ); }
		}

		public static uint [] CursorTPressureResponce
		{
			get { return GetInfoUInts ( InfoCategory.CURSORS, ( uint ) InfoIndex.CURSOR.NPRESPONSE, 512 ); }
		}

		public static uint CursorPhysicalID
		{
			get { return GetInfoUInt ( InfoCategory.CURSORS, ( uint ) InfoIndex.CURSOR.PHYSID ); }
		}

		public static uint CursorMode
		{
			get { return GetInfoUInt ( InfoCategory.CURSORS, ( uint ) InfoIndex.CURSOR.MODE ); }
		}

		public static uint CursorMinPacket
		{
			get { return GetInfoUInt ( InfoCategory.CURSORS, ( uint ) InfoIndex.CURSOR.MINPKTDATA ); }
		}

		public static uint CursorMinButton
		{
			get { return GetInfoUInt ( InfoCategory.CURSORS, ( uint ) InfoIndex.CURSOR.MINBUTTONS ); }
		}

		public static CursorCapabilities CursorCapabilities
		{
			get { return ( CursorCapabilities ) GetInfoUInt ( InfoCategory.CURSORS, ( uint ) InfoIndex.CURSOR.CAPABILITIES ); }
		}
	}

	public struct PacketEventArgs { public PACKET pkts; }
	public delegate void NewPacketsHandler ( PacketEventArgs e );
	public delegate void ButtonUpHandler ( PacketEventArgs e );
	public delegate void ButtonDownHandler ( PacketEventArgs e );
	public delegate void CursorMoveHandler ( PacketEventArgs e );
	public delegate void NPressureChangeHandler ( PacketEventArgs e );
	public delegate void CursorChangeHandler ( PacketEventArgs e );

	public class WinTabMessenger
	{
		public event NewPacketsHandler NewPackets;
		public event ButtonDownHandler ButtonDown;
		public event ButtonUpHandler ButtonUp;
		public event CursorMoveHandler CursorMove;
		public event NPressureChangeHandler NPressureChange;
		public event CursorChangeHandler CursorChange;

		public unsafe bool WndProc ( ref Message m )
		{
			switch ( m.Msg )
			{
				case WinTab.WT_PACKET:
					{
						PacketEventArgs e;
						WinTab.WTPacket ( m.LParam, ( uint ) m.WParam, &( e.pkts ) );

						if ( NewPackets != null ) { NewPackets ( e ); }

						switch ( ( RelativeButton ) e.pkts.pkButtons )
						{
							case RelativeButton.UP: if ( ButtonUp != null ) { ButtonUp ( e ); } break;
							case RelativeButton.DOWN: if ( ButtonDown != null ) { ButtonDown ( e ); } break;
						}

						if ( ( ( e.pkts.pkChanged & WTPKT.X ) |
							 ( e.pkts.pkChanged & WTPKT.Y ) ) != 0 )
						{ if ( CursorMove != null ) { CursorMove ( e ); } }

						if ( ( e.pkts.pkChanged & WTPKT.NORMAL_PRESSURE ) != 0 )
						{ if ( NPressureChange != null ) { NPressureChange ( e ); } }
						if ( ( e.pkts.pkChanged & WTPKT.CURSOR ) != 0 )
						{ if ( CursorChange != null ) { CursorChange ( e ); } }

						return true;
					}
			}
			return false;
		}
	};

	public enum RelativeField
	{
		None,
		Time,
		Position,
		Button,
		NPressure,
		TPressure
	};

	public class WinTabContext
	{
		private HCTX m_hCTX;
		private bool m_bEnabled;
		private LOGCONTEXT m_srLogContext;

		public WinTabContext () { m_hCTX = IntPtr.Zero; }
		public WinTabContext ( HCTX i ) { m_hCTX = i; }
		~WinTabContext () { if ( IsValid ) { Close (); } }
		public static explicit operator WinTabContext ( HCTX x ) { return new WinTabContext ( x ); }
		public static explicit operator HCTX ( WinTabContext x ) { return x.m_hCTX; }

		public unsafe WinTabContext Open ( IntPtr hWnd, bool bEnable )
		{
			fixed ( LOGCONTEXT* p = &m_srLogContext )
			{
				WinTab.WTInfo ( InfoCategory.DEFCONTEXT, 0, p );

				m_srLogContext.lcOptions = ContextOption.MESSAGES | ContextOption.SYSTEM | ContextOption.CSRMESSAGES;
				m_srLogContext.lcPktData = WinTab.WTPKT_ALL_WITHOUT_XY;
				m_srLogContext.lcPktMode = WTPKT.BUTTONS;
				m_srLogContext.lcSysMode = 0;

				m_hCTX = WinTab.WTOpen ( hWnd, p, Convert.ToInt32 ( bEnable ) );
			}
			m_bEnabled = bEnable;
			return this;
		}

		public void Close ()
		{
			if ( m_hCTX != IntPtr.Zero )
			{
				WinTab.WTClose ( m_hCTX );
				m_hCTX = IntPtr.Zero;
			}
			else
			{
				throw new Exception ( "Context is not initialized." );
			}
		}

		public bool Config ( IntPtr hWnd )
		{
			return WinTab.WTConfig ( m_hCTX, hWnd );
		}

		public bool Enabled
		{
			get { return m_bEnabled; }
			set
			{
				if ( m_bEnabled == value ) { return; }
				WinTab.WTEnable ( m_hCTX, Convert.ToInt32 ( value ) );
			}
		}

		public void Overlap ( bool bOverlap )
		{
			WinTab.WTOverlap ( m_hCTX, Convert.ToInt16 ( bOverlap ) );
		}

		public bool IsValid
		{
			get { return m_hCTX != IntPtr.Zero; }
		}
	};
}
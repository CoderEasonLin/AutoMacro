using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace AutoMacro
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);
        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();
        [DllImport("user32.dll")]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetClientRect(IntPtr hWnd, out RECT lpRect);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool ClientToScreen(IntPtr hWnd, ref Point lpPoint);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool ScreenToClient(IntPtr hWnd, ref Point lpPoint);


        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SendMessage(IntPtr hWnd, int message, int wParam, int lParam);

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;        // x position of upper-left corner  
            public int Top;         // y position of upper-left corner  
            public int Right;       // x position of lower-right corner  
            public int Bottom;      // y position of lower-right corner  
        }

        enum KeyModifier
        {
            None = 0,
            Alt = 1,
            Control = 2,
            Shift = 4,
            WinKey = 8
        }

        class TargetApplication
        {
            public string Title { get; set; }

            public int SizeX
            {
                get { return Rect.Right - Rect.Left; }
            }

            public int SizeY
            {
                get { return Rect.Bottom - Rect.Top; }
            }

            public IntPtr Handle { get; set; }
            public RECT Rect { get; set; }
        }

        private TargetApplication target = new TargetApplication();

        protected override void WndProc(ref Message message)
        {
            base.WndProc(ref message);

            if (message.Msg == 0x0312)
            {
                Keys key = (Keys)(((int)message.LParam >> 16) & 0xFFFF);                  // The key of the hotkey that was pressed.
                KeyModifier modifier = (KeyModifier)((int)message.LParam & 0xFFFF);       // The modifier of the hotkey that was pressed.
                int id = message.WParam.ToInt32();                                        // The id of the hotkey that was pressed.

                GetCurrentProcess();
            }
        }

        public Form1()
        {
            InitializeComponent();

            int id = 100;
            RegisterHotKey(Handle, id, (int)KeyModifier.Shift, Keys.A.GetHashCode());
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            int id = 100;
            UnregisterHotKey(Handle, id);
        }

        private void GetCurrentProcess()
        {
            
            var handle = GetForegroundWindow();
            int count = 255;
            var stringBuilder = new StringBuilder();
            GetWindowText(handle, stringBuilder, count);

            RECT rect;
            GetClientRect(handle, out rect);
            var mousePosition = MousePosition;
            var sb = new StringBuilder();

            target.Handle = handle;
            target.Title = stringBuilder.ToString();
            target.Rect = rect;

            ScreenToClient(target.Handle, ref mousePosition);
            position = mousePosition;

            sb.AppendFormat("Window Title: {0}\n", stringBuilder);
            sb.AppendFormat("Window Position: Top {0} Bottom {1} Left {2} Right {3}\n", rect.Top, rect.Bottom, rect.Left, rect.Right);
            sb.AppendFormat("Window Size: X {0} Y {1}\n", target.SizeX, target.SizeY);
            sb.AppendFormat("Current Mouse Position: X {0} Y {1}\n", mousePosition.X, mousePosition.Y);
            sb.AppendFormat("Current Mouse Position of window: X {0} Y {1}\n", mousePosition.X - rect.Left,
                mousePosition.Y - rect.Top);
            

            richTextBox1.Text = sb.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var proc = Process.GetCurrentProcess();

        }


        private Point position;
        private void button2_Click(object sender, EventArgs e)
        {
            int x = position.X;
            int y = position.Y;
            int pos = ((y << 0x10) | x);
            SendMessage(target.Handle, (int)0x201, 1, pos);
            SendMessage(target.Handle, (int)0x202, 0, pos);
        }
    }
}

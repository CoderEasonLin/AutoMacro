using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AutoMacro.Class;
using AutoMacro.Enum;

namespace AutoMacro
{
    public partial class Form1 : Form
    {
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
            Win32.RegisterHotKey(Handle, id, (int)KeyModifier.Shift, Keys.A.GetHashCode());
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            int id = 100;
            Win32.UnregisterHotKey(Handle, id);
        }

        private void GetCurrentProcess()
        {
            
            var handle = Win32.GetForegroundWindow();
            int count = 255;
            var stringBuilder = new StringBuilder();
            Win32.GetWindowText(handle, stringBuilder, count);

            RECT rect;
            Win32.GetClientRect(handle, out rect);
            var mousePosition = MousePosition;
            var sb = new StringBuilder();

            target.Handle = handle;
            target.Title = stringBuilder.ToString();
            target.Rect = rect;

            Win32.ScreenToClient(target.Handle, ref mousePosition);
            position = mousePosition;

            sb.AppendFormat("Window Title: {0}\n", stringBuilder);
            sb.AppendFormat("Window Position: Top {0} Bottom {1} Left {2} Right {3}\n", rect.Top, rect.Bottom, rect.Left, rect.Right);
            sb.AppendFormat("Window Size: X {0} Y {1}\n", target.SizeX, target.SizeY);
            sb.AppendFormat("Current Mouse Position: X {0} Y {1}\n", mousePosition.X, mousePosition.Y);
            sb.AppendFormat("Current Mouse Position of window: X {0} Y {1}\n", mousePosition.X - rect.Left,
                mousePosition.Y - rect.Top);
            

            richTextBox1.Text = sb.ToString();
        }

        private Point position;
        private void button2_Click(object sender, EventArgs e)
        {
            int x = position.X;
            int y = position.Y;
            int pos = ((y << 0x10) | x);
            Win32.SendMessage(target.Handle, (int)0x201, 1, pos);
            Win32.SendMessage(target.Handle, (int)0x202, 0, pos);
        }
    }
}

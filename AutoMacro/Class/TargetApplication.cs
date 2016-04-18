using System;
using System.Text;

namespace AutoMacro.Class
{
    public class TargetApplication
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
        public RECT ClientRect { get; set; }

        public TargetApplication()
        {
            Handle = Win32.GetForegroundWindow();

            int count = 255;
            var stringBuilder = new StringBuilder(count);
            Win32.GetWindowText(Handle, stringBuilder, count);
            Title = stringBuilder.ToString();

            RECT clientRect, rect;
            Win32.GetClientRect(Handle, out clientRect);
            Win32.GetWindowRect(Handle, out rect);
            ClientRect = clientRect;
            Rect = rect;
        }
    }
}
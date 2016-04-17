using System;

namespace AutoMacro.Class
{
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
}
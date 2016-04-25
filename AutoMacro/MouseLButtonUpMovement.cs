using System;
using AutoMacro.Class;
using AutoMacro.Enum;

namespace AutoMacro
{
    public class MouseLButtonUpMovement : Movement
    {
        public int X { get; set; }
        public int Y { get; set; }

        public MouseLButtonUpMovement(IntPtr handle) : base(handle)
        {
            Type = MovementType.MouseLButtonUp;
        }

        public override void Do()
        {
            int pos = ((Y << 0x10) | X);
            Win32.SendMessage(Handle, 0x202, 0, pos);
        }
    }
}
using System;
using AutoMacro.Class;
using AutoMacro.Enum;

namespace AutoMacro
{
    public class MouseLButtonDownMovement : Movement
    {
        public int X { get; set; }
        public int Y { get; set; }
        
        public MouseLButtonDownMovement(IntPtr handle) : base(handle)
        {
            Type = MovementType.MouseLButtonDown;
        }

        public override void Do()
        {
            int pos = ((Y << 0x10) | X);
            Win32.SendMessage(Handle, 0x201, 1, pos);
        }
    }
}
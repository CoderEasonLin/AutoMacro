using System;
using AutoMacro.Class;
using AutoMacro.Enum;

namespace AutoMacro
{
    public class MousePositionMovement : Movement
    {
        public MousePositionMovement(IntPtr handle) : base(handle)
        {
            Type = MovementType.MousePosition;
        }

        public int X { get; set; }
        public int Y { get; set; }

        public override void Do()
        {
            throw new NotImplementedException();
        }
    }
}
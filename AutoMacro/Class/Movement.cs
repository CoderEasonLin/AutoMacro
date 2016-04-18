using System;
using AutoMacro.Enum;

namespace AutoMacro.Class
{
    public class Movement
    {
        public Movement(IntPtr handle)
        {
            Handle = handle;
        }

        public IntPtr Handle { get; set; }
        public MovementType Type { get; set; }
    }
}
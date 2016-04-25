using System;
using AutoMacro.Enum;

namespace AutoMacro.Class
{
    public abstract class Movement
    {
        protected Movement(IntPtr handle)
        {
            Handle = handle;
        }

        public IntPtr Handle { get; set; }
        public MovementType Type { get; set; }

        public abstract void Do();
    }
}
using System;
using System.Threading;
using AutoMacro.Class;

namespace AutoMacro
{
    public class SleepMovement : Movement
    {
        public int Millisecond { get; set; }

        public SleepMovement(IntPtr handle) : base(handle)
        {
        }

        public override void Do()
        {
            Thread.Sleep(Millisecond);
        }
    }
}
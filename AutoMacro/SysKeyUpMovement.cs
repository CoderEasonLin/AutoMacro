using System;
using AutoMacro.Class;
using AutoMacro.Enum;

namespace AutoMacro
{
    public class SysKeyUpMovement : Movement
    {
        public VirtualKey Key { get; set; }

        public SysKeyUpMovement(IntPtr handle) : base(handle)
        {
            Type = MovementType.SysKeyUp;
        }
        
        public override void Do()
        {
            Win32.SendMessage(Handle, WindowsMessage.WM_SYSKEYUP.GetHashCode(), Key.GetHashCode(), 0);
        }
    }
}
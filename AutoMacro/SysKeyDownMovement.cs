using System;
using AutoMacro.Class;
using AutoMacro.Enum;

namespace AutoMacro
{
    internal class SysKeyDownMovement : Movement
    {
        public VirtualKey Key { get; set; }

        public SysKeyDownMovement(IntPtr handle) : base(handle)
        {
            Type = MovementType.SysKeyDown;
        }

        public override void Do()
        {
            Win32.SendMessage(Handle, WindowsMessage.WM_SYSKEYDOWN.GetHashCode(), Key.GetHashCode(), 0);
        }
    }
}
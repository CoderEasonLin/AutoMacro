using System;
using System.Windows.Forms;
using AutoMacro.Class;
using AutoMacro.Enum;

namespace AutoMacro
{
    public class KeyDownMovement : Movement
    {
        public Keys Key { get; set; }

        public KeyDownMovement(IntPtr handle) : base(handle)
        {
            Type = MovementType.KeyDown;
        }

        public override void Do()
        {
            Win32.SendMessage(Handle, WindowsMessage.WM_KEYDOWN.GetHashCode(), Key.GetHashCode(), 0);
        }
    }
}
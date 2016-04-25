using System;
using System.Windows.Forms;
using AutoMacro.Class;
using AutoMacro.Enum;

namespace AutoMacro
{
    public class KeyUpMovement : Movement
    {
        public Keys Key { get; set; }

        public KeyUpMovement(IntPtr handle) : base(handle)
        {
            Type = MovementType.KeyUp;
        }

        public override void Do()
        {
            Win32.SendMessage(Handle, WindowsMessage.WM_KEYUP.GetHashCode(), Key.GetHashCode(), 0);
        }
    }
}
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using AutoMacro.Class;

namespace AutoMacro
{
    public class KeyDownRule : CodeRule
    {
        public KeyDownRule()
        {
            Regex = new Regex("^KEY DOWN (\\S)$");
        }

        public override Movement GetMovement(string line, IntPtr handle)
        {
            var list = Regex.Split(line);
            var key = list[1];
            return new KeyDownMovement(handle)
            {
                Key = (Keys)System.Enum.Parse(typeof(Keys), key, true)
            };
        }
    }
}
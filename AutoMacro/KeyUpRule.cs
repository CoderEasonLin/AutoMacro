using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using AutoMacro.Class;

namespace AutoMacro
{
    public class KeyUpRule : CodeRule
    {
        public KeyUpRule()
        {
            Regex = new Regex("^KEY UP (\\S)$");
        }

        public override Movement GetMovement(string line, IntPtr handle)
        {
            var list = Regex.Split(line);
            var key = list[1];

            return new KeyUpMovement(handle)
            {
                Key = (Keys)System.Enum.Parse(typeof(Keys), key, true)
            };
        }
    }
}
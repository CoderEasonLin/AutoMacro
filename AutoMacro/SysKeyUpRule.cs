using System;
using System.Text.RegularExpressions;
using AutoMacro.Class;
using AutoMacro.Enum;

namespace AutoMacro
{
    public class SysKeyUpRule : CodeRule
    {
        public SysKeyUpRule()
        {
            Regex = new Regex("^KEY UP (CTRL|ALT|SHIFT)$");
        }

        public override Movement GetMovement(string line, IntPtr handle)
        {
            var list = Regex.Split(line);
            var key = list[1];

            return new SysKeyUpMovement(handle)
            {
                Key = (VirtualKey)System.Enum.Parse(typeof(VirtualKey), key, true)
            };
        }
    }
}
using System;
using System.Text.RegularExpressions;
using AutoMacro.Class;
using AutoMacro.Enum;

namespace AutoMacro
{
    public class SysKeyDownRule : CodeRule
    {
        public SysKeyDownRule()
        {
            Regex = new Regex("^KEY DOWN (CTRL|ALT|SHIFT)$");
        }

        public override Movement GetMovement(string line, IntPtr handle)
        {
            var list = Regex.Split(line);
            var key = list[1];

            return new SysKeyDownMovement(handle)
            {
                Key = (VirtualKey)System.Enum.Parse(typeof(VirtualKey), key, true)
            };
        }
    }
}
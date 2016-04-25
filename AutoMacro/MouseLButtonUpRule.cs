using System;
using System.Text.RegularExpressions;
using AutoMacro.Class;

namespace AutoMacro
{
    public class MouseLButtonUpRule : CodeRule
    {
        public MouseLButtonUpRule()
        {
            Regex = new Regex("^MOUSE L BUTTON UP (\\d+) (\\d+)$");
        }

        public override Movement GetMovement(string line, IntPtr handle)
        {
            var list = Regex.Split(line);
            return new MouseLButtonUpMovement(handle)
            {
                X = Convert.ToInt32(list[1]),
                Y = Convert.ToInt32(list[2])
            };
        }
    }
}
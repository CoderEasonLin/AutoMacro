using System;
using System.Text.RegularExpressions;
using AutoMacro.Class;

namespace AutoMacro
{
    public class MouseLButtonDownRule : CodeRule
    {
        public MouseLButtonDownRule()
        {
            Regex = new Regex("^MOUSE L BUTTON DOWN (\\d+) (\\d+)$");
        }

        public override Movement GetMovement(string line, IntPtr handle)
        {
            var list = Regex.Split(line);
            return new MouseLButtonDownMovement(handle)
            {
                X = Convert.ToInt32(list[1]),
                Y = Convert.ToInt32(list[2])
            };
        }
    }
}
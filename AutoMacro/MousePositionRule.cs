using System;
using System.Text.RegularExpressions;
using AutoMacro.Class;

namespace AutoMacro
{
    public class MousePositionRule : CodeRule
    {
        public MousePositionRule()
        {
            Regex = new Regex("^MOUSE POS (\\d+) (\\d+)$");
        }

        public override Movement GetMovement(string line, IntPtr handle)
        {
            var list = Regex.Split(line);

            var movement = new MousePositionMovement(handle)
            {
                X = Convert.ToInt32(list[1]),
                Y = Convert.ToInt32(list[2])
            };
            return movement;
        }
    }
}
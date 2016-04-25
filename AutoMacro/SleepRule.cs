using System;
using System.Text.RegularExpressions;
using AutoMacro.Class;

namespace AutoMacro
{
    public class SleepRule : CodeRule
    {
        public SleepRule()
        {
            Regex = new Regex("^SLEEP (\\d+)$");
        }

        public override Movement GetMovement(string line, IntPtr handle)
        {
            var list = Regex.Split(line);
            var millisecond = Convert.ToInt32(list[1]);
            return new SleepMovement(handle)
            {
                Millisecond = millisecond
            };
        }
    }
}
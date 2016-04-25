using System;
using System.Text.RegularExpressions;
using AutoMacro.Class;

namespace AutoMacro
{
    public abstract class CodeRule
    {
        protected Regex Regex;

        public virtual bool IsMatch(string line)
        {
            return Regex.IsMatch(line);
        }

        public abstract Movement GetMovement(string line, IntPtr handle);
    }
}
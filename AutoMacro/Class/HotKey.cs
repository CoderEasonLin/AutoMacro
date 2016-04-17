using System;
using System.Windows.Forms;
using AutoMacro.Enum;

namespace AutoMacro.Class
{
    public class HotKey
    {
        public int Id { get; set; }
        public KeyModifier KeyModifier { get; set; }
        public int VKey { get; set; }
        public Action Action { get; set; }

        public HotKey(int id, KeyModifier keyModifier, Keys vKey, Action action)
        {
            Id = id;
            KeyModifier = keyModifier;
            VKey = vKey.GetHashCode();
            Action = action;
        }

        
    }
}
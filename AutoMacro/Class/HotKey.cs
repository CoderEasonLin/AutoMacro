using AutoMacro.Enum;

namespace AutoMacro.Class
{
    public class HotKey
    {
        public string Title { get; set; }
        public int Id { get; set; }
        public KeyModifier KeyModifier { get; set; }
        public int VKey { get; set; }

        public HotKey(int id, KeyModifier keyModifier, int vKey, string title)
        {
            Id = id;
            KeyModifier = keyModifier;
            VKey = vKey;
            Title = title;
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoMacro.Class;
using AutoMacro.Enum;

namespace AutoMacro
{
    public partial class AutoMacro : Form
    {
        private List<HotKey> hotKeys = new List<HotKey>();

        public AutoMacro()
        {
            InitializeComponent();

            InitializeHotKey();
            RegisterHotKey();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            UnRegisterHotKey();
        }

        private void InitializeHotKey()
        {
            hotKeys.Add(new HotKey(100, KeyModifier.Control, Keys.NumPad1.GetHashCode(), "Select window"));
            hotKeys.Add(new HotKey(101, KeyModifier.Control, Keys.NumPad2.GetHashCode(), "Get mouse position"));
        }

        private void UnRegisterHotKey()
        {
            foreach (var hotKey in hotKeys)
            {
                Win32.UnregisterHotKey(Handle, hotKey.Id);
            }
        }

        private void RegisterHotKey()
        {
            foreach (var hotKey in hotKeys)
            {
                Win32.RegisterHotKey(Handle, hotKey.Id, (int) hotKey.KeyModifier, hotKey.VKey);
            }
        }
    }
}

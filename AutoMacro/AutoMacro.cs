using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using AutoMacro.Class;
using AutoMacro.Enum;

namespace AutoMacro
{
    public partial class AutoMacro : Form
    {
        private List<HotKey> hotKeys = new List<HotKey>();
        private TargetApplication target;

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
            hotKeys.Add(new HotKey(100, KeyModifier.Control, Keys.D1, SelectWindow));
            hotKeys.Add(new HotKey(101, KeyModifier.Control, Keys.D2, GetMousePosition));
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
                Win32.RegisterHotKey(Handle, hotKey.Id, (int)hotKey.KeyModifier, hotKey.VKey);
            }
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == WM.HOTKEY)
            {
                int id = m.WParam.ToInt32();
                CallHotKeyAction(id);
            }
        }

        private void CallHotKeyAction(int id)
        {
            var hotkey = hotKeys.Single(x => x.Id == id);
            hotkey.Action();
        }

        private void SelectWindow()
        {
            target = new TargetApplication();
        }

        private void GetMousePosition()
        {
            Point mousePosition = MousePosition;
            Win32.ScreenToClient(target.Handle, ref mousePosition);
            txtMacro.AppendText(string.Format("MOUSE POS {0} {1}\n", mousePosition.X, mousePosition.Y));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder(txtMacro.Text);
            MacroCompiler compiler = new MacroCompiler(sb);
        }
    }

    public class MacroCompiler
    {
        public Regex MousePosition = new Regex("^MOUSE POS (\\d+) (\\d+)$");
        public Regex FuncStart = new Regex("FUNC ");

        public MacroCompiler(StringBuilder sb)
        {
            
        }

        public MacroAction Compile()
        {
            throw new NotImplementedException();
        }
    }

    public class MacroAction
    {
        public List<Class.Action> Actions { get; set; }
    }
}
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
            txtCode.AppendText(string.Format("MOUSE POS {0} {1}\n", mousePosition.X, mousePosition.Y));
        }

        private void buttonRun_Click(object sender, EventArgs e)
        {
            StringBuilder code = new StringBuilder(txtCode.Text);
            MacroCompiler compiler = new MacroCompiler(code, target);
        }
    }

    public class MacroCompiler
    {
        public List<Regex> Regexes { get; set; }

        public Regex MousePosition = new Regex("^MOUSE POS (\\d+) (\\d+)$");
        public Regex FuncStart = new Regex("FUNC ");

        public StringBuilder Code { get; set; }
        public TargetApplication TargetApplication { get; set; }

        public MacroCompiler(StringBuilder code, TargetApplication targetApplication)
        {
            InitialRegex();
            Code = code;
            TargetApplication = targetApplication;
        }

        private void InitialRegex()
        {
            throw new NotImplementedException();
        }

        public Macro Compile()
        {
            throw new NotImplementedException();
        }
    }

    public abstract class CodeRule
    {
        protected Regex Regex;

        public virtual bool IsMatch(string line)
        {
            return Regex.IsMatch(line);
        }

        public abstract Movement GetMovement(string line, IntPtr handle);
    }

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

    public class MousePositionMovement : Movement
    {
        public MousePositionMovement(IntPtr handle) : base(handle)
        {
            Type = MovementType.MousePosition;
        }

        public int X { get; set; }
        public int Y { get; set; }

        public void Do()
        {
            
        }
    }


    public class Macro
    {
        public List<Movement> Movements { get; set; }
    }
}
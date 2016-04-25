using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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
            if (m.Msg == WindowsMessage.WM_HOTKEY.GetHashCode())
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
            MacroCompiler compiler = new MacroCompiler(txtCode.Lines.ToList(), target);
            var macro = compiler.Compile();
            macro.Run();
        }
    }

    public class MacroCompiler
    {
        public List<Regex> Regexes { get; set; }
        public List<CodeRule> CodeRules { get; set; }

        public List<string> Codes { get; set; }
        public TargetApplication TargetApplication { get; set; }

        public MacroCompiler(List<string> code, TargetApplication targetApplication)
        {
            InitialCodeRules();
            Codes = code;
            TargetApplication = targetApplication;
        }

        private void InitialCodeRules()
        {
            CodeRules = new List<CodeRule>();
            CodeRules.Add(new MousePositionRule());
            CodeRules.Add(new MouseLButtonDownRule());
            CodeRules.Add(new MouseLButtonUpRule());
            CodeRules.Add(new SleepRule());
            CodeRules.Add(new KeyDownRule());
            CodeRules.Add(new KeyUpRule());
            CodeRules.Add(new SysKeyDownRule());
            CodeRules.Add(new SysKeyUpRule());
            CodeRules.Add(new FuncStartRule());
            CodeRules.Add(new FuncEndRule());
            CodeRules.Add(new FuncCallRule());
            //CodeRules.Add(new ForLoopStartRule());
            //CodeRules.Add(new ForLoopEndRule());
        }

        public Macro Compile()
        {
            var macro = new Macro();
            ExtractFunctionCodes();
            ExtractForLoopCodes();
            ExtractCodes();
            foreach (var code in Codes)
            {
                foreach (var codeRule in CodeRules)
                {
                    if (codeRule.IsMatch(code))
                    {
                        macro.Movements.Add(codeRule.GetMovement(code, TargetApplication.Handle));
                    }
                }
            }
            return macro;
        }
    }

    internal class FuncStartRule : CodeRule
    {
        public FuncStartRule()
        {
            Regex = new Regex("^Func (\\w+)$");
        }

        public override Movement GetMovement(string line, IntPtr handle)
        {
            throw new NotImplementedException();
        }
    }
}
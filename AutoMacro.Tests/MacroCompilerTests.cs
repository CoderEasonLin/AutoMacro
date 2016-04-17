using System.Text;
using AutoMacro.Class;
using AutoMacro.Enum;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutoMacro.Tests
{
    [TestClass]
    public class MacroCompilerTests
    {
        [TestMethod]
        public void MacroCompilerTest()
        {
            //Assert.Fail();
        }

        [TestMethod]
        public void MousePositionShouldCorrect()
        {
            // Arrange
            var macro = "MOUSE POS 123 456\n";
            var sb = new StringBuilder(macro);

            // Act
            var macroCompiler = new MacroCompiler(sb);
            var macroAction = macroCompiler.Compile();

            // Assert
            Assert.AreEqual(1, macroAction.Actions.Count);
            var action = macroAction.Actions[0];
            Assert.AreEqual(ActionType.MousePosition, action);
            Assert.AreEqual(123, action.X);
            Assert.AreEqual(456, action.Y);
        }
    }
}
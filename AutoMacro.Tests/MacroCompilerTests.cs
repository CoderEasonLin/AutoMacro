using System.Collections.Generic;
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
            var code = "MOUSE POS 123 456\n";
            var sb = new List<string> { code };
            var target = new TargetApplication();

            // Act
            var macroCompiler = new MacroCompiler(sb, target);
            var macro = macroCompiler.Compile();

            // Assert
            Assert.AreEqual(1, macro.Movements.Count);
            var movement = macro.Movements[0] as MousePositionMovement;
            Assert.IsNotNull(movement);
            Assert.AreEqual(MovementType.MousePosition, movement.Type);
            Assert.AreEqual(123, movement.X);
            Assert.AreEqual(456, movement.Y);
        }
    }
}
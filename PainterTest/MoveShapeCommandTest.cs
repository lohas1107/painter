using Painter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Drawing;

namespace PainterTest
{
    /// <summary>
    ///This is a test class for MoveShapeCommandTest and is intended
    ///to contain all MoveShapeCommandTest Unit Tests
    ///</summary>
    [TestClass()]
    public class MoveShapeCommandTest
    {
        MoveShapeCommand_Accessor _moveShapeCommandTarget;
        Shape _rectangle;

        [TestInitialize()]
        public void Initialize()
        {
            Point startPoint = new Point(10, 10);
            Point endPoint = new Point(20, 20);
            _rectangle = ShapeFactory.CreatShape(Mode.Rectangle, startPoint, endPoint);
            _moveShapeCommandTarget = new MoveShapeCommand_Accessor(_rectangle, new Point(10, 10));
        }

        /// <summary>
        ///A test for Execute
        ///</summary>
        [TestMethod()]
        public void ExecuteTest()
        {
            _moveShapeCommandTarget.Execute();
            Assert.IsTrue(_rectangle.StartPosition == new Point(20, 20));
            
        }

        /// <summary>
        ///A test for Undo
        ///</summary>
        [TestMethod()]
        public void UndoTest()
        {
            _moveShapeCommandTarget.Undo();
            Assert.IsTrue(_rectangle.StartPosition == new Point(0, 0));
        }
    }
}

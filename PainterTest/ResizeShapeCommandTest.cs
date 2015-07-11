using Painter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Drawing;

namespace PainterTest
{
    /// <summary>
    ///This is a test class for ResizeShapeCommandTest and is intended
    ///to contain all ResizeShapeCommandTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ResizeShapeCommandTest
    {
        ResizeShapeCommand_Accessor _resizeShapeCommandTarget;
        Shape _rectangle;

        [TestInitialize()]
        public void Initialize()
        {
            Point startPoint = new Point(10, 10);
            Point endPoint = new Point(20, 20);
            _rectangle = ShapeFactory.CreatShape(Mode.Rectangle, startPoint, endPoint);
            _resizeShapeCommandTarget = new ResizeShapeCommand_Accessor(_rectangle, new Point(-5, -5), new Point(5, 5));
        }

        /// <summary>
        ///A test for Execute
        ///</summary>
        [TestMethod()]
        public void ExecuteTest()
        {
            _resizeShapeCommandTarget.Execute();
            Assert.AreEqual(new Point(5, 5), _resizeShapeCommandTarget._startPoint);
            Assert.AreEqual(15, _resizeShapeCommandTarget._resizeShape.Width);
            Assert.AreEqual(15, _resizeShapeCommandTarget._resizeShape.Height);
        }

        /// <summary>
        ///A test for Undo
        ///</summary>
        [TestMethod()]
        public void UndoTest()
        {
            _resizeShapeCommandTarget.Undo();
            Assert.AreEqual(new Point(15, 15), _resizeShapeCommandTarget._startPoint);
            Assert.AreEqual(5, _resizeShapeCommandTarget._resizeShape.Width);
            Assert.AreEqual(5, _resizeShapeCommandTarget._resizeShape.Height);
        }
    }
}

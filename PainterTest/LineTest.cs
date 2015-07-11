using Painter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Drawing;

namespace PainterTest
{
    /// <summary>
    ///This is a test class for LineTest and is intended
    ///to contain all LineTest Unit Tests
    ///</summary>
    [TestClass()]
    public class LineTest
    {
        /// <summary>
        ///A test for Contains
        ///</summary>

        Shape _target;

        [TestInitialize()]
        public void Initialize()
        {
            _target = ShapeFactory.CreatShape(Mode.Line, new Point(10, 10), new Point(20, 20));
        }

        [TestMethod()]
        public void ContainsTest()
        {
            Point pointIn = new Point(15, 15);
            Assert.IsTrue(_target.Contains(pointIn));
            Point pointOut = new Point(30, 30);
            Assert.IsFalse(_target.Contains(pointOut));
        }
    }
}

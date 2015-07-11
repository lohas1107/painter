using Painter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Drawing;

namespace PainterTest
{   
    /// <summary>
    ///This is a test class for RectangleTest and is intended
    ///to contain all RectangleTest Unit Tests
    ///</summary>
    [TestClass()]
    public class RectangleTest
    {
        Shape _target;

        [TestInitialize()]
        public void Initialize()
        {
            Point start = new Point(10, 10);
            Point end= new Point(20, 20);
            _target = ShapeFactory.CreatShape(Mode.Rectangle, start, end);
        }

        /// <summary>
        ///A test for Contains
        ///</summary>
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

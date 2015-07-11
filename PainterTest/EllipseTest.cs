using Painter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Drawing;

namespace PainterTest
{


    /// <summary>
    ///This is a test class for EllipseTest and is intended
    ///to contain all EllipseTest Unit Tests
    ///</summary>
    [TestClass()]
    public class EllipseTest
    {
        Shape _target;

        [TestInitialize]
        public void Initialize()
        {
            _target = ShapeFactory.CreatShape(Mode.Ellipse, new Point(10, 10), new Point(20, 20));
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

using Painter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Drawing;

namespace PainterTest
{
    
    
    /// <summary>
    ///This is a test class for ShapeFactoryTest and is intended
    ///to contain all ShapeFactoryTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ShapeFactoryTest
    {

        /// <summary>
        ///A test for CreatShape
        ///</summary>
        [TestMethod()]
        public void CreatShapeTest()
        {
            Point startPosition = new Point(10, 10); // TODO: Initialize to an appropriate value
            Point endPosition = new Point(20, 20); // TODO: Initialize to an appropriate value
            Shape actual;
            actual = ShapeFactory.CreatShape(Mode.Pointer, startPosition, endPosition);
            Assert.AreEqual(null, actual);
            actual = ShapeFactory.CreatShape(Mode.Rectangle, startPosition, endPosition);
            Assert.IsNotNull(actual);
            actual = ShapeFactory.CreatShape(Mode.Ellipse, startPosition, endPosition);
            Assert.IsNotNull(actual);
            actual = ShapeFactory.CreatShape(Mode.Line, startPosition, endPosition);
            Assert.IsNotNull(actual);
            actual = ShapeFactory.CreatShape(Mode.Line + 1, startPosition, endPosition);
            Assert.IsNull(actual);
        }
    }
}

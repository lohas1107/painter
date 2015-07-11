using Painter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Drawing;

namespace PainterTest
{  
    /// <summary>
    ///This is a test class for ShapeListTest and is intended
    ///to contain all ShapeListTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ShapeListTest
    {
        ShapeList_Accessor _shapeListTarget;

        [TestInitialize()]
        public void Initialize()
        {
            _shapeListTarget = new ShapeList_Accessor();
        }

        /// <summary>
        ///A test for AddShape
        ///</summary>
        [TestMethod()]
        public void AddShapeTest()
        {
            Point startPoint = new Point(10, 10);
            Point endPoint = new Point(20, 20);
            Shape rectangle = ShapeFactory.CreatShape(Mode.Rectangle, startPoint, endPoint);
            _shapeListTarget.AddShape(rectangle);
            Assert.AreEqual(1, _shapeListTarget._shapeList.Count);
        }

        [TestMethod()]
        public void DeleteShapeTest()
        {
            Point startPoint = new Point(10, 10);
            Point endPoint = new Point(20, 20);
            Shape rectangle = ShapeFactory.CreatShape(Mode.Rectangle, startPoint, endPoint);
            _shapeListTarget.AddShape(rectangle);
            Assert.AreEqual(1, _shapeListTarget._shapeList.Count);
            _shapeListTarget.DeleteShape(rectangle);
            Assert.AreEqual(0, _shapeListTarget._shapeList.Count);
        }

        [TestMethod()]
        public void IndexOfTest()
        {
            Point startPoint = new Point(10, 10);
            Point endPoint = new Point(20, 20);
            Shape rectangle = ShapeFactory.CreatShape(Mode.Rectangle, startPoint, endPoint);
            _shapeListTarget.AddShape(rectangle);
            int index = _shapeListTarget.GetIndex(rectangle);
            Assert.AreEqual(0, index);
        }

        [TestMethod()]
        public void InsertShapeTest()
        {
            Point startPoint = new Point(10, 10);
            Point endPoint = new Point(20, 20);
            Shape rectangle = ShapeFactory.CreatShape(Mode.Rectangle, startPoint, endPoint);
            Shape ellipse = ShapeFactory.CreatShape(Mode.Ellipse, startPoint, endPoint);
            _shapeListTarget.AddShape(rectangle);
            _shapeListTarget.InsertShape(0, ellipse);
            int index = _shapeListTarget.GetIndex(ellipse);
            Assert.AreEqual(0, index);
            Assert.AreEqual(2, _shapeListTarget._shapeList.Count);
        }

        /// <summary>
        ///A test for Contains
        ///</summary>
        [TestMethod()]
        public void ContainsTest()
        {
            Point startPoint = new Point(10, 10);
            Point endPoint = new Point(20, 20);
            Shape rectangle = ShapeFactory.CreatShape(Mode.Rectangle, startPoint, endPoint);
            _shapeListTarget.AddShape(rectangle);
            Assert.IsNull(_shapeListTarget.Contains(true, new Point(5, 5)));
            Assert.IsNotNull(_shapeListTarget.Contains(true, new Point(15, 15)));
        }
    }
}

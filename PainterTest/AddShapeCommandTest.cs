using Painter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Drawing;

namespace PainterTest
{  
    /// <summary>
    ///This is a test class for AddShapeCommandTest and is intended
    ///to contain all AddShapeCommandTest Unit Tests
    ///</summary>
    [TestClass()]
    public class AddShapeCommandTest
    {
        AddShapeCommand_Accessor _addShapeCommandTarget;
        ShapeModel _shapeModel;
        Shape _rectangle;

        [TestInitialize()]
        public void Initialize()
        {
            _shapeModel = new ShapeModel();
            _shapeModel.CursorChange += InvokeTest;
            _shapeModel.ScreenChange += InvokeTest;
            _shapeModel.StripChange += InvokeTest;
            Point startPoint = new Point(10, 10);
            Point endPoint = new Point(20, 20);
            _rectangle = ShapeFactory.CreatShape(Mode.Rectangle, startPoint, endPoint);
            _addShapeCommandTarget = new AddShapeCommand_Accessor(_rectangle, _shapeModel);

        }

        public void InvokeTest(CursorType type)
        {
        }

        public void InvokeTest()
        {
        }

        /// <summary>
        ///A test for Execute
        ///</summary>
        [TestMethod()]
        public void ExecuteTest()
        {
            _addShapeCommandTarget.Execute();
            Assert.AreEqual(false, _rectangle.IsSelect);
        }

        /// <summary>
        ///A test for Undo
        ///</summary>
        [TestMethod()]
        public void UndoTest()
        {
            _shapeModel.SelectedShape = _rectangle;
            _addShapeCommandTarget.Undo();
            Assert.AreEqual(false, _rectangle.IsSelect);
        }
    }
}

using Painter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Drawing;

namespace PainterTest
{   
    /// <summary>
    ///This is a test class for DeleteShapeCommandTest and is intended
    ///to contain all DeleteShapeCommandTest Unit Tests
    ///</summary>
    [TestClass()]
    public class DeleteShapeCommandTest
    {
        DeleteShapeCommand_Accessor _deleteCommandTarget;
        Shape _rectangle;
        ShapeModel _shapeModel;

        [TestInitialize()]
        public void Initialize()
        {
            Point startPoint = new Point(10, 10);
            Point endPoint = new Point(20, 20);
            _rectangle = ShapeFactory.CreatShape(Mode.Rectangle, startPoint, endPoint);
            _shapeModel = new ShapeModel();
            _deleteCommandTarget = new DeleteShapeCommand_Accessor(_rectangle, _shapeModel);
            _shapeModel.CursorChange += InvokeTest;
            _shapeModel.ScreenChange += InvokeTest;
            _shapeModel.StripChange += InvokeTest;
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
            _shapeModel.SelectedShape = _rectangle;
            _rectangle.IsSelect = true;
            Assert.AreEqual(0, _deleteCommandTarget._shapeIndex);
            _deleteCommandTarget.Execute();
            Assert.AreEqual(-1, _deleteCommandTarget._shapeIndex);
        }

        /// <summary>
        ///A test for Undo
        ///</summary>
        [TestMethod()]
        public void UndoTest()
        {
            _shapeModel.SelectedShape = _rectangle;
            _deleteCommandTarget.Undo();
            Assert.AreEqual(0, _deleteCommandTarget._shapeIndex);
        }
    }
}

using Painter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PainterTest
{

    /// <summary>
    ///This is a test class for PresentationModelTest and is intended
    ///to contain all PresentationModelTest Unit Tests
    ///</summary>
    [TestClass()]
    public class PresentationModelTest
    {
        PresentationModel_Accessor _presentationModelTarget;
        //AddShapeCommand _addShapeCommand;
        //ShapeModel _shapeModel;
        //Shape _rectangle;

        [TestInitialize()]
        public void Initialize()
        {
            _presentationModelTarget = new PresentationModel_Accessor(new ShapeModel());
            _presentationModelTarget.add_CursorChange(InvokeTest);
            _presentationModelTarget.add_StripChange(InvokeTest);
            _presentationModelTarget.add_ScreenChange(InvokeTest);

            //_shapeModel = new ShapeModel();
            //Point startPoint = new Point(10, 10);
            //Point endPoint = new Point(20, 20);
            //_rectangle = ShapeFactory.CreatShape(Mode.Rectangle, startPoint, endPoint);
            //_addShapeCommand = new AddShapeCommand(_rectangle, _shapeModel);
            //_addShapeCommand.Execute();
        }

        public void InvokeTest(Cursor cursor)
        {
        }

        public void InvokeTest()
        {
        }

        [TestMethod()]
        public void ClickUndoMenuItemTest()
        {
            Point point = new Point(15, 15);
            Point point2 = new Point(55, 55);
            _presentationModelTarget._shapeModel.SelectedMode = Mode.Rectangle;
            _presentationModelTarget._shapeModel.MoveMouse(point);
            _presentationModelTarget._shapeModel.ClickMouseDown(point);
            _presentationModelTarget._shapeModel.MoveMouse(point2);
            _presentationModelTarget._shapeModel.ClickMouseUp(point2);
            
            _presentationModelTarget.ClickUndoMenuItem();
            Assert.IsFalse(_presentationModelTarget.UndoMenuItemEnable);
        }

        [TestMethod()]
        public void ClickRedoMenuItemTest()
        {
            Point point = new Point(15, 15);
            Point point2 = new Point(55, 55);
            _presentationModelTarget._shapeModel.SelectedMode = Mode.Rectangle;
            _presentationModelTarget._shapeModel.MoveMouse(point);
            _presentationModelTarget._shapeModel.ClickMouseDown(point);
            _presentationModelTarget._shapeModel.MoveMouse(point2);
            _presentationModelTarget._shapeModel.ClickMouseUp(point2);

            _presentationModelTarget.ClickUndoMenuItem();
            _presentationModelTarget.ClickRedoMenuItem();
            Assert.IsFalse(_presentationModelTarget.RedoMenuItemEnable);
        }

        [TestMethod()]
        public void ClickDeleteMenuItemTest()
        {
            Point point = new Point(15, 15);
            Point point2 = new Point(55, 55);
            Point insidePoint = new Point(30, 30);
            _presentationModelTarget._shapeModel.SelectedMode = Mode.Rectangle;
            _presentationModelTarget._shapeModel.MoveMouse(point);
            _presentationModelTarget._shapeModel.ClickMouseDown(point);
            _presentationModelTarget._shapeModel.MoveMouse(point2);
            _presentationModelTarget._shapeModel.ClickMouseUp(point2);

            _presentationModelTarget._shapeModel.SelectedMode = Mode.Pointer;
            _presentationModelTarget._shapeModel.MoveMouse(insidePoint);
            _presentationModelTarget._shapeModel.ClickMouseDown(insidePoint);
            _presentationModelTarget._shapeModel.MoveMouse(insidePoint);
            _presentationModelTarget._shapeModel.ClickMouseUp(insidePoint);

            _presentationModelTarget.ClickDeleteMenuItem();
            Assert.IsFalse(_presentationModelTarget.DeleteMenuItemEnable);
        }

        /// <summary>
        ///A test for ClickEllipseMenuItem
        ///</summary>
        [TestMethod()]
        public void ClickEllipseMenuItemTest()
        {
            _presentationModelTarget.ClickEllipseMenuItem();
            Assert.IsFalse(_presentationModelTarget.EllipseMenuItemEnable);
        }

        /// <summary>
        ///A test for ClickLineMenuItem
        ///</summary>
        [TestMethod()]
        public void ClickLineMenuItemTest()
        {
            _presentationModelTarget.ClickLineMenuItem();
            Assert.IsFalse(_presentationModelTarget.LineMenuItemEnable);
        }

        /// <summary>
        ///A test for ClickMouseDown
        ///</summary>
        [TestMethod()]
        public void ClickMouseDownTest()
        {
            Point point = new Point(10, 10);
            MouseButtons mouseButton = MouseButtons.Left;
            _presentationModelTarget.ClickMouseDown(point, mouseButton);
            Assert.IsTrue(_presentationModelTarget._shapeModel.Cursor == CursorType.Default);
        }

        /// <summary>
        ///A test for ClickMouseUp
        ///</summary>
        [TestMethod()]
        public void ClickMouseUpTest()
        {
            Point point = new Point(10, 10);
            _presentationModelTarget.ClickMouseUp(point);
            Assert.IsTrue(_presentationModelTarget._shapeModel.Cursor == CursorType.Default);
        }

        /// <summary>
        ///A test for ClickPointerMenuItem
        ///</summary>
        [TestMethod()]
        public void ClickPointerMenuItemTest()
        {
            _presentationModelTarget.ClickPointerMenuItem();
            Assert.IsFalse(_presentationModelTarget.PointerMenuItemEnable);
        }

        /// <summary>
        ///A test for ClickRectangleMenuItem
        ///</summary>
        [TestMethod()]
        public void ClickRectangleMenuItemTest()
        {
            _presentationModelTarget.ClickRectangleMenuItem();
            Assert.IsFalse(_presentationModelTarget.RectangleMenuItemEnable);
        }

        /// <summary>
        ///A test for CursorTypeChangeEvent
        ///</summary>
        [TestMethod()]
        public void CursorTypeChangeEventTest()
        {
            _presentationModelTarget._shapeModel.Cursor = CursorType.Default;
            _presentationModelTarget.ChangeCursorTypeEvent(CursorType.Default);
            Assert.AreEqual(CursorType.Default, _presentationModelTarget._shapeModel.Cursor);
            _presentationModelTarget._shapeModel.Cursor = CursorType.Cross;
            _presentationModelTarget.ChangeCursorTypeEvent(CursorType.Cross);
            Assert.AreEqual(CursorType.Cross, _presentationModelTarget._shapeModel.Cursor);
            _presentationModelTarget._shapeModel.Cursor = CursorType.SizeAll;
            _presentationModelTarget.ChangeCursorTypeEvent(CursorType.SizeAll);
            Assert.AreEqual(CursorType.SizeAll, _presentationModelTarget._shapeModel.Cursor);
            _presentationModelTarget._shapeModel.Cursor = CursorType.SizeNWSE;
            _presentationModelTarget.ChangeCursorTypeEvent(CursorType.SizeNWSE);
            Assert.AreEqual(CursorType.SizeNWSE, _presentationModelTarget._shapeModel.Cursor);
            _presentationModelTarget._shapeModel.Cursor = CursorType.SizeNESW;
            _presentationModelTarget.ChangeCursorTypeEvent(CursorType.SizeNESW);
            Assert.AreEqual(CursorType.SizeNESW, _presentationModelTarget._shapeModel.Cursor);
        }

        /// <summary>
        ///A test for MoveMouse
        ///</summary>
        [TestMethod()]
        public void MoveMouseTest()
        {
            Point point = new Point(10, 10);
            _presentationModelTarget.MoveMouse(point);
            Assert.IsTrue(_presentationModelTarget._shapeModel.Cursor == CursorType.Default);
        }
    }
}

using Painter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Drawing;

namespace PainterTest
{
    /// <summary>
    ///This is a test class for PointerStateTest and is intended
    ///to contain all PointerStateTest Unit Tests
    ///</summary>
    [TestClass()]
    public class PointerStateTest
    {
        ShapeModel _shapeModelTarget;
        PointerState_Accessor _pointerStateTarget;
        Shape _rectangle;

        [TestInitialize()]
        public void Initialize()
        {
            _shapeModelTarget = new ShapeModel();
            _pointerStateTarget = new PointerState_Accessor(_shapeModelTarget);
            _shapeModelTarget.CursorChange += InvokeTest;
            _shapeModelTarget.StripChange += InvokeTest;
            _shapeModelTarget.ScreenChange += InvokeTest;
            
            Point startPoint = new Point(10, 10);
            Point endPoint = new Point(20, 20);
            _rectangle = ShapeFactory.CreatShape(Mode.Rectangle, startPoint, endPoint);
        }

        public void InvokeTest(CursorType curseType)
        {
        }

        public void InvokeTest()
        {
        }

        [TestMethod()]
        public void PressMouseTest()
        {
            _pointerStateTarget.PressMouse(new Point(15, 15));
            Assert.AreEqual(Corner.None, _pointerStateTarget._pressedCorner);
            _shapeModelTarget.SelectedShape = _rectangle;
            _rectangle.IsSelect = true;
            _pointerStateTarget.PressMouse(new Point(10, 10));
            Assert.IsTrue(_pointerStateTarget._resizing);
        }

        /// <summary>
        ///A test for MoveMouse
        ///</summary>
        [TestMethod()]
        public void MoveMouseTest()
        {           
            _shapeModelTarget.AddShape(_rectangle);
            _pointerStateTarget.MoveMouse(new Point(15, 15));
            Assert.AreEqual(CursorType.SizeAll, _shapeModelTarget.Cursor);
            _pointerStateTarget.MoveMouse(new Point(15, 15));
            _shapeModelTarget.ClickMouseDown(new Point(15, 15));
            _pointerStateTarget.MoveMouse(new Point(15, 15));
            _shapeModelTarget.ClickMouseUp(new Point(15, 15));
            _pointerStateTarget.PressMouse(new Point(10, 10));
            _pointerStateTarget.MoveMouse(new Point(15, 15));
            Assert.AreEqual(CursorType.SizeNWSE, _shapeModelTarget.Cursor);          
            _pointerStateTarget.PressMouse(new Point(15, 15));
            _shapeModelTarget.SelectedShape = _rectangle;
            _rectangle.IsSelect = true;
            _pointerStateTarget._resizing = false;
            _pointerStateTarget._mousePressed = true;
            _pointerStateTarget.MoveMouse(new Point(18, 18));
            Assert.AreEqual(new Point(13, 13), _rectangle.StartPosition);
            _pointerStateTarget._resizing = false;
            _pointerStateTarget._mousePressed = false;
            _pointerStateTarget.MoveMouse(new Point(5, 5));
            Assert.AreEqual(CursorType.Default, _shapeModelTarget.Cursor);
        }

        [TestMethod()]
        public void ReleaseMouseTest()
        {
            Point point = new Point(15,15);
            Point point2 = new Point(55,55);
            Point point3 = new Point(15, 55);
            Point point4 = new Point(55, 15);
            Point insidePoint = new Point(30,30);

            //畫第一個圖
            _shapeModelTarget.SelectedMode = Mode.Rectangle;
            _shapeModelTarget.MoveMouse(point);
            _shapeModelTarget.ClickMouseDown(point);
            _shapeModelTarget.MoveMouse(point2);
            _shapeModelTarget.ClickMouseUp(point2);

            //點選該圖            
            _shapeModelTarget.SelectedMode = Mode.Pointer;
            _shapeModelTarget.MoveMouse(insidePoint);
            _shapeModelTarget.ClickMouseDown(insidePoint);
            _shapeModelTarget.MoveMouse(insidePoint);
            _shapeModelTarget.ClickMouseUp(insidePoint);
            Assert.AreEqual(_shapeModelTarget.SelectedShape.StartPosition, point);

            //點選圖形右下角
            _shapeModelTarget.MoveMouse(point2);
            _shapeModelTarget.ClickMouseDown(point2);
            _shapeModelTarget.MoveMouse(insidePoint);
            _shapeModelTarget.ClickMouseUp(insidePoint);
            Assert.AreEqual(_shapeModelTarget.SelectedShape.StartPosition, point);
            _shapeModelTarget.ClickUndoButton();
           

            //Click LeftTop
            _shapeModelTarget.MoveMouse(point);
            _shapeModelTarget.ClickMouseDown(point);
            _shapeModelTarget.MoveMouse(insidePoint);
            _shapeModelTarget.ClickMouseUp(insidePoint);
            Assert.AreEqual(_shapeModelTarget.SelectedShape.StartPosition, insidePoint);
            _shapeModelTarget.ClickUndoButton();

            //Click BottomLeft
            _shapeModelTarget.MoveMouse(point3);
            _shapeModelTarget.ClickMouseDown(point3);
            _shapeModelTarget.MoveMouse(insidePoint);
            _shapeModelTarget.ClickMouseUp(insidePoint);
            Assert.AreEqual(_shapeModelTarget.SelectedShape.StartPosition, new Point(30, 15));
            _shapeModelTarget.ClickUndoButton();
            
            //Click TopRight
            _shapeModelTarget.MoveMouse(point4);
            _shapeModelTarget.ClickMouseDown(point4);
            _shapeModelTarget.MoveMouse(insidePoint);
            _shapeModelTarget.ClickMouseUp(insidePoint);
            Assert.AreEqual(_shapeModelTarget.SelectedShape.StartPosition, new Point(15, 30));
            _shapeModelTarget.ClickUndoButton();
            _shapeModelTarget.ClickRedoButton();
            _shapeModelTarget.ClickUndoButton();
            _shapeModelTarget.ClickDeleteButton();
            _shapeModelTarget.ClickUndoButton();

            //move
            _shapeModelTarget.MoveMouse(insidePoint);
            _shapeModelTarget.ClickMouseDown(insidePoint);
            _shapeModelTarget.MoveMouse(point);
            _shapeModelTarget.ClickMouseUp(point);
            Assert.AreEqual(_shapeModelTarget.SelectedShape.StartPosition, new Point(0, 0));
            _shapeModelTarget.ClickUndoButton();

        }
    }
}

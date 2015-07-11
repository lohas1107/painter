using Painter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PainterTest
{


    /// <summary>
    ///This is a test class for DrawingStateTest and is intended
    ///to contain all DrawingStateTest Unit Tests
    ///</summary>
    [TestClass()]
    public class DrawingStateTest
    {
        DrawingState_Accessor _drawingStateTarget;
        ShapeModel _shapeModelTarget;
        PresentationModel _presentationModelTarget;

        [TestInitialize()]
        public void Initialize()
        {
            _shapeModelTarget = new ShapeModel();
            _presentationModelTarget = new PresentationModel(_shapeModelTarget);
            _drawingStateTarget = new DrawingState_Accessor(_shapeModelTarget);

            _presentationModelTarget.CursorChange += InvokeTest;
            _presentationModelTarget.StripChange += InvokeTest;
            _presentationModelTarget.ScreenChange += InvokeTest;
        }

        /// <summary>
        ///A test for PressMouse
        ///</summary>
        [TestMethod()]
        public void PressMouseTest()
        {
            Point startPoint = new Point(10, 10);
            _shapeModelTarget.SelectedMode = Mode.Rectangle;            
            _drawingStateTarget.PressMouse(startPoint);

            Assert.AreEqual(true, _drawingStateTarget._mousePressed);
            Assert.AreEqual(true, _drawingStateTarget._drawingShape.IsSelect);
        }

        public void InvokeTest(Cursor type)
        {
        }

        public void InvokeTest()
        {
        }

        /// <summary>
        ///A test for MoveMouse
        ///</summary>
        [TestMethod()]
        public void MoveMouseTest()
        {
            Point startPoint = new Point(10, 10);
            Point endPoint = new Point(20, 20);
            _shapeModelTarget.SelectedMode = Mode.Rectangle; 
            _drawingStateTarget._mousePressed = true;
            _drawingStateTarget.PressMouse(startPoint);
            _drawingStateTarget.MoveMouse(endPoint);
            Assert.AreEqual(startPoint, _drawingStateTarget._drawingShape.StartPosition);
            Assert.AreEqual(10, _drawingStateTarget._drawingShape.Width);
            Assert.AreEqual(10, _drawingStateTarget._drawingShape.Height);
        }

        /// <summary>
        ///A test for ReleaseMouse
        ///</summary>
        [TestMethod()]
        public void ReleaseMouseTest()
        {
            Point startPoint = new Point(10, 10);
            Point endPoint = new Point(20, 20);
            _shapeModelTarget.SelectedMode = Mode.Rectangle;
            _drawingStateTarget.PressMouse(startPoint);
            _drawingStateTarget.MoveMouse(endPoint);
            Assert.AreEqual(10, _drawingStateTarget._drawingShape.Width);
            Assert.AreEqual(10, _drawingStateTarget._drawingShape.Height);
            _drawingStateTarget._shapeModel.SelectedShape = _drawingStateTarget._drawingShape;
            _drawingStateTarget._shapeModel.SelectedShape.IsSelect = true;
            _drawingStateTarget.ReleaseMouse(endPoint);
            Assert.IsNull(_drawingStateTarget._drawingShape);
            Assert.IsFalse(_drawingStateTarget._mousePressed);
        }
    }
}

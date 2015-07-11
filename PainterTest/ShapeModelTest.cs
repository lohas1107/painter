using Painter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PainterTest
{
    
    
    /// <summary>
    ///This is a test class for ShapeModelTest and is intended
    ///to contain all ShapeModelTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ShapeModelTest
    {
        ShapeModel_Accessor _shapeModelTarget;

        [TestInitialize()]
        public void Initialize()
        {
            _shapeModelTarget = new ShapeModel_Accessor();
            _shapeModelTarget._selectedMode = Mode.Pointer;
            _shapeModelTarget.add_CursorChange(InvokeTest);
            _shapeModelTarget.add_ScreenChange(InvokeTest);
            _shapeModelTarget.add_StripChange(InvokeTest);
        }

        /// <summary>
        ///A test for ClickMouseDown
        ///</summary>
        [TestMethod()]
        public void ClickMouseDownTest()
        {
            _shapeModelTarget.ClickMouseDown(new Point(10, 10));
            Assert.IsTrue(_shapeModelTarget._cursor == CursorType.Default);
        }

        public void InvokeTest(CursorType type)
        {
        }

        public void InvokeTest()
        {
        }

        //[TestMethod()]
        //public void DoCommandTest()
        //{

        //}

        /// <summary>
        ///A test for ClickMouseUp
        ///</summary>
        [TestMethod()]
        public void ClickMouseUpTest()
        {
            _shapeModelTarget.ClickMouseUp(new Point(20, 20));
            Assert.IsTrue(_shapeModelTarget._cursor == CursorType.Default);
        }

        /// <summary>
        ///A test for MoveMouse
        ///</summary>
        [TestMethod()]
        public void MoveMouseTest()
        {
            _shapeModelTarget.MoveMouse(new Point(15, 15));
            Assert.IsTrue(_shapeModelTarget._cursor == CursorType.Default);
        }

        /// <summary>
        ///A test for Cursor
        ///</summary>
        [TestMethod()]
        public void CursorTest()
        {
            _shapeModelTarget.Cursor = CursorType.Cross;
            Assert.IsTrue(_shapeModelTarget.Cursor == CursorType.Cross);
            _shapeModelTarget.Cursor = CursorType.Default;
            Assert.IsTrue(_shapeModelTarget.Cursor == CursorType.Default);
            _shapeModelTarget.Cursor = CursorType.SizeAll;
            Assert.IsTrue(_shapeModelTarget.Cursor == CursorType.SizeAll);
        }

        /// <summary>
        ///A test for SelectedMode
        ///</summary>
        [TestMethod()]
        public void SelectedModeTest()
        {
            _shapeModelTarget.SelectedMode = Mode.Pointer;
            Assert.IsTrue(_shapeModelTarget.Cursor == CursorType.Default);
        }
    }
}

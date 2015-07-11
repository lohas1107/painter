using Painter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Drawing;

namespace PainterTest
{   
    /// <summary>
    ///This is a test class for CommandManagerTest and is intended
    ///to contain all CommandManagerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class CommandManagerTest
    {
        CommandManager_Accessor _commandManagerTarget;
        ShapeModel _shapeModel;

        [TestInitialize()]
        public void Initialize()
        {
            _commandManagerTarget = new CommandManager_Accessor();
            _shapeModel = new ShapeModel();
            _shapeModel.CursorChange += InvokeTest;
            _shapeModel.StripChange += InvokeTest;
            _shapeModel.ScreenChange += InvokeTest;
        }

        public void InvokeTest(CursorType type)
        {
        }

        public void InvokeTest()
        {
        }

        /// <summary>
        ///A test for DoCommand
        ///</summary>
        [TestMethod()]
        public void DoCommandTest()
        {
            Point startPoint = new Point(10, 10);
            Point endPoint = new Point(20, 20);
            Shape rectangle = ShapeFactory.CreatShape(Mode.Rectangle, startPoint, endPoint);
            Command command = new AddShapeCommand(rectangle, _shapeModel);
            _commandManagerTarget.DoCommand(command);
            Assert.AreEqual(1, _commandManagerTarget._undoList.Count);
            Assert.AreEqual(0, _commandManagerTarget._redoList.Count);
        }

        /// <summary>
        ///A test for RedoCommand
        ///</summary>
        [TestMethod()]
        public void RedoCommandTest()
        {
            Point startPoint = new Point(10, 10);
            Point endPoint = new Point(20, 20);
            Shape rectangle = ShapeFactory.CreatShape(Mode.Rectangle, startPoint, endPoint);
            Command commandAdd = new AddShapeCommand(rectangle, _shapeModel);
            _commandManagerTarget.DoCommand(commandAdd);
            Assert.AreEqual(1, _commandManagerTarget._undoList.Count);
            _commandManagerTarget.UndoCommand();
            Assert.AreEqual(0, _commandManagerTarget._undoList.Count);
            Assert.AreEqual(1, _commandManagerTarget._redoList.Count);
            _commandManagerTarget.RedoCommand();
            Assert.AreEqual(0, _commandManagerTarget._redoList.Count);
            Assert.AreEqual(1, _commandManagerTarget._undoList.Count);
        }

        /// <summary>
        ///A test for UndoCommand
        ///</summary>
        [TestMethod()]
        public void UndoCommandTest()
        {
            Point startPoint = new Point(10, 10);
            Point endPoint = new Point(20, 20);
            Shape rectangle = ShapeFactory.CreatShape(Mode.Rectangle, startPoint, endPoint);
            Command commandAdd = new AddShapeCommand(rectangle, _shapeModel);
            _commandManagerTarget.DoCommand(commandAdd);
            Assert.AreEqual(1, _commandManagerTarget._undoList.Count);
            _shapeModel.SelectedShape = rectangle;
            _commandManagerTarget.UndoCommand();
            Assert.AreEqual(0, _commandManagerTarget._undoList.Count);
            Assert.AreEqual(1, _commandManagerTarget._redoList.Count);
        }

        ///// <summary>
        /////A test for RedoEnble
        /////</summary>
        //[TestMethod()]
        //public void RedoEnbleTest()
        //{
        //    CommandManager target = new CommandManager(); // TODO: Initialize to an appropriate value
        //    bool actual;
        //    actual = target.RedoEnble;
        //    Assert.Inconclusive("Verify the correctness of this test method.");
        //}

        ///// <summary>
        /////A test for UndoEnable
        /////</summary>
        //[TestMethod()]
        //public void UndoEnableTest()
        //{
        //    CommandManager target = new CommandManager(); // TODO: Initialize to an appropriate value
        //    bool actual;
        //    actual = target.UndoEnable;
        //    Assert.Inconclusive("Verify the correctness of this test method.");
        //}
    }
}

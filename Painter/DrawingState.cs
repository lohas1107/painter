using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Painter
{
    class DrawingState : State
    {
        private ShapeModel _shapeModel;
        private Point _startPosition;
        private Point _endPosition;
        private Boolean _mousePressed = false;
        private Shape _drawingShape = null;

        public DrawingState(ShapeModel shapeModel)
        {
            _shapeModel = shapeModel;
        }

        // 按下滑鼠
        override public void PressMouse(Point point)
        {
            _startPosition = point;
            _mousePressed = true;
            _drawingShape = ShapeFactory.CreatShape(_shapeModel.SelectedMode, _startPosition, _startPosition);
            _drawingShape.IsSelect = true;
        }

        // 移動滑鼠
        override public void MoveMouse(Point point)
        {
            _endPosition = point;
            if (_mousePressed)
            {
                _drawingShape.StartPosition = _startPosition;
                _drawingShape.Width = _endPosition.X - _startPosition.X;
                _drawingShape.Height = _endPosition.Y - _startPosition.Y;
            }
        }

        // 放開滑鼠
        override public void ReleaseMouse(Point point)
        {
            if (_drawingShape != null)
            {
                Command command = new AddShapeCommand(_drawingShape, _shapeModel);
                if (_drawingShape.Width != 0 & _drawingShape.Height != 0)
                {
                    _shapeModel.DoCommand(command);
                }
                _drawingShape.IsSelect = false;
            }

            _drawingShape = null;
            _mousePressed = false;
        }

        // 畫圖
        override public void Draw(Graphics graphics)
        {
            if (_mousePressed)
            {
                _drawingShape.DoDraw(graphics);
            }
        }
    }
}

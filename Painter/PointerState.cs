using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Painter
{
    class PointerState : State
    {
        private ShapeModel _shapeModel;
        private bool _mousePressed;
        private Point _pressPoint;
        private bool _resizing;
        private Point _referencePoint;
        private Corner _pressedCorner;
        private Point _different;
        private Point _resize;

        public PointerState(ShapeModel shapeModel)
        {
            _shapeModel = shapeModel;
        }

        // 按下滑鼠
        override public void PressMouse(Point point)
        {
            _mousePressed = true;
            _pressPoint = point;

            if (_shapeModel.SelectedShape != null)
            {
                _pressedCorner = _shapeModel.SelectedShape.ContainCorner(point);

                if (_pressedCorner != Corner.None)
                {
                    _resizing = true;
                }
            }

            if (!_resizing)
            {
                _shapeModel.SelectedShape = _shapeModel.Contains(_mousePressed, point);
            }
        }

        // 移動滑鼠
        override public void MoveMouse(Point point)
        {
            Shape hoveringShape = _shapeModel.Contains(false, point);
            Point differentPoint = Differ(point, _referencePoint);

            if (_resizing && _mousePressed) // resize
            {
                ResizingShape(differentPoint);
            }
            else if (_shapeModel.SelectedShape != null && _shapeModel.SelectedShape.IsSelect && _mousePressed) // move
            {
                _shapeModel.SelectedShape.StartPosition = AddDifference(differentPoint);
            }
            else
            {
                _shapeModel.Cursor = CursorType.Default;
            }

            if (hoveringShape != null & !_resizing)
            {
                _shapeModel.Cursor = CursorType.SizeAll;
            }
            _referencePoint = point;
        }

        // resize動畫
        private void ResizingShape(Point differentPoint)
        {
            switch (_pressedCorner)
            {
                case Corner.TopLeft:
                    _shapeModel.Cursor = CursorType.SizeNWSE;
                    _shapeModel.SelectedShape.StartPosition = AddDifference(differentPoint);
                    Point resizeTopLeft = ResizeTopLeft(differentPoint);
                    Resize(resizeTopLeft);
                    break;
                case Corner.TopRight:
                    _shapeModel.Cursor = CursorType.SizeNESW;
                    Point resizeTopRight = ResizeTopRight(differentPoint);
                    Resize(resizeTopRight);
                    differentPoint.X = 0;
                    _shapeModel.SelectedShape.StartPosition = AddDifference(differentPoint);
                    break;
                case Corner.BottomLeft:
                    _shapeModel.Cursor = CursorType.SizeNESW;
                    Point resizeBottomRight = ResizeBottomLeft(differentPoint);
                    Resize(resizeBottomRight);
                    differentPoint.Y = 0;
                    _shapeModel.SelectedShape.StartPosition = AddDifference(differentPoint);
                    break;
                case Corner.BottomRight:
                    _shapeModel.Cursor = CursorType.SizeNWSE;
                    Resize(differentPoint);
                    break;
            }
        }

        // 放開滑鼠
        override public void ReleaseMouse(Point point)
        {
            _mousePressed = false;
            _different = Differ(point, _pressPoint);

            if (_shapeModel.SelectedShape != null)
            {
                if (_different.X == 0 & _different.Y == 0) return;

                if (_resizing)
                {
                    ResizedShape();
                }
                else
                {
                    Command moveShapeCommand = new MoveShapeCommand(_shapeModel.SelectedShape, _different);
                    moveShapeCommand.Undo();
                    _shapeModel.DoCommand(moveShapeCommand);
                }
            }
            _resizing = false;
        }

        // 下 resize command
        private void ResizedShape()
        {
            if (_pressedCorner == Corner.TopLeft)
            {
                _resize = ResizeTopLeft(_different);
                SetResizeCommand();
            }
            if (_pressedCorner == Corner.TopRight)
            {
                _resize = ResizeTopRight(_different);
                _different.X = 0;
                SetResizeCommand();
            }
            if (_pressedCorner == Corner.BottomLeft)
            {
                _resize = ResizeBottomLeft(_different);
                _different.Y = 0;
                SetResizeCommand();
            }
            if (_pressedCorner == Corner.BottomRight)
            {
                _resize = _different;
                _different.X = 0;
                _different.Y = 0;
                SetResizeCommand();
            }
        }

        // 設定 ResizeShapeCommand
        private void SetResizeCommand()
        {
            Command command = new ResizeShapeCommand(_shapeModel.SelectedShape, _different, _resize);
            command.Undo();
            _shapeModel.DoCommand(command);
        }

        // 前後2點的距離
        private Point Differ(Point nextPoint, Point previousPoint)
        {
            Point differentPoint = new Point();
            differentPoint.X = nextPoint.X - previousPoint.X;
            differentPoint.Y = nextPoint.Y - previousPoint.Y;
            return differentPoint;
        }

        // 移動至目標點
        private Point AddDifference(Point differentPoint)
        {
            Point newStart = _shapeModel.SelectedShape.StartPosition;
            newStart.X += differentPoint.X;
            newStart.Y += differentPoint.Y;
            return newStart;
        }

        // 更新長寬
        private void Resize(Point resize)
        {
            _shapeModel.SelectedShape.Width += resize.X;
            _shapeModel.SelectedShape.Height += resize.Y;
        }

        // 更新 TopLeft 點
        private Point ResizeTopLeft(Point point)
        {
            Point resizeTopLeft = new Point();
            resizeTopLeft.X = -point.X;
            resizeTopLeft.Y = -point.Y;
            return resizeTopLeft;
        }

        // 更新 TopRight 點
        private Point ResizeTopRight(Point point)
        {
            Point resizeTopRight = point;
            resizeTopRight.Y = -point.Y;
            return resizeTopRight;
        }

        // 更新 BottomLeft 點
        private Point ResizeBottomLeft(Point point)
        {
            Point reizeBottomLeft = point;
            reizeBottomLeft.X = -point.X;
            return reizeBottomLeft;
        }

        // 畫圖
        override public void Draw(Graphics graphics)
        {
        }
    }
}

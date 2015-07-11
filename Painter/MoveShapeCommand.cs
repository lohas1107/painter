using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Painter
{
    class MoveShapeCommand : Command
    {
        Shape _shape;
        Point _point;
        Point _startPoint;

        public MoveShapeCommand(Shape shape, Point point)
        {
            _shape = shape;
            _point = point;
            _startPoint = _shape.StartPosition;
        }

        // 執行命令
        override public void Execute()
        {
            _startPoint.X += _point.X;
            _startPoint.Y += _point.Y;
            _shape.StartPosition = _startPoint;
        }

        // 復原命令
        override public void Undo()
        {
            _startPoint.X -= _point.X;
            _startPoint.Y -= _point.Y;
            _shape.StartPosition = _startPoint;
        }
    }
}

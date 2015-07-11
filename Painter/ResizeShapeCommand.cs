using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Painter
{
    class ResizeShapeCommand : Command
    {
        Shape _resizeShape;
        Point _startPoint;
        Point _differentPoint;
        Point _resize;

        public ResizeShapeCommand(Shape shape, Point differentPoint, Point resize)
        {
            _resizeShape = shape;
            _startPoint = shape.StartPosition;
            _differentPoint = differentPoint;
            _resize = resize;
        }

        // 執行命令
        override public void Execute()
        {
            _startPoint.X += _differentPoint.X;
            _startPoint.Y += _differentPoint.Y;
            _resizeShape.StartPosition = _startPoint;
            _resizeShape.Width += _resize.X;
            _resizeShape.Height += _resize.Y;
        }

        // 復原命令
        override public void Undo()
        {
            _startPoint.X -= _differentPoint.X;
            _startPoint.Y -= _differentPoint.Y;
            _resizeShape.StartPosition = _startPoint;
            _resizeShape.Width -= _resize.X;
            _resizeShape.Height -= _resize.Y;
        }
    }
}

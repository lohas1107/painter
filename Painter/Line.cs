using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Painter
{
    class Line : Shape
    {
        private const float PATH_WIDEN = 10.0f;
        private const float BLACK_PEN_WIDTH = 2.0f;

        public Line(Point startPosition, Point endPosition)
        {
            StartPosition = startPosition;
            Width = endPosition.X - startPosition.X;
            Height = endPosition.Y - startPosition.Y;
        }

        //是否包含圖形的座標
        override public bool Contains(Point point)
        {
            GraphicsPath path = new GraphicsPath();
            path.FillMode = FillMode.Winding;
            path.AddLine(StartPosition.X, StartPosition.Y, StartPosition.X + Width, StartPosition.Y + Height);
            path.Widen(new Pen(Color.AliceBlue, PATH_WIDEN));
            return path.IsVisible(point.X, point.Y);
        }

        //畫圖
        override protected void Draw(Graphics graphics)
        {
            Pen blackPen = new Pen(Color.Black, BLACK_PEN_WIDTH);
            graphics.DrawLine(blackPen, StartPosition.X, StartPosition.Y, StartPosition.X + Width, StartPosition.Y + Height);
        }
    }
}

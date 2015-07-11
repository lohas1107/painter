using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Painter
{
    public class Rectangle : Shape
    {
        private const float RED_PEN_WIDTH = 2.0f;

        public Rectangle(Point startPosition, Point endPosition)
        {
            StartPosition = startPosition;
            Width = endPosition.X - startPosition.X;
            Height = endPosition.Y - startPosition.Y;
        }

        //是否圖形包含的座標
        override public bool Contains(Point point)
        {
            GraphicsPath path = new GraphicsPath();
            path.FillMode = FillMode.Winding;
            path.AddRectangle(new System.Drawing.Rectangle(TopLeft.X, TopLeft.Y, AbsoluteSize.X, AbsoluteSize.Y));
            return path.IsVisible(point.X, point.Y);
        }

        // 畫圖
        override protected void Draw(Graphics graphics)
        {
            Pen redPen = new Pen(Color.Red, RED_PEN_WIDTH);
            graphics.FillRectangle(Brushes.Plum, TopLeft.X, TopLeft.Y, AbsoluteSize.X, AbsoluteSize.Y);
            graphics.DrawRectangle(redPen, TopLeft.X, TopLeft.Y, AbsoluteSize.X, AbsoluteSize.Y);
        }

    }
}

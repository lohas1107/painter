using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Painter
{
    public class Ellipse : Shape
    {
        private const float BLUE_PEN_WIDTH = 2.0f;

        public Ellipse(Point startPosition, Point endPosition)
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
            path.AddEllipse(new System.Drawing.Rectangle(TopLeft.X, TopLeft.Y, AbsoluteSize.X, AbsoluteSize.Y));
            return path.IsVisible(point.X, point.Y);
        }

        // 畫圖
        override protected void Draw(Graphics graphics)
        {
            Pen bluePen = new Pen(Color.Blue, BLUE_PEN_WIDTH);
            graphics.DrawEllipse(bluePen, TopLeft.X, TopLeft.Y, AbsoluteSize.X, AbsoluteSize.Y);
            graphics.FillEllipse(Brushes.LightBlue, TopLeft.X, TopLeft.Y, AbsoluteSize.X, AbsoluteSize.Y);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Painter
{
    public enum Corner
    {
        None,
        TopLeft,
        TopRight,
        BottomLeft,
        BottomRight
    }

    public abstract class Shape
    {
        private const float DASH_PEN_WIDTH = 1.5f;
        private const float DASH_PATTERN_LENGTH = 3.0f;
        private const float DASH_PATTERN_GAP = 3.0f;
        private const float DASH_LINE_MARGIN = 1.5f;
        private const float DASH_LINE_MARGIN_DOUBLE = 3.0f;
        private const int SQUARE_SIDE = 6;
        private const int SQUARE_OFFSET = 3;

        // 是否包含圖形的座標
        abstract public bool Contains(Point point);

        // 是否包含 small control blocks 的座標
        public Corner ContainCorner(Point point)
        {
            GraphicsPath path = new GraphicsPath();
            path.FillMode = FillMode.Winding;
            path.AddRectangle(new System.Drawing.Rectangle(StartPosition.X - SQUARE_OFFSET, StartPosition.Y - SQUARE_OFFSET, SQUARE_SIDE, SQUARE_SIDE));
            if (path.IsVisible(point.X, point.Y))
            {
                return Corner.TopLeft;
            }
            path.AddRectangle(new System.Drawing.Rectangle(StartPosition.X + Width - SQUARE_OFFSET, StartPosition.Y - SQUARE_OFFSET, SQUARE_SIDE, SQUARE_SIDE));
            if (path.IsVisible(point.X, point.Y))
            {
                return Corner.TopRight;
            }
            path.AddRectangle(new System.Drawing.Rectangle(StartPosition.X - SQUARE_OFFSET, StartPosition.Y + Height - SQUARE_OFFSET, SQUARE_SIDE, SQUARE_SIDE));
            if (path.IsVisible(point.X, point.Y))
            {
                return Corner.BottomLeft;
            }
            path.AddRectangle(new System.Drawing.Rectangle(StartPosition.X + Width - SQUARE_OFFSET, StartPosition.Y + Height - SQUARE_OFFSET, SQUARE_SIDE, SQUARE_SIDE));
            if (path.IsVisible(point.X, point.Y))
            {
                return Corner.BottomRight;
            }
            return Corner.None;
        }

        // 畫圖形，被點到的圖形畫虛線
        public void DoDraw(Graphics graphics)
        {
            Draw(graphics);
            if (IsSelect)
            {
                DrawDashLine(graphics);
            }
        }

        // 畫圖
        abstract protected void Draw(Graphics graphics);

        //畫虛線
        private void DrawDashLine(Graphics graphics)
        {
            Pen dashPen = new Pen(Color.Green, DASH_PEN_WIDTH);
            Pen greenPen = new Pen(Color.Green);
            dashPen.DashPattern = new float[] { DASH_PATTERN_LENGTH, DASH_PATTERN_GAP };
            graphics.DrawRectangle(dashPen, TopLeft.X - DASH_LINE_MARGIN, TopLeft.Y - DASH_LINE_MARGIN, AbsoluteSize.X + DASH_LINE_MARGIN_DOUBLE, AbsoluteSize.Y + DASH_LINE_MARGIN_DOUBLE);
            graphics.DrawRectangle(greenPen, StartPosition.X - SQUARE_OFFSET, StartPosition.Y - SQUARE_OFFSET, SQUARE_SIDE, SQUARE_SIDE); // TopLeft
            graphics.DrawRectangle(greenPen, StartPosition.X + Width - SQUARE_OFFSET, StartPosition.Y - SQUARE_OFFSET, SQUARE_SIDE, SQUARE_SIDE); // TopRight
            graphics.DrawRectangle(greenPen, StartPosition.X - SQUARE_OFFSET, StartPosition.Y + Height - SQUARE_OFFSET, SQUARE_SIDE, SQUARE_SIDE); // BottomLeft
            graphics.DrawRectangle(greenPen, StartPosition.X + Width - SQUARE_OFFSET, StartPosition.Y + Height - SQUARE_OFFSET, SQUARE_SIDE, SQUARE_SIDE); // BottomRight
        }

        public Point StartPosition
        {
            get;
            set;
        }

        public int Width
        {
            get;
            set;
        }

        public int Height
        {
            get;
            set;
        }

        // 左上的點
        protected Point TopLeft
        {
            get
            {
                Point result = StartPosition;

                if (Width < 0)
                {
                    result.X = StartPosition.X + Width;
                }

                if (Height < 0)
                {
                    result.Y = StartPosition.Y + Height;
                }

                return result;
            }
        }

        // 右下的點
        protected Point BottomRight
        {
            get
            {
                Point result = StartPosition;

                if (Width > 0)
                {
                    result.X = StartPosition.X + Width;
                }

                if (Height > 0)
                {
                    result.Y = StartPosition.Y + Height;
                }

                return result;
            }
        }

        protected Point AbsoluteSize
        {
            get
            {
                Point result = new Point();
                result.X = BottomRight.X - TopLeft.X;
                result.Y = BottomRight.Y - TopLeft.Y;
                return result;
            }
        }

        public bool IsSelect
        {
            get;
            set;
        }
    }
}

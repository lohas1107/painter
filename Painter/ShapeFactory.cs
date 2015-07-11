using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Painter
{
    // 滑鼠和畫圖模式
    public enum Mode
    {
        Pointer,
        Rectangle,
        Ellipse,
        Line
    }

    public class ShapeFactory
    {
        // 製作圖形
        static public Shape CreatShape(Mode mode, Point startPosition, Point endPosition)
        {
            switch (mode)
            {
                case Mode.Pointer:
                    return null;
                case Mode.Rectangle:
                    return new Rectangle(startPosition, endPosition);
                case Mode.Ellipse:
                    return new Ellipse(startPosition, endPosition);
                case Mode.Line:
                    return new Line(startPosition, endPosition);
            }
            return null;
        }
    }
}

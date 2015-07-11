using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Painter
{
    abstract class State
    {
        // 按下滑鼠
        abstract public void PressMouse(Point point);

        // 移動滑鼠
        abstract public void MoveMouse(Point point);

        // 放開滑鼠
        abstract public void ReleaseMouse(Point point);

        // 畫圖
        abstract public void Draw(Graphics graphics);
    }
}

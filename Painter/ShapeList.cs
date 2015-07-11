using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Painter
{
    public class ShapeList
    {
        private List<Shape> _shapeList = new List<Shape>();

        // 加入圖形
        public void AddShape(Shape shape)
        {
            _shapeList.Add(shape);
        }

        // 刪除圖形
        public void DeleteShape(Shape shape)
        {
            _shapeList.Remove(shape);
        }

        // 取得z-order
        public int GetIndex(Shape shape)
        {
            return _shapeList.IndexOf(shape);
        }

        // 插入圖形
        public void InsertShape(int index, Shape shape)
        {
            _shapeList.Insert(index, shape);
        }

        //是否圖形包含的座標
        public Shape Contains(bool mousePressed, Point point)
        {
            Shape target = null;

            foreach (Shape shape in _shapeList)
            {
                if (mousePressed)
                {
                    shape.IsSelect = false;
                }

                if (shape.Contains(point))
                {
                    target = shape;
                }
            }

            if (target != null && mousePressed)
            {
                target.IsSelect = true;
            }

            return target;
        }

        // 畫圖
        public void Draw(Graphics graphics)
        {
            foreach (Shape shape in _shapeList)
            {
                shape.DoDraw(graphics);
            }
        }
    }
}

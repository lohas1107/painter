using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace Painter
{
    // 游標模式
    public enum CursorType
    {
        Default,
        Cross,
        SizeAll,
        SizeNWSE,
        SizeNESW
    }

    public class PresentationModel
    {
        private ShapeModel _shapeModel;

        public delegate void CursorChangeHandler(Cursor cursor);
        public event CursorChangeHandler CursorChange = null;

        public delegate void StripChangeHandler();
        public event StripChangeHandler StripChange = null;

        public delegate void ScreenChangeHandler();
        public event ScreenChangeHandler ScreenChange = null;

        public PresentationModel(ShapeModel shapeModel)
        {
            _shapeModel = shapeModel;
            _shapeModel.CursorChange += ChangeCursorTypeEvent;
            _shapeModel.StripChange += ChangeStripEvent;
            _shapeModel.ScreenChange += ChangeScreenEvent;
        }

        // 變換游標事件
        private void ChangeCursorTypeEvent(CursorType type)
        {
            switch (type)
            {
                case CursorType.Default:
                    CursorChange.Invoke(Cursors.Default);
                    break;
                case CursorType.Cross:
                    CursorChange.Invoke(Cursors.Cross);
                    break;
                case CursorType.SizeAll:
                    CursorChange.Invoke(Cursors.SizeAll);
                    break;
                case CursorType.SizeNWSE:
                    CursorChange.Invoke(Cursors.SizeNWSE);
                    break;
                case CursorType.SizeNESW:
                    CursorChange.Invoke(Cursors.SizeNESW);
                    break;
            }
        }

        // 點擊Strip事件
        private void ChangeStripEvent()
        {
            StripChange.Invoke();
        }

        // 畫面變化事件
        private void ChangeScreenEvent()
        {
            ScreenChange.Invoke();
        }

        // 按下左鍵
        public void ClickMouseDown(Point point, MouseButtons mouseButton)
        {
            if (mouseButton == MouseButtons.Left)
            {
                _shapeModel.ClickMouseDown(point);
            }
        }

        // 拖拉滑鼠
        public void MoveMouse(Point point)
        {
            _shapeModel.MoveMouse(point);
        }

        // 放開滑鼠
        public void ClickMouseUp(Point point)
        {
            _shapeModel.ClickMouseUp(point);
        }

        // 點擊 Undo MenuItem
        public void ClickUndoMenuItem()
        {
            _shapeModel.ClickUndoButton();
        }

        // 點擊 Redo MenuItem 
        public void ClickRedoMenuItem()
        {
            _shapeModel.ClickRedoButton();
        }

        // 按下 Pointer MenuItem
        public void ClickPointerMenuItem()
        {
            _shapeModel.SelectedMode = Mode.Pointer;
        }

        // 按下 Rectangle MenuItem
        public void ClickRectangleMenuItem()
        {
            _shapeModel.SelectedMode = Mode.Rectangle;
        }

        // 按下 Ellipse MenuItem
        public void ClickEllipseMenuItem()
        {
            _shapeModel.SelectedMode = Mode.Ellipse;
        }

        //點擊 Line MenuItem
        public void ClickLineMenuItem()
        {
            _shapeModel.SelectedMode = Mode.Line;
            StripChange.Invoke();
        }

        // 點擊 Delete MenuItem
        public void ClickDeleteMenuItem()
        {
            _shapeModel.ClickDeleteButton();
        }

        // 畫圖
        public void Draw(Graphics graphics)
        {
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            _shapeModel.Draw(graphics);
        }

        public bool UndoMenuItemEnable
        {
            get
            {
                return _shapeModel.UndoEnable;
            }
        }

        public bool RedoMenuItemEnable
        {
            get
            {
                return _shapeModel.RedoEnable;
            }
        }

        public bool PointerMenuItemEnable
        {
            get
            {
                return _shapeModel.SelectedMode != Mode.Pointer;
            }
        }

        public bool RectangleMenuItemEnable
        {
            get
            {
                return _shapeModel.SelectedMode != Mode.Rectangle;
            }
        }

        public bool EllipseMenuItemEnable
        {
            get
            {
                return _shapeModel.SelectedMode != Mode.Ellipse;
            }
        }

        public bool LineMenuItemEnable
        {
            get
            {
                return _shapeModel.SelectedMode != Mode.Line;
            }
        }

        public bool DeleteMenuItemEnable
        {
            get
            {
                return _shapeModel.DeleteEnable;
            }
        }
    }
}

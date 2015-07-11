using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Painter
{
    public class ShapeModel
    {
        private ShapeList _shapeList;
        private State _currentState;
        private Mode _selectedMode;
        private Shape _selectedShape = null;
        private CursorType _cursor;
        private CommandManager _commandManager;

        public delegate void CursorChangeHandler(CursorType cursor);
        public event CursorChangeHandler CursorChange = null;

        public delegate void StripChangeHandler();
        public event StripChangeHandler StripChange = null;

        public delegate void ScreenChangeHandler();
        public event ScreenChangeHandler ScreenChange = null;

        public ShapeModel()
        {
            _shapeList = new ShapeList();
            _currentState = new PointerState(this);
            _commandManager = new CommandManager();
        }

        // 執行命令
        public void DoCommand(Command command)
        {
            _commandManager.DoCommand(command);
            ScreenChange.Invoke();
            StripChange.Invoke();
        }

        // 點擊 UndoButton
        public void ClickUndoButton()
        {
            _commandManager.UndoCommand();
            ScreenChange.Invoke();
            StripChange.Invoke();
        }

        // 點擊 RedoButton
        public void ClickRedoButton()
        {
            _commandManager.RedoCommand();
            ScreenChange.Invoke();
            StripChange.Invoke();
        }

        // 點擊 DeleteButton
        public void ClickDeleteButton()
        {
            Command command = new DeleteShapeCommand(_selectedShape, this);
            _selectedShape.IsSelect = false;
            _selectedShape = null;
            DoCommand(command);
        }

        // 加入圖形
        public void AddShape(Shape shape)
        {
            _shapeList.AddShape(shape);
        }

        // 刪除圖形
        public void DeleteShape(Shape shape)
        {
            _shapeList.DeleteShape(shape);
        }

        // 被點到的圖形
        public Shape Contains(bool mousePressed, Point point)
        {
            return _shapeList.Contains(mousePressed, point);
        }

        // 按下左鍵
        public void ClickMouseDown(Point point)
        {
            _currentState.PressMouse(point);
        }

        // 拖拉滑鼠
        public void MoveMouse(Point point)
        {
            _currentState.MoveMouse(point);
            ScreenChange.Invoke();
        }

        // 放開滑鼠
        public void ClickMouseUp(Point point)
        {
            _currentState.ReleaseMouse(point);
            ScreenChange.Invoke();
        }

        // 畫圖
        public void Draw(Graphics graphics)
        {
            _shapeList.Draw(graphics);
            _currentState.Draw(graphics);
        }

        public ShapeList ShapeList
        {
            get
            {
                return _shapeList;
            }
        }

        // 選擇游標或畫圖模式
        public Mode SelectedMode
        {
            get
            {
                return _selectedMode;
            }
            set
            {
                _selectedMode = value;
                if (SelectedMode == Mode.Pointer)
                {
                    _currentState = new PointerState(this);
                    Cursor = CursorType.Default;
                }
                else
                {
                    _currentState = new DrawingState(this);
                    Cursor = CursorType.Cross;
                }
                StripChange.Invoke();
            }
        }

        public Shape SelectedShape
        {
            get
            {
                return _selectedShape;
            }
            set
            {
                _selectedShape = value;
                StripChange.Invoke();
            }
        }

        public CursorType Cursor
        {
            get
            {
                return _cursor;
            }
            set
            {
                _cursor = value;
                CursorChange.Invoke(value);
            }
        }

        public bool UndoEnable
        {
            get
            {
                return _commandManager.UndoEnable;
            }
        }

        public bool RedoEnable
        {
            get
            {
                return _commandManager.RedoEnble;
            }
        }

        public bool DeleteEnable
        {
            get
            {
                return SelectedShape != null;
            }
        }
    }
}

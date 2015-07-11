using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Painter
{
    class PainterForm : Form
    {
        private const int FORM_WIDTH = 800;
        private const int FORM_HEIGHT = 600;
        private PresentationModel _presentationModel;
        private MenuStrip _mainMenuStrip;
        private ToolStripMenuItem _fileMenuItem;
        private ToolStripMenuItem _exitMenuItem;
        private ToolStripMenuItem _editMenuItem;
        private ToolStripMenuItem _undoMenuItem;
        private ToolStripMenuItem _redoMenuItem;
        private ToolStripMenuItem _shapesMenuItem;
        private ToolStripMenuItem _pointerMenuItem;
        private ToolStripMenuItem _rectangleMenuItem;
        private ToolStripMenuItem _ellipseMenuItem;
        private ToolStripMenuItem _lineMenuItem;
        private ToolStripMenuItem _deleteMenuItem;
        private ToolStripMenuItem _helpMenuItem;
        private ToolStripMenuItem _aboutMenuItem;
        private ToolStrip _toolStrip;
        private ToolStripButton _undoToolStripButton;
        private ToolStripButton _redoToolStripButton;
        private ToolStripButton _pointerToolStripButton;
        private ToolStripButton _rectangleToolStripButton;
        private ToolStripButton _ellipseToolStripButton;
        private ToolStripButton _lineToolStripButton;
        private ToolStripButton _deleteToolStripButton;

        public PainterForm(PresentationModel presentationModel)
        {
            DoubleBuffered = true;
            _presentationModel = presentationModel;
            PrepareMenuStrip();
            PrepareToolStrip();
            Initialize();
        }

        // 準備 MenuStrip 元件
        private void PrepareMenuStrip()
        {
            _mainMenuStrip = new MenuStrip();
            _fileMenuItem = new ToolStripMenuItem("File");
            _exitMenuItem = new ToolStripMenuItem("Exit");
            _editMenuItem = new ToolStripMenuItem("Edit");
            _undoMenuItem = new ToolStripMenuItem("Undo");
            _redoMenuItem = new ToolStripMenuItem("Redo");
            _shapesMenuItem = new ToolStripMenuItem("Shapes");
            _pointerMenuItem = new ToolStripMenuItem("Pointer");
            _rectangleMenuItem = new ToolStripMenuItem("Rectangle");
            _ellipseMenuItem = new ToolStripMenuItem("Ellipse");
            _lineMenuItem = new ToolStripMenuItem("Line");
            _deleteMenuItem = new ToolStripMenuItem("Delete");
            _helpMenuItem = new ToolStripMenuItem("Help");
            _aboutMenuItem = new ToolStripMenuItem("About");
        }

        // 準備 ToolStrip 元件
        private void PrepareToolStrip()
        {
            _toolStrip = new ToolStrip();
            _undoToolStripButton = new ToolStripButton("Undo");
            _redoToolStripButton = new ToolStripButton("Redo");
            _pointerToolStripButton = new ToolStripButton("Pointer");
            _rectangleToolStripButton = new ToolStripButton("Rectangle");
            _ellipseToolStripButton = new ToolStripButton("Ellipse");
            _lineToolStripButton = new ToolStripButton("Line");
            _deleteToolStripButton = new ToolStripButton("Delete");
        }

        // 初始化元件
        private void Initialize()
        {
            Width = FORM_WIDTH;
            Height = FORM_HEIGHT;
            Text = "Painter";
            Controls.Add(_toolStrip);
            Controls.Add(_mainMenuStrip);
            SetToolStrip();
            SetMenuStrip();
            SetEventHandler();
            UpdateStripEvent();
        }

        // 設定MenuStrip
        private void SetMenuStrip()
        {
            SetFileMenuItem();
            SetEditMenuItem();
            SetHelpMenuItem();
        }

        // 設定FileMenuStrip
        private void SetFileMenuItem()
        {
            _mainMenuStrip.Items.Add(_fileMenuItem);
            _fileMenuItem.DropDown.Items.Add(_exitMenuItem);
            _exitMenuItem.Image = Properties.Resources.exitIcon;
        }

        // 設定EditMenuStrip
        private void SetEditMenuItem()
        {
            _mainMenuStrip.Items.Add(_editMenuItem);
            _editMenuItem.DropDown.Items.Add(_undoMenuItem);
            _undoMenuItem.Image = Properties.Resources.undoIcon;
            _editMenuItem.DropDown.Items.Add(_redoMenuItem);
            _editMenuItem.DropDown.Items.Add(new ToolStripSeparator());
            _redoMenuItem.Image = Properties.Resources.redoIcon;
            _editMenuItem.DropDown.Items.Add(_shapesMenuItem);
            _shapesMenuItem.DropDown.Items.Add(_pointerMenuItem);
            _pointerMenuItem.Image = Properties.Resources.cursorIcon;
            _shapesMenuItem.DropDown.Items.Add(_rectangleMenuItem);
            _rectangleMenuItem.Image = Properties.Resources.rectangleIcon;
            _shapesMenuItem.DropDown.Items.Add(_ellipseMenuItem);
            _ellipseMenuItem.Image = Properties.Resources.ellipseIcon;
            _shapesMenuItem.DropDown.Items.Add(_lineMenuItem);
            _lineMenuItem.Image = Properties.Resources.lineIcon;
            _editMenuItem.DropDown.Items.Add(new ToolStripSeparator());
            _editMenuItem.DropDown.Items.Add(_deleteMenuItem);
            _deleteMenuItem.Image = Properties.Resources.deleteIcon;
        }

        // 設定HelpMenuStrip
        private void SetHelpMenuItem()
        {
            _mainMenuStrip.Items.Add(_helpMenuItem);
            _helpMenuItem.DropDown.Items.Add(_aboutMenuItem);
            _aboutMenuItem.Image = Properties.Resources.aboutIcon;
        }

        // 設定 tool strip
        private void SetToolStrip()
        {
            _toolStrip.Items.Add(_undoToolStripButton);
            _undoToolStripButton.Image = Properties.Resources.undoIcon;
            _toolStrip.Items.Add(_redoToolStripButton);
            _redoToolStripButton.Image = Properties.Resources.redoIcon;
            _toolStrip.Items.Add(new ToolStripSeparator());
            _toolStrip.Items.Add(_pointerToolStripButton);
            _pointerToolStripButton.Image = Properties.Resources.cursorIcon;
            _toolStrip.Items.Add(_rectangleToolStripButton);
            _rectangleToolStripButton.Image = Properties.Resources.rectangleIcon;
            _toolStrip.Items.Add(_ellipseToolStripButton);
            _ellipseToolStripButton.Image = Properties.Resources.ellipseIcon;
            _toolStrip.Items.Add(_lineToolStripButton);
            _lineToolStripButton.Image = Properties.Resources.lineIcon;
            _toolStrip.Items.Add(new ToolStripSeparator());
            _toolStrip.Items.Add(_deleteToolStripButton);
            _deleteToolStripButton.Image = Properties.Resources.deleteIcon;
        }

        // 游標變化事件
        private void ChangeCursorEvent(Cursor cursor)
        {
            Cursor = cursor;
        }

        // Strip更新事件
        private void UpdateStripEvent()
        {
            _undoMenuItem.Enabled = _presentationModel.UndoMenuItemEnable;
            _redoMenuItem.Enabled = _presentationModel.RedoMenuItemEnable;
            _pointerMenuItem.Enabled = _presentationModel.PointerMenuItemEnable;
            _rectangleMenuItem.Enabled = _presentationModel.RectangleMenuItemEnable;
            _ellipseMenuItem.Enabled = _presentationModel.EllipseMenuItemEnable;
            _lineMenuItem.Enabled = _presentationModel.LineMenuItemEnable;
            _deleteMenuItem.Enabled = _presentationModel.DeleteMenuItemEnable;
            _undoToolStripButton.Enabled = _presentationModel.UndoMenuItemEnable;
            _redoToolStripButton.Enabled = _presentationModel.RedoMenuItemEnable;
            _pointerToolStripButton.Enabled = _presentationModel.PointerMenuItemEnable;
            _rectangleToolStripButton.Enabled = _presentationModel.RectangleMenuItemEnable;
            _ellipseToolStripButton.Enabled = _presentationModel.EllipseMenuItemEnable;
            _lineToolStripButton.Enabled = _presentationModel.LineMenuItemEnable;
            _deleteToolStripButton.Enabled = _presentationModel.DeleteMenuItemEnable;
        }

        // 畫面變化事件
        private void ChangeScreenEvent()
        {
            Invalidate();
        }

        // 設定事件
        private void SetEventHandler()
        {
            MouseDown += ClickMouseDown;
            MouseMove += MoveMouse;
            MouseUp += ClickMouseUp;
            _exitMenuItem.Click += ClickExitMenuItem;
            _undoMenuItem.Click += ClickUndoMenuItem;
            _redoMenuItem.Click += ClickRedoMenuItem;
            _pointerMenuItem.Click += ClickPointerMenuItem;
            _rectangleMenuItem.Click += ClickRectangleMenuItem;
            _ellipseMenuItem.Click += ClickEllipseMenuItem;
            _lineMenuItem.Click += ClickLineMenuItem;
            _deleteMenuItem.Click += ClickDeleteMenuItem;
            _aboutMenuItem.Click += ClickAboutMenuItem;
            _undoToolStripButton.Click += ClickUndoMenuItem;
            _redoToolStripButton.Click += ClickRedoMenuItem;
            _pointerToolStripButton.Click += ClickPointerMenuItem;
            _rectangleToolStripButton.Click += ClickRectangleMenuItem;
            _ellipseToolStripButton.Click += ClickEllipseMenuItem;
            _lineToolStripButton.Click += ClickLineMenuItem;
            _deleteToolStripButton.Click += ClickDeleteMenuItem;
            _presentationModel.CursorChange += ChangeCursorEvent;
            _presentationModel.StripChange += UpdateStripEvent;
            _presentationModel.ScreenChange += ChangeScreenEvent;
        }

        // 按下左鍵
        private void ClickMouseDown(Object sender, MouseEventArgs eventArgument)
        {
            _presentationModel.ClickMouseDown(eventArgument.Location, eventArgument.Button);
        }

        // 拖拉滑鼠
        private void MoveMouse(Object sender, MouseEventArgs eventArgument)
        {
            _presentationModel.MoveMouse(eventArgument.Location);
        }

        // 放開滑鼠
        private void ClickMouseUp(Object sender, MouseEventArgs eventArgument)
        {
            _presentationModel.ClickMouseUp(eventArgument.Location);
        }

        // 點擊ExitMenuItem
        private void ClickExitMenuItem(Object sender, EventArgs eventArgument)
        {
            Application.Exit();
        }

        // 點擊UndoMenuItem
        private void ClickUndoMenuItem(Object sender, EventArgs eventArgument)
        {
            _presentationModel.ClickUndoMenuItem();
        }

        // 點擊RedoMenuItem
        private void ClickRedoMenuItem(Object sender, EventArgs eventArgument)
        {
            _presentationModel.ClickRedoMenuItem();
        }

        // 點擊PointerMenuItem
        private void ClickPointerMenuItem(Object sender, EventArgs eventArgument)
        {
            _presentationModel.ClickPointerMenuItem();
        }

        // 點擊RectangleMenuItem
        private void ClickRectangleMenuItem(Object sender, EventArgs eventArgument)
        {
            _presentationModel.ClickRectangleMenuItem();
        }

        // 點擊EllipseMenuItem
        private void ClickEllipseMenuItem(Object sender, EventArgs eventArgument)
        {
            _presentationModel.ClickEllipseMenuItem();
        }

        //點擊LineMenuItem
        private void ClickLineMenuItem(Object sender, EventArgs eventArgument)
        {
            _presentationModel.ClickLineMenuItem();
        }

        // 點擊DeleteMenuItem
        private void ClickDeleteMenuItem(Object sender, EventArgs eventArgument)
        {
            _presentationModel.ClickDeleteMenuItem();
        }

        // 點擊AboutMenuItem
        private void ClickAboutMenuItem(Object sender, EventArgs eventArgument)
        {
            using (Form aboutDialog = new AboutForm())
            {
                aboutDialog.ShowDialog();
            }
        }

        // 畫圖
        protected override void OnPaint(PaintEventArgs eventArgument)
        {
            base.OnPaint(eventArgument);
            _presentationModel.Draw(eventArgument.Graphics);
        }
    }
}

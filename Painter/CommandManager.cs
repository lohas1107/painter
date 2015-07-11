using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Painter
{
    class CommandManager
    {
        List<Command> _undoList;
        List<Command> _redoList;

        public CommandManager()
        {
            _undoList = new List<Command>();
            _redoList = new List<Command>();
        }

        // 執行命令
        public void DoCommand(Command command)
        {
            command.Execute();
            _undoList.Add(command);
            _redoList.Clear();
        }

        // 復原命令
        public void UndoCommand()
        {
            Command lastCommand = _undoList[_undoList.Count - 1];
            _undoList.Remove(lastCommand);
            lastCommand.Undo();
            _redoList.Add(lastCommand);
        }

        // 重複命令
        public void RedoCommand()
        {
            Command lastCommand = _redoList[_redoList.Count - 1];
            _redoList.Remove(lastCommand);
            lastCommand.Execute();
            _undoList.Add(lastCommand);
        }

        public bool UndoEnable
        {
            get
            {
                return _undoList.Count > 0;
            }
        }

        public bool RedoEnble
        {
            get
            {
                return _redoList.Count > 0;
            }
        }
    }
}

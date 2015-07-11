using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Painter
{
    abstract public class Command
    {
        // 執行
        abstract public void Execute();

        // 復原
        abstract public void Undo();
    }
}

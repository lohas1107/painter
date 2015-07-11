using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Painter
{
    class DeleteShapeCommand : Command
    {
        private Shape _shape;
        private ShapeModel _shapeModel;
        private int _shapeIndex;

        public DeleteShapeCommand(Shape shape, ShapeModel shapeModel)
        {
            _shape = shape;
            _shapeModel = shapeModel;
        }

        // 執行命令
        override public void Execute()
        {
            _shapeIndex = _shapeModel.ShapeList.GetIndex(_shape);
            _shapeModel.DeleteShape(_shape);
            _shape.IsSelect = false;
            _shapeModel.SelectedShape = null;
        }

        // 復原命令
        override public void Undo()
        {
            _shapeModel.ShapeList.InsertShape(_shapeIndex, _shape);
        }
    }
}

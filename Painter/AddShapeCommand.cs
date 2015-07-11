using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Painter
{
    class AddShapeCommand : Command
    {
        private Shape _shape;
        private ShapeModel _shapeModel;

        public AddShapeCommand(Shape shape, ShapeModel shapeModel)
        {
            _shape = shape;
            _shapeModel = shapeModel;
        }

        // 執行
        override public void Execute()
        {
            _shapeModel.AddShape(_shape);          
        }

        // 復原
        override public void Undo()
        {
            _shapeModel.DeleteShape(_shape);
            _shape.IsSelect = false;
            _shapeModel.SelectedShape = null;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Painter
{
    class Program
    {
        static void Main(string[] args)
        {
            PresentationModel presentationModel = new PresentationModel(new ShapeModel());
            Form form = new PainterForm(presentationModel);
            Application.Run(form);
        }
    }
}

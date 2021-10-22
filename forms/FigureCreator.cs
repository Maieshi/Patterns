using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace forms
{
    public abstract  class FigureCreator
    {
        public abstract Figure Create(int x, int y, int width, int height, Color color);
        
    }
}

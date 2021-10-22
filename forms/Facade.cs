using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace forms
{
    class Facade
    {
        Manipulator manipulator;
        Group group;

        public Facade(Group gr,Manipulator man)
        {
            manipulator = man;
            group = gr;
        }

        public void FDeltaManipulator(Point p)
        {
            manipulator.Delta(out manipulator.dx, out manipulator.dx1, out manipulator.dy, out manipulator.dy1, p);
        }
        public void FDeltaGroup(Point p)
        {
           group.Delta(out group.dx, out group.dx1, out group.dy, out group.dy1, p);
        }
    }
}

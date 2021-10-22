using System.Collections.Generic;
using System.Drawing;

namespace forms
{
    public abstract class Prototype
    {

        public static List<Figure> copyFigures = new List<Figure>();

        public virtual void Clone()
        {

        }

        public virtual void Spawn(Point Spawnpoint, Figure currentF, List<FigureCreator> figC, List<Figure> figures, Graphics gr)
        {

        }



        //    public Manipulator manipulator;

        //    public void Clone()
        //    {
        //        manipulator.CopytFig = null;
        //        var rc = new Rectangle.RectCreator();
        //        var tr = new Triangle.TrianCreator();

        //        var f = manipulator.CurrentFig;
        //        if (manipulator.CurrentFig as Triangle != null)
        //        {
        //            manipulator.CopytFig = tr.Create(f.x, f.y, f.width, f.height, f.Color);
        //        }
        //        else
        //        {
        //            manipulator.CopytFig = rc.Create(f.x, f.y, f.width, f.height, f.Color);
        //        }
        //    }

        //    public void spawn(Point Spawnpoint, Figure currentF, List<FigureCreator> figC, List<Figure> figures,
        //        Graphics gr)
        //    {
        //        var rc = new Rectangle.RectCreator();
        //        var tr = new Triangle.TrianCreator();

        //        var b = manipulator.CopytFig as Triangle;
        //        if (b == null)
        //        {
        //            currentF = rc.Create(Spawnpoint.X, Spawnpoint.Y,
        //                Spawnpoint.X + (manipulator.CopytFig.width - manipulator.CopytFig.x),
        //                Spawnpoint.Y + (manipulator.CopytFig.height - manipulator.CopytFig.y), manipulator.CopytFig.Color);
        //            figC.Add(rc);
        //        }
        //        else
        //        {
        //            currentF = tr.Create(Spawnpoint.X, Spawnpoint.Y,
        //                Spawnpoint.X + (manipulator.CopytFig.width - manipulator.CopytFig.x),
        //                Spawnpoint.Y + (manipulator.CopytFig.height - manipulator.CopytFig.y), manipulator.CopytFig.Color);
        //            figC.Add(tr);
        //        }


        //        figures.Add(currentF);
        //        currentF.Draw(gr);
        //    }
    }
}
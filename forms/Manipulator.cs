using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace forms
{
    public class Manipulator : Figure,IStrategy
    {
        public Figure CurrentFig { get; protected set; }

        public Figure CopytFig { get; set; }

        public int corner = -1;


        private Manipulator ()
        {

        }

        private static Manipulator instance;

        public static Manipulator getInstance()
        {
            if (instance == null)
            {
                instance = new Manipulator();
            }
            return instance;
        }


        public void Attach(Figure f)
        {
            CurrentFig = f;
            x = f.x;
            y = f.y;
            width = f.width;
            height = f.height;

            //  Debug.WriteLine(f.x+" "+f.y+" "+f.width+" "+f.height);
            //  Debug.WriteLine(x+" "+y+" "+width+" "+height);


        }

        public override bool Click(Point p)
        {
            corner = -1;
            click = false;


            if (CurrentFig != null)
            {

                if (p.X > CurrentFig.x - 5 && p.X < CurrentFig.x + 5)//0,3
                {
                    if (p.Y > CurrentFig.y - 5 && p.Y < CurrentFig.y + 5) corner = 0;
                    else if (p.Y > CurrentFig.height - 5 && p.Y < CurrentFig.height + 5) corner = 3;

                    click = true;
                }
                else if (p.X > CurrentFig.width - 5 && p.X < CurrentFig.width + 5)//1,2
                {
                    if (p.Y > CurrentFig.y - 5 && p.Y < CurrentFig.y + 5) corner = 1;
                    else if (p.Y > CurrentFig.height - 5 && p.Y < CurrentFig.height + 5) corner = 2;

                    click = true;
                }
                else if (p.X > (CurrentFig.x + CurrentFig.width) / 2 - 5 && p.X < (CurrentFig.x + CurrentFig.width) / 2 + 5)//4
                {
                    if (p.Y > (CurrentFig.y + CurrentFig.height) / 2 - 5 && p.Y < (CurrentFig.y + CurrentFig.height) / 2 + 5) corner = 4;

                    click = true;
                }

            }

            return click;
        }

        public override void Delta(out int dx, out int dx1, out int dy, out int dy1, Point p1)
        {
            dx = p1.X - x;

            dy = p1.Y - y;
            dx1 = p1.X - width;
            dy1 = p1.Y - height;


            CurrentFig.Delta(out CurrentFig.dx, out CurrentFig.dy, out CurrentFig.dx1, out CurrentFig.dy1, p1);


        }

        public override void Draw(Graphics gr)
        {


            //0       1

            //    4

            //3       2

            //-1 -не выбрано


            if (CurrentFig != null)
            {
                gr.FillEllipse(new SolidBrush((corner == 0) ? Color.Black : Color.Blue), new RectangleF(new PointF(CurrentFig.x - 5, CurrentFig.y - 5), new SizeF(10, 10)));//0
                gr.FillEllipse(new SolidBrush((corner == 1) ? Color.Black : Color.Blue), new RectangleF(new PointF(CurrentFig.width - 5, CurrentFig.y - 5), new SizeF(10, 10)));//1
                gr.FillEllipse(new SolidBrush((corner == 2) ? Color.Black : Color.Blue), new RectangleF(new PointF(CurrentFig.width - 5, CurrentFig.height - 5), new SizeF(10, 10)));//2
                gr.FillEllipse(new SolidBrush((corner == 3) ? Color.Black : Color.Blue), new RectangleF(new PointF(CurrentFig.x - 5, CurrentFig.height - 5), new SizeF(10, 10)));//3
                gr.FillEllipse(new SolidBrush((corner == 4) ? Color.Black : Color.Blue), new RectangleF(new PointF((CurrentFig.x + CurrentFig.width) / 2 - 5, (CurrentFig.y + CurrentFig.height) / 2 - 5), new SizeF(10, 10)));//4

                Point[] rectanglePoints = new Point[4];
                rectanglePoints[0] = new Point(CurrentFig.x, CurrentFig.y);
                rectanglePoints[1] = new Point(CurrentFig.width, CurrentFig.y);
                rectanglePoints[2] = new Point(CurrentFig.width, CurrentFig.height);
                rectanglePoints[3] = new Point(CurrentFig.x, CurrentFig.height);
                gr.DrawPolygon(new Pen(Color.Blue), rectanglePoints);
            }
        }

        public override void DrawCur(Graphics gr)
        {
            gr.FillEllipse(new SolidBrush((corner == 0) ? Color.Black : Color.Blue), new RectangleF(new PointF(CurrentFig.x - 5, CurrentFig.y - 5), new SizeF(10, 10)));//0
            gr.FillEllipse(new SolidBrush((corner == 1) ? Color.Black : Color.Blue), new RectangleF(new PointF(CurrentFig.width - 5, CurrentFig.y - 5), new SizeF(10, 10)));//1
            gr.FillEllipse(new SolidBrush((corner == 2) ? Color.Black : Color.Blue), new RectangleF(new PointF(CurrentFig.width - 5, CurrentFig.height - 5), new SizeF(10, 10)));//2
            gr.FillEllipse(new SolidBrush((corner == 3) ? Color.Black : Color.Blue), new RectangleF(new PointF(CurrentFig.x - 5, CurrentFig.height - 5), new SizeF(10, 10)));//3
            gr.FillEllipse(new SolidBrush((corner == 4) ? Color.Black : Color.Blue), new RectangleF(new PointF((CurrentFig.x + CurrentFig.width) / 2 - 5, (CurrentFig.y + CurrentFig.height) / 2 - 5), new SizeF(10, 10)));//4

            Point[] rectanglePoints = new Point[4];
            rectanglePoints[0] = new Point(CurrentFig.x, CurrentFig.y);
            rectanglePoints[1] = new Point(CurrentFig.width, CurrentFig.y);
            rectanglePoints[2] = new Point(CurrentFig.width, CurrentFig.height);
            rectanglePoints[3] = new Point(CurrentFig.x, CurrentFig.height);
            gr.DrawPolygon(new Pen(Color.Black), rectanglePoints);


        }



        public override void Move(Point p)
        {
            if (corner == 4)
            {
                x = p.X - dx;
                y = p.Y - dy;
                width = p.X - dx1;
                height = p.Y - dy1;

                CurrentFig.x = x;
                CurrentFig.y = y;
                CurrentFig.height = height;
                CurrentFig.width = width;
            }

        }



        public  void Smena(Point p)
        {

            //0       1

            //    4

            //3       2

            //-1 -не выбрано
            switch (corner)
            {
                case 0:
                    x = p.X - dx;
                    y = p.Y - dy;

                    CurrentFig.x = x;
                    CurrentFig.y = y;
                    break;

                case 1:
                    width = p.X - dx1;
                    y = p.Y - dy;

                    CurrentFig.width = width;
                    CurrentFig.y = y;
                    break;

                case 2:
                    width = p.X - dx1;
                    height = p.Y - dy1;

                    CurrentFig.width = width;
                    CurrentFig.height = height;
                    break;

                case 3:
                    x = p.X - dx;
                    height = p.Y - dy1;

                    CurrentFig.x = x;
                    CurrentFig.height = height;
                    break;

            }
        }
        public void SetNull()
        {
            CurrentFig = null;
        }

        public class PrototypeM : Prototype
        {
            public Manipulator manipulator = new Manipulator();
            
            public override void Clone()
            {

                    
                    copyFigures.Clear();
                    var rc = new Rectangle.RectCreator();
                    var tr = new Triangle.TrianCreator();

                    var f = manipulator.CurrentFig;
                    if (manipulator.CurrentFig as Triangle != null)
                    {
                    copyFigures.Add(tr.Create(f.x, f.y, f.width, f.height, f.Color));
                    }
                    else
                    {
                    copyFigures.Add(rc.Create(f.x, f.y, f.width, f.height, f.Color));
                    }
                
            }

            public override void Spawn(Point Spawnpoint, Figure currentF, List<FigureCreator> figC, List<Figure> figures, Graphics gr)
            {
                var rc = new Rectangle.RectCreator();
                var tr = new Triangle.TrianCreator();

                
                if (copyFigures[0] as Triangle == null)
                {
                    currentF = rc.Create(Spawnpoint.X, Spawnpoint.Y,
                        Spawnpoint.X + (copyFigures[0].width - copyFigures[0].x),
                        Spawnpoint.Y + (copyFigures[0].height - copyFigures[0].y), copyFigures[0].Color);
                    figC.Add(rc);
                }
                else
                {
                    currentF = tr.Create(Spawnpoint.X, Spawnpoint.Y,
                        Spawnpoint.X + (copyFigures[0].width - copyFigures[0].x),
                        Spawnpoint.Y + (copyFigures[0].height - copyFigures[0].y), copyFigures[0].Color);
                    figC.Add(tr);
                }


                figures.Add(currentF);
                currentF.Draw(gr);
            }
        }


    }

}

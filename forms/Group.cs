using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
namespace forms
{
    class Group : Figure,IStrategy
    {
        public List<Figure> figures { get; protected set; } = new List<Figure>();

        public List<Figure> copyF = new List<Figure>();

        public int corner = -1;

        public float lastX, lastY, lastW, lastH;

        public float scaleX, scaleY;

        private Group()
        {

        }

        private static Group instance;

        public static Group getInstance()
        {
            if(instance==null)
            {
                instance = new Group();
            }
            return instance;
        }

        public override bool Click(Point p)
        {

            if (figures.Count != 0)
            {
                corner = -1;
                click = false;

                if (p.X > x - 5 && p.X < x + 5)//0,3
                {
                    if (p.Y > y - 5 && p.Y < y + 5) corner = 0;
                    else if (p.Y > height - 5 && p.Y < height + 5) corner = 3;

                    click = true;
                }
                else if (p.X > width - 5 && p.X < width + 5)//1,2
                {
                    if (p.Y > y - 5 && p.Y < y + 5) corner = 1;
                    else if (p.Y > height - 5 && p.Y < height + 5) corner = 2;

                    click = true;
                }
                else if (p.X > (x + width) / 2 - 5 && p.X < (x + width) / 2 + 5)//4
                {
                    if (p.Y > (y + height) / 2 - 5 && p.Y < (y + height) / 2 + 5) corner = 4;

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


            foreach (var f in figures)
            {
                f.Delta(out f.dx, out f.dx1, out f.dy, out f.dy1, p1);
            }
        }

        public override void Draw(Graphics gr)
        {
            if(figures.Count!=0)
            {
                gr.FillEllipse(new SolidBrush((corner == 0) ? Color.Black : Color.Blue), new RectangleF(new PointF(x - 5, y - 5), new SizeF(10, 10)));//0
                gr.FillEllipse(new SolidBrush((corner == 1) ? Color.Black : Color.Blue), new RectangleF(new PointF(width - 5, y - 5), new SizeF(10, 10)));//1
                gr.FillEllipse(new SolidBrush((corner == 2) ? Color.Black : Color.Blue), new RectangleF(new PointF(width - 5, height - 5), new SizeF(10, 10)));//2
                gr.FillEllipse(new SolidBrush((corner == 3) ? Color.Black : Color.Blue), new RectangleF(new PointF(x - 5, height - 5), new SizeF(10, 10)));//3
                gr.FillEllipse(new SolidBrush((corner == 4) ? Color.Black : Color.Blue), new RectangleF(new PointF((x +width) / 2 - 5, (y + height) / 2 - 5), new SizeF(10, 10)));//4

                Point[] rectanglePoints = new Point[4];
                rectanglePoints[0] = new Point(x, y);
                rectanglePoints[1] = new Point(width,y);
                rectanglePoints[2] = new Point(width, height);
                rectanglePoints[3] = new Point(x, height);
                gr.DrawPolygon(new Pen(Color.Blue), rectanglePoints);
            }
        }

        public override void DrawCur(Graphics gr)
        {
            throw new NotImplementedException();
        }

        public override void Move(Point p)
        {
            if (corner == 4)
            {
                x = p.X - dx;
                y = p.Y - dy;
                width = p.X - dx1;
                height = p.Y - dy1;

                foreach(var f in figures)
                {
                    f.x = p.X - f.dx;
                    f.y = p.Y - f.dy;
                    f.width = p.X - f.dx1;
                    f.height = p.Y - f.dy1;
                }
            }
        }



        public  void Smena(Point p)
        {

            

            switch (corner)
            {
                case 0:
                    x = p.X - dx;
                    y = p.Y - dy;

                    scaleX = (lastW - p.X) / (lastW - lastX);
                    scaleY = (lastH - p.Y) / (lastH - lastY);
                    for (int i = 0; i < figures.Count; i++)
                    {

                        figures[i].x = (int)(copyF[i].x * scaleX + (1 - scaleX) * width);
                        figures[i].y = (int)(copyF[i].y * scaleY + (1 - scaleY) * height);
                        figures[i].width = (int)(copyF[i].width * scaleX + (1 - scaleX) * width);
                        figures[i].height = (int)(copyF[i].height * scaleY + (1 - scaleY) * height);
                    }
                    break;

                case 1:
                    width = p.X - dx1;
                    y = p.Y - dy;

                    scaleX = (p.X-lastX)/(lastW-lastX);
                    scaleY = (lastH - p.Y ) / (lastH - lastY);
                    for (int i = 0; i < figures.Count; i++)
                    {
                        figures[i].x = (int)(copyF[i].x * scaleX + (1 - scaleX) * x);
                        figures[i].y = (int)(copyF[i].y * scaleY + (1 - scaleY) * height);
                        figures[i].width = (int)(copyF[i].width* scaleX + (1 - scaleX) * x);
                        figures[i].height = (int)(copyF[i].height * scaleY + (1 - scaleY) * height);
                    }
                    break;

                case 2:
                    width = p.X - dx1;
                    height = p.Y - dy1;

                    scaleX = (p.X - lastX) / (lastW - lastX);
                    scaleY = (p.Y - lastY) / (lastH - lastY);

                    for (int i = 0; i < figures.Count; i++)
                    {

                        figures[i].x = (int)(copyF[i].x * scaleX + (1 - scaleX) * x);
                        figures[i].y = (int)(copyF[i].y * scaleY + (1 - scaleY) * y);
                        figures[i].width = (int)(copyF[i].width * scaleX + (1 - scaleX) * x);
                        figures[i].height = (int)(copyF[i].height * scaleY + (1 - scaleY) * y);
                    }
                    break;

                case 3:
                    x = p.X - dx;
                    height = p.Y - dy1;

                    scaleX = (lastW - p.X) / (lastW - lastX);
                    scaleY = (p.Y - lastY) / (lastH - lastY);
 
                    for (int i = 0; i < figures.Count; i++)
                    {

                        figures[i].x = (int)(copyF[i].x * scaleX + (1 - scaleX) * width);
                        figures[i].y = (int)(copyF[i].y * scaleY + (1 - scaleY) * y);
                        figures[i].width = (int)(copyF[i].width * scaleX + (1 - scaleX) * width);
                        figures[i].height = (int)(copyF[i].height * scaleY + (1 - scaleY) * y);
                    }
                    break;

            }

            

            
        }

        public void Add(Figure f)
        {
            figures.Add(f);
            setSize();
           // copyList();
        }

        public void Clear() 
        {
            figures.Clear();
            setSize();
            //copyList();
        }

        public void Update(Figure f)
        {
            if(figures.Contains(f))
            {
                figures.Remove(f);
                setSize();
               // copyList();
            }
            
        }
        private void setSize()
        {
            if(figures.Count!=0)
            {
                x = figures[0].x;
                y = figures[0].y;
                width = figures[0].width;
                height = figures[0].height;

                if(figures.Count>1)
                {
                    foreach (var f in figures)
                    {
                        if (f.x < x) x = f.x;
                        if (f.y < y) y = f.y;
                        if (f.width > width) width = f.width;
                        if (f.height > height) height= f.height;
                    }
                }
            }
            else
            {
                x = y = width = height = 0;
            }
        }

        

         
        public void copyList()
        {
            copyF.Clear();
            var rc = new Rectangle.RectCreator();
            var tc = new Triangle.TrianCreator();
            foreach (var f in figures)
            {
                var tr = f as Triangle;
                if (tr != null)
                {
                    
                    copyF.Add(tc.Create(f.x,f.y,f.width,f.height,f.Color));
                }
                else
                {
                    copyF.Add(rc.Create(f.x, f.y, f.width, f.height, f.Color));
                }
            }
        }

        public class PrototypeG : Prototype
        {

            public Group group = new Group();

            public Point p;

            public override void Clone()
            {
                copyFigures.Clear();

                Figure fig;

                var rc = new Rectangle.RectCreator();
                var tr = new Triangle.TrianCreator();
                foreach (var f in group.figures)
                {
                    if (f as Triangle != null)
                    {
                        fig = tr.Create(f.x, f.y, f.width, f.height, f.Color);
                        fig.Delta(out fig.dx,out fig.dx1,out fig.dy, out fig.dy1,p);
                        copyFigures.Add(fig);
                    }
                    else
                    {
                        fig = rc.Create(f.x, f.y, f.width, f.height, f.Color);
                        fig.Delta(out fig.dx, out fig.dx1, out fig.dy, out fig.dy1, p);
                        copyFigures.Add(fig);
                    }

                }


            }

            public override void Spawn(Point Spawnpoint, Figure currentF, List<FigureCreator> figC, List<Figure> figures, Graphics gr)
            {
                var rc = new Rectangle.RectCreator();
                var tr = new Triangle.TrianCreator();



                foreach (var f in copyFigures)
                {

                    


                    if (f as Triangle == null)
                    {
                        currentF = rc.Create(Spawnpoint.X-f.dx, Spawnpoint.Y - f.dy, Spawnpoint.X - f.dx1, Spawnpoint.Y - f.dy1, f.Color);
                        
                        figC.Add(rc);
                    }
                    else
                    {
                        currentF = tr.Create(Spawnpoint.X-f.dx, Spawnpoint.Y - f.dy, Spawnpoint.X - f.dx1, Spawnpoint.Y - f.dy1, f.Color);
                        
                        figC.Add(tr);
                    }



                    figures.Add(currentF);

                    

                    currentF.Draw(gr);


                }
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Drawing;

namespace forms
{
    class Rectangle : Figure, IStrategy
    {



        private Rectangle(int x, int y, int width, int height, Color color)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
            this.Color = color;
        }

        public override bool Click(Point p)
        {
            if (x < width && y < height)
            {
                if (p.X <= width && p.X >= x)
                    if (p.Y >= y && p.Y <= height)
                        click = true;
            }
            if (x > width && y > height)
            {
                if (p.X >= width && p.X <= x)
                    if (p.Y <= y && p.Y >= height)
                        click = true;
            }
            if (x < width && y > height)
            {
                if (p.X <= width && p.X >= x)
                    if (p.Y <= y && p.Y >= height)
                        click = true;
            }
            if (x > width && y < height)
            {
                if (p.X >= width && p.X <= x)
                    if (p.Y >= y && p.Y <= height)
                        click = true;
            }
            return click;

        }

        public override void Move(Point p)
        {



            x = p.X - dx;
            y = p.Y - dy;
            width = p.X - dx1;
            height = p.Y - dy1;

        }

        //public override void Resize(Point point, Point point1)
        //{
        //    x = point.X - point1.X;
        //    y = point.Y - point1.Y;
        //}
        public override void Delta(out int dx, out int dx1, out int dy, out int dy1, Point p1)

        {


            dx = p1.X - x;
            dy = p1.Y - y;
            dx1 = p1.X - width;
            dy1 = p1.Y - height;
            
        }

        public  void Smena(Point p)
        {
            x = p.X - dx;
            y = p.Y - dy;
        }
        public override void Draw(Graphics gr)
        {
            Point[] rectanglePoints = new Point[4];
            rectanglePoints[0] = new Point(x, y);
            rectanglePoints[1] = new Point(width, y);
            rectanglePoints[2] = new Point(width, height);
            rectanglePoints[3] = new Point(x, height);
            gr.FillPolygon(new SolidBrush(Color), rectanglePoints);
        }
        public override void DrawCur(Graphics gr)
        {
            Point[] rectanglePoints = new Point[4];
            rectanglePoints[0] = new Point(x, y);
            rectanglePoints[1] = new Point(width, y);
            rectanglePoints[2] = new Point(width, height);
            rectanglePoints[3] = new Point(x, height);
            gr.DrawPolygon(new Pen(Color), rectanglePoints);
        }


        public class RectCreator : FigureCreator
        {
            

            public override Figure Create(int x, int y, int width, int height, Color color)
            {
                return  new Rectangle(x, y, width, height, color);
            }
        }


    }
}

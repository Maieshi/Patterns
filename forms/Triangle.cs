using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
namespace forms
{
    class Triangle : Figure, IStrategy
    {




        public Triangle(int x, int y, int width, int height, Color color)
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

        public override void Delta(out int dx, out int dx1, out int dy, out int dy1, Point p1)

        {
            dx = p1.X - x;
            dy = p1.Y - y;
            dx1 = p1.X - width;
            dy1 = p1.Y - height;
        }
        public override void Draw(Graphics gr)
        {
            Point[] trianglePoints = new Point[3];
            trianglePoints[0] = new Point(x, height);
            trianglePoints[2] = new Point(width, height);
            trianglePoints[1] = new Point((x + width) / 2, y);
            gr.FillPolygon(new SolidBrush(Color), trianglePoints);
        }
        public override void DrawCur(Graphics gr)
        {
            Point[] trianglePoints = new Point[3];
            trianglePoints[0] = new Point(x, height);
            trianglePoints[2] = new Point(width, height);
            trianglePoints[1] = new Point((x + width) / 2, y);
            gr.DrawPolygon(new Pen(Color), trianglePoints);
        }
        public  void Smena(Point p)
        {
            x = p.X - dx;
            y = p.Y - dy;

            
        }

        public override void Move(Point p)
        {



            x = p.X - dx;
            y = p.Y - dy;
            width = p.X - dx1;
            height = p.Y - dy1;

        }

        public class TrianCreator : FigureCreator
        {


            public override Figure Create(int x, int y, int width, int height, Color color)
            {
                return new Triangle(x, y, width, height, color);
            }
        }

    }
}

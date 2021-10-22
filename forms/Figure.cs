using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace forms
{
    public abstract class Figure
    {

        public int x;
        public int y;
        public int width;
        public int height;
        public Color Color;
        public bool click = false;

        public int dx = 0, dy = 0, dx1 = 0, dy1 = 0;


        public abstract void Draw(Graphics gr);
        public abstract void DrawCur(Graphics gr);

        public abstract bool Click(Point point);
        public abstract void Delta(out int dx, out int dx1, out int dy, out int dy1, Point p1);
        //public abstract void Smena(Point p);
        public abstract void Move(Point p);

    }
}

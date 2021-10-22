using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace forms
{
    class Context
    {
        public IStrategy strategy;

        public Context(IStrategy str)
        {
            strategy = str;
        }

        public void Smena(Point p)
        {
            strategy.Smena(p);
        }
    }
}

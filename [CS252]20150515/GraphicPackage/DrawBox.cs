using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GraphicPackage
{
    class DrawBox
    {
        Graphics g;
        Pen pen;

        private int DefaultX = 100;
        private int DefaultY = 100;

        public DrawBox(Graphics g) 
        {
            this.g = g ;
        }

        public void DoIt(int width, int height)
        {
            pen = new Pen(Color.Pink, 1);
            g.DrawLine(pen, DefaultX, DefaultY, DefaultX + width, DefaultY);
            g.DrawLine(pen, DefaultX, DefaultY, DefaultX, DefaultY + height);
            g.DrawLine(pen, DefaultX, DefaultY + height, DefaultX + width, DefaultY + height);
            g.DrawLine(pen, DefaultX + width, DefaultY, DefaultX + width, DefaultY + height);
        }

        public void Clear()
        {
           g.Clear(Color.WhiteSmoke);
        }
    }
}

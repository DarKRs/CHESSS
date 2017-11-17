using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cheees
{
    class TileChess
    {
        public int xReal, yReal;
        public int x,y;
        public Figure currentFigure = null;


        public void draw(Graphics g, string color)
        {
            
            if (color == "BLACK") { g.FillRectangle(Brushes.DarkCyan, xReal, yReal, 60, 60); }
            if (color == "WHITE") { g.FillRectangle(Brushes.White, xReal, yReal, 60, 60); }
        }

        public void drawFigure(Graphics g, Figure figure)
        {
            figure.draw(g, xReal, yReal, figure.ChessColor);
        }

        public bool haveFigure(Figure figure)
        {
            if(figure.x == x && figure.y == y) { return true; }
            else { return false; }
        }
    }
}

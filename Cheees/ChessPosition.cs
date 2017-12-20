using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cheees
{
    public class ChessPosition
    {
        public int x;
        public int y;
        public int PriceTile;
        public Figure TileFigure;

        public ChessPosition(int x1, int y1,Figure fig)
        {
            x = x1;
            y = y1;
            PriceTile = 50;
            TileFigure = fig;
        }
    }
}

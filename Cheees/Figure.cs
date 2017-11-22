using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cheees
{
   public abstract class Figure
    {
        protected Random rnd = new Random();
        public string Name;
        public int x;
        public int y;
        public int Price;
        public string ChessColor;
        public string local = Directory.GetCurrentDirectory();

        public abstract ChessPosition move(ChessBoard chessBoard);

        public abstract int AlpBet(ChessBoard chessBoard, int ScoreDepth = 0, int Depth = 1);

        public abstract void draw(Graphics g, int x, int y, string ChessColor);

    }
}

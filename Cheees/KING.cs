using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cheees
{
    class KING : Figure
    {
        public KING(string color)
        {
            int x = 0;
            int y = 0;
            this.ChessColor = color;
        }
        public override void draw(Graphics g, int x, int y, string ChessColor)
        {
            if (ChessColor == "BLACK")
            {
                Image img = Image.FromFile("C:\\GitHub\\jom\\Cheeeeees\\Cheees\\Cheees\\KING_BLACK.png");
                g.DrawImage(img, new Point(x, y));
            }
            if (ChessColor == "WHITE")
            {
                Image img = Image.FromFile("C:\\GitHub\\jom\\Cheeeeees\\Cheees\\Cheees\\KING_WHITE.png");
                g.DrawImage(img, new Point(x, y));
            }
        }

        public override void update()
        {
            throw new NotImplementedException();
        }
    }
}

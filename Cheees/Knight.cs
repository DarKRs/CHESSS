using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cheees
{
    class Knight : Figure
    {
        public Knight(string color)
        {
            int x = 0;
            int y = 0;
            this.ChessColor = color;
            Price = 200;
        }

        override public int AlpBet(ChessBoard chessBoard)
        {
            int Score1 = 0;
            int Score2 = 0;
            List<ChessPosition> moveList = new List<ChessPosition>();
            List<Figure> allFigure = new List<Figure>();
            allFigure.AddRange(chessBoard.CheeesBlack);
            allFigure.AddRange(chessBoard.CheeesWhite);
            List<Figure> White = new List<Figure>();
            List<Figure> Black = new List<Figure>();
            Black.AddRange(chessBoard.CheeesBlack);
            White.AddRange(chessBoard.CheeesWhite);


            if (ChessColor == "WHITE")
            {
                ChessPosition y1 = new ChessPosition(x, y - 1);
                ChessPosition y2 = new ChessPosition(x, y - 2);

                moveList.Add(y1);
                moveList.Add(y2);


                foreach (Figure figure in White)
                {
                    if ((y - 1 == figure.y && x == figure.x) || y - 1 < 0)
                    {
                        Score1 = 0;

                    }
                    if ((y - 2 == figure.y && x == figure.x) || y - 2 < 0)
                    {
                        Score2 = 0;
                    }
                }
                foreach (Figure figure in Black)
                {
                    if ((y - 1 == figure.y && x == figure.x) || y - 1 < 0)
                    {
                        Score1 = 100;

                    }
                    if ((y - 2 == figure.y && x == figure.x) || y - 2 < 0)
                    {
                        Score2 = 100;
                    }
                }
                foreach (Figure figure in allFigure)
                {
                    if ((y - 1 != figure.y && x != figure.x) || y - 1 < 0)
                    {
                        Score1 = 50;

                    }
                    if ((y - 2 != figure.y && x != figure.x) || y - 2 < 0)
                    {
                        Score2 = 50;
                    }
                }

            }
            if (ChessColor == "BLACK")
            {
                ChessPosition y1 = new ChessPosition(x, y + 1);
                ChessPosition y2 = new ChessPosition(x, y + 2);

                moveList.Add(y1);
                moveList.Add(y2);


                foreach (Figure figure in allFigure)
                {
                    if ((y + 1 == figure.y && x == figure.x) || y + 1 < 0)
                    {
                        moveList.Remove(y1);

                    }
                    if ((y + 2 == figure.y && x == figure.x) || y + 2 < 0)
                    {
                        moveList.Remove(y2);
                    }
                }
            }
            if (Score1 > Score2)
            {
                return Score1;
            }
            if (Score2 > Score1)
            {
                return Score2;
            }

            return Score1;

        }

        override public ChessPosition move(ChessBoard chessBoard)
        {
            List<ChessPosition> moveList = new List<ChessPosition>();
            List<ChessPosition> kill2 = new List<ChessPosition>();
            int buffer = 0;
            int Best = 0;
            if(chessBoard.chessTiles[this.y - 3, this.x - 1].currentFigure == null)
            {
                moveList.Add(new ChessPosition(this.x-1, this.y -3));
            }
            if (chessBoard.chessTiles[this.y - 3, this.x - 1].currentFigure.ChessColor != this.ChessColor)
            {
                ChessPosition Kill = new ChessPosition(this.x - 1,this.y - 3);
                Kill.PriceTile = 100 + chessBoard.chessTiles[this.y-3, this.x-1].currentFigure.Price;
                kill2.Add(Kill);
            }
            /////////////////////////////////////////////////////////////////////////////////////////
            if (chessBoard.chessTiles[this.y + 3, this.x - 1].currentFigure == null)
            {
                moveList.Add(new ChessPosition(this.x - 1, this.y + 3));
            }
            if (chessBoard.chessTiles[this.y + 3, this.x - 1].currentFigure.ChessColor != this.ChessColor)
            {
                ChessPosition Kill = new ChessPosition(this.x - 1,this.y + 3);
                Kill.PriceTile = 100 + chessBoard.chessTiles[this.y + 3, this.x - 1].currentFigure.Price;
                kill2.Add(Kill);
            }
            /////////////////////////////////////////////////////////////////////////////////////////
            if (chessBoard.chessTiles[this.y - 3, this.x + 1].currentFigure == null)
            {
                moveList.Add(new ChessPosition(this.x + 1, this.y - 3));
            }
            if (chessBoard.chessTiles[this.y - 3, this.x + 1].currentFigure.ChessColor != this.ChessColor)
            {
                ChessPosition Kill = new ChessPosition(this.x + 1, this.y - 3);
                Kill.PriceTile = 100 + chessBoard.chessTiles[this.y - 3, this.x + 1].currentFigure.Price;
                kill2.Add(Kill);
            }
            /////////////////////////////////////////////////////////////////////////////////////////
            if (chessBoard.chessTiles[this.y - 3, this.x - 1].currentFigure == null)
            {
                moveList.Add(new ChessPosition(this.x - 1, this.y - 3));
            }
            if (chessBoard.chessTiles[this.y - 3, this.x - 1].currentFigure.ChessColor != this.ChessColor)
            {
                ChessPosition Kill = new ChessPosition(this.x - 1, this.y - 3);
                Kill.PriceTile = 100 + chessBoard.chessTiles[this.y - 3, this.x - 1].currentFigure.Price;
                kill2.Add(Kill);
            }
            if (ChessColor == "WHITE")
            {
                for (int yy = this.y - 1; yy < 8; yy++)
                {
                    if (chessBoard.chessTiles[yy, this.x].currentFigure == null)
                    {
                        moveList.Add(new ChessPosition(this.x, yy));
                    }
                    else if (chessBoard.chessTiles[yy, this.x + 1].currentFigure.ChessColor != this.ChessColor)
                    {
                        ChessPosition Kill = new ChessPosition(x + 1, y - 1);
                        Kill.PriceTile = 100 + chessBoard.chessTiles[yy, this.x].currentFigure.Price;
                        kill2.Add(Kill);
                    }
                    else if (chessBoard.chessTiles[yy, this.x - 1].currentFigure.ChessColor != this.ChessColor)
                    {
                        ChessPosition Kill = new ChessPosition(x - 1, y - 1);
                        Kill.PriceTile = 100 + chessBoard.chessTiles[yy, this.x].currentFigure.Price;
                        kill2.Add(Kill);
                    }
                    else { break; }
                }
            }
            if (ChessColor == "BLACK")
            {
                for (int yy = this.y + 1; yy < 8; yy++)
                {
                    if (chessBoard.chessTiles[yy, this.x].currentFigure == null)
                    {
                        moveList.Add(new ChessPosition(this.x, yy));
                    }
                    else if (chessBoard.chessTiles[yy, this.x + 1].currentFigure.ChessColor != this.ChessColor)
                    {
                        ChessPosition Kill = new ChessPosition(x + 1, y + 1);
                        Kill.PriceTile = 100 + chessBoard.chessTiles[yy, this.x].currentFigure.Price;
                        kill2.Add(Kill);
                    }
                    else if (chessBoard.chessTiles[yy, this.x - 1].currentFigure.ChessColor != this.ChessColor)
                    {
                       
                    }
                    else { break; }
                }
            }
            if (kill2 != null)
            {
                for (int i = 0; i < kill2.Count; i++)
                {
                    buffer = kill2[i].PriceTile;
                    if (buffer > Best) { Best = kill2[i].PriceTile; }
                }
                for (int i = 0; i < kill2.Count; i++)
                {
                    if (kill2[i].PriceTile == Best) { return kill2[i]; }
                }
            }
            int rand = rnd.Next(moveList.Count);
            return moveList[rand];
        }

        public override void draw(Graphics g, int x, int y, string ChessColor)
        {
            if (ChessColor == "BLACK")
            {
                string fileName = "KNIGHT_BLACK.png";
                string path = Path.Combine(local, fileName);
                Image img = Image.FromFile(path);
                g.DrawImage(img, new Point(x, y));
            }
            if (ChessColor == "WHITE")
            {
                string fileName = "KNIGHT_WHITE.png";
                string path = Path.Combine(local, fileName);
                Image img = Image.FromFile(path);
                g.DrawImage(img, new Point(x, y));
            }
        }

    }
}

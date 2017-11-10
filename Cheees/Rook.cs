using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cheees
{
    public class Rook : Figure
    {
        public Rook(string color)
        {
            int x = 0;
            int y = 0;
            this.ChessColor = color;
            Price = 150;
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
                ChessPosition[] possXP = new ChessPosition[8];
                ChessPosition[] possYP = new ChessPosition[8];
                ChessPosition[] possXM = new ChessPosition[8];
                ChessPosition[] possYM = new ChessPosition[8];
                bool FoundXP = false;
                bool FoundYP = false;
                bool FoundXM = false;
                bool FoundYM = false;

                ////////////////////////X PLUS////////////////////////
                for (int i = 1; i < 8; i++)
                {
                    if (!FoundXP)
                    {
                        possXP[i] = new ChessPosition(x + 1, y);
                        foreach (Figure figure in Black)
                        {
                            if (possXP[i].x == figure.x && possXP[i].y == figure.y)
                            {
                                FoundXP = true;
                                Score1 = 100 + figure.Price;
                                break;
                            }
                        }
                        foreach (Figure figure in White)
                        {
                            if ((possXP[i].x + 1 == figure.x && possXP[i].y == figure.y) || (possXP[i].x + 1 > 8))
                            {
                                FoundXP = true;
                                break;
                            }
                        }
                    }
                }
                /////////////////////////////////////////Y PLUS//////////////////////////////////////
                for (int i = 1; i < 8; i++)
                {
                    if (!FoundYP)
                    {
                        possYP[i] = new ChessPosition(x, y + 1);
                        foreach (Figure figure in Black)
                        {
                            if (possYP[i].x == figure.x && possYP[i].y == figure.y)
                            {
                                FoundYP = true;
                                Score1 = 100 + figure.Price;
                                break;
                            }
                        }
                        foreach (Figure figure in White)
                        {
                            if ((possYP[i].x == figure.x && possYP[i].y + 1 == figure.y) || (possYP[i].y + 1 > 8))
                            {
                                FoundYP = true;
                                break;
                            }
                        }
                    }
                }
                //////////////////////////////////////X MINUS///////////////////////////////
                for (int i = 1; i < 8; i++)
                {
                    if (!FoundXM)
                    {
                        possXM[i] = new ChessPosition(x - 1, y);
                        foreach (Figure figure in Black)
                        {
                            if (possXM[i].x == figure.x && possXM[i].y == figure.y)
                            {
                                FoundXM = true;
                                Score1 = 100 + figure.Price;
                                break;
                            }
                        }
                        foreach (Figure figure in White)
                        {
                            if ((possXM[i].x - 1 == figure.x && possXM[i].y == figure.y) || (possXM[i].x - 1 < 0))
                            {
                                FoundXM = true;
                                break;
                            }
                        }
                    }
                }
                ////////////////////////////////////////Y MINUS//////////////////////////////////////////////////
                for (int i = 1; i < 8; i++)
                {
                    if (!FoundYM)
                    {
                        possYM[i] = new ChessPosition(x, y - 1);
                        foreach (Figure figure in Black)
                        {
                            if (possYM[i].x == figure.x && possYM[i].y == figure.y)
                            {
                                FoundYM = true;
                                Score1 = 100 + figure.Price;
                                break;
                            }
                        }
                        foreach (Figure figure in White)
                        {
                            if ((possYM[i].x - 1 == figure.x && possYM[i].y == figure.y) || (possYM[i].y - 1 < 0))
                            {
                                FoundYM = true;
                                break;
                            }
                        }
                    }
                }
            }
            if (ChessColor == "BLACK")
            {
                ChessPosition[] possXP = new ChessPosition[8];
                ChessPosition[] possYP = new ChessPosition[8];
                ChessPosition[] possXM = new ChessPosition[8];
                ChessPosition[] possYM = new ChessPosition[8];
                bool FoundXP = false;
                bool FoundYP = false;
                bool FoundXM = false;
                bool FoundYM = false;

                ////////////////////////X PLUS////////////////////////
                for (int i = 1; i < 8; i++)
                {
                    if (!FoundXP)
                    {
                        possXP[i] = new ChessPosition(x + 1, y);
                        foreach (Figure figure in White)
                        {
                            if (possXP[i].x == figure.x && possXP[i].y == figure.y)
                            {
                                FoundXP = true;
                                Score1 = 100 + figure.Price;
                                break;
                            }
                        }
                        foreach (Figure figure in Black)
                        {
                            if ((possXP[i].x + 1 == figure.x && possXP[i].y == figure.y) || (possXP[i].x + 1 > 8))
                            {
                                FoundXP = true;
                                break;
                            }
                        }
                    }
                }
                /////////////////////////////////////////Y PLUS//////////////////////////////////////
                for (int i = 1; i < 8; i++)
                {
                    if (!FoundYP)
                    {
                        possYP[i] = new ChessPosition(x, y + 1);
                        foreach (Figure figure in White)
                        {
                            if (possYP[i].x == figure.x && possYP[i].y == figure.y)
                            {
                                FoundYP = true;
                                Score1 = 100 + figure.Price;
                                break;
                            }
                        }
                        foreach (Figure figure in Black)
                        {
                            if ((possYP[i].x == figure.x && possYP[i].y + 1 == figure.y) || (possYP[i].y + 1 > 8))
                            {
                                FoundYP = true;
                                break;
                            }
                        }
                    }
                }
                //////////////////////////////////////X MINUS///////////////////////////////
                for (int i = 1; i < 8; i++)
                {
                    if (!FoundXM)
                    {
                        possXM[i] = new ChessPosition(x - 1, y);
                        foreach (Figure figure in White)
                        {
                            if (possXM[i].x == figure.x && possXM[i].y == figure.y)
                            {
                                FoundXM = true;
                                Score1 = 100 + figure.Price;
                                break;
                            }
                        }
                        foreach (Figure figure in Black)
                        {
                            if ((possXM[i].x - 1 == figure.x && possXM[i].y == figure.y) || (possXM[i].x - 1 < 0))
                            {
                                FoundXM = true;
                                break;
                            }
                        }
                    }
                }
                ////////////////////////////////////////Y MINUS//////////////////////////////////////////////////
                for (int i = 1; i < 8; i++)
                {
                    if (!FoundYM)
                    {
                        possYM[i] = new ChessPosition(x, y - 1);
                        foreach (Figure figure in White)
                        {
                            if (possYM[i].x == figure.x && possYM[i].y == figure.y)
                            {
                                FoundYM = true;
                                Score1 = 100 + figure.Price;
                                break;
                            }
                        }
                        foreach (Figure figure in Black)
                        {
                            if ((possYM[i].x - 1 == figure.x && possYM[i].y == figure.y) || (possYM[i].y - 1 < 0))
                            {
                                FoundYM = true;
                                break;
                            }
                        }
                    }
                }
            }
            return Score1;

        }

        override public List<ChessPosition> move(ChessBoard chessBoard)
        {
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
                ChessPosition[] possXP = new ChessPosition[8];
                ChessPosition[] possYP = new ChessPosition[8];
                ChessPosition[] possXM = new ChessPosition[8];
                ChessPosition[] possYM = new ChessPosition[8];
                bool FoundXP = false;
                bool FoundYP = false;
                bool FoundXM = false;
                bool FoundYM = false;

                ////////////////////////X PLUS////////////////////////
                for (int i = 1; i < 8; i++)
                {
                    if (!FoundXP)
                    {
                        possXP[i] = new ChessPosition(x + 1, y);
                        moveList.Add(possXP[i]);
                        foreach (Figure figure in Black)
                        {
                            if (possXP[i].x == figure.x && possXP[i].y == figure.y)
                            {
                                FoundXP = true;
                                possXP[i].PriceTile = 100 + figure.Price;
                                moveList.Add(possXP[i]);
                                return moveList;

                            }
                        }
                        foreach (Figure figure in White)
                        {
                            if ((possXP[i].x + 1 == figure.x && possXP[i].y == figure.y) || (possXP[i].x + 1 > 8))
                            {
                                FoundXP = true;
                                break;
                            }
                        }
                    }
                }
                /////////////////////////////////////////Y PLUS//////////////////////////////////////
                for (int i = 1; i < 8; i++)
                {
                    if (!FoundYP)
                    {
                        possYP[i] = new ChessPosition(x, y + 1);
                        moveList.Add(possYP[i]);
                        foreach (Figure figure in Black)
                        {
                            if (possYP[i].x == figure.x && possYP[i].y == figure.y)
                            {
                                FoundYP = true;
                                possYP[i].PriceTile = 100 + figure.Price;
                                moveList.Add(possYP[i]);
                                return moveList;
                            }
                        }
                        foreach (Figure figure in White)
                        {
                            if ((possYP[i].x == figure.x && possYP[i].y + 1 == figure.y) || (possYP[i].y + 1 > 8))
                            {
                                FoundYP = true;
                                break;
                            }
                        }
                    }
                }
                //////////////////////////////////////X MINUS///////////////////////////////
                for (int i = 1; i < 8; i++)
                {
                    if (!FoundXM)
                    {
                        possXM[i] = new ChessPosition(x - 1, y);
                        moveList.Add(possXM[i]);
                        foreach (Figure figure in Black)
                        {
                            if (possXM[i].x == figure.x && possXM[i].y == figure.y)
                            {
                                FoundXM = true;
                                possXM[i].PriceTile = 100 + figure.Price;
                                moveList.Add(possXM[i]);
                                return moveList;
                            }
                        }
                        foreach (Figure figure in White)
                        {
                            if ((possXM[i].x - 1 == figure.x && possXM[i].y == figure.y) || (possXM[i].x - 1 < 0))
                            {
                                FoundXM = true;
                                break;
                            }
                        }
                    }
                }
                ////////////////////////////////////////Y MINUS//////////////////////////////////////////////////
                for (int i = 1; i < 8; i++)
                {
                    if (!FoundYM)
                    {
                        possYM[i] = new ChessPosition(x, y - 1);
                        moveList.Add(possYM[i]);
                        foreach (Figure figure in Black)
                        {
                            if (possYM[i].x == figure.x && possYM[i].y == figure.y)
                            {
                                FoundYM = true;
                                possYM[i].PriceTile = 100 + figure.Price;
                                moveList.Add(possYM[i]);
                                return moveList;
                            }
                        }
                        foreach (Figure figure in White)
                        {
                            if ((possYM[i].x - 1 == figure.x && possYM[i].y == figure.y) || (possYM[i].y - 1 < 0))
                            {
                                FoundYM = true;
                                break;
                            }
                        }
                    }
                }
            }
            if (ChessColor == "BLACK")
            {
                ChessPosition[] possXP = new ChessPosition[8];
                ChessPosition[] possYP = new ChessPosition[8];
                ChessPosition[] possXM = new ChessPosition[8];
                ChessPosition[] possYM = new ChessPosition[8];
                bool FoundXP = false;
                bool FoundYP = false;
                bool FoundXM = false;
                bool FoundYM = false;

                ////////////////////////X PLUS////////////////////////
                for (int i = 1; i < 8; i++)
                {
                    if (!FoundXP)
                    {
                        possXP[i] = new ChessPosition(x + 1, y);
                        moveList.Add(possXP[i]);
                        foreach (Figure figure in White)
                        {
                            if (possXP[i].x == figure.x && possXP[i].y == figure.y)
                            {
                                FoundXP = true;
                                possXP[i].PriceTile = 100 + figure.Price;
                                moveList.Add(possXP[i]);
                                return moveList;
                            }
                        }
                        foreach (Figure figure in Black)
                        {
                            if ((possXP[i].x + 1 == figure.x && possXP[i].y == figure.y) || (possXP[i].x + 1 > 8))
                            {
                                FoundXP = true;
                                break;
                            }
                        }
                    }
                }
                /////////////////////////////////////////Y PLUS//////////////////////////////////////
                for (int i = 1; i < 8; i++)
                {
                    if (!FoundYP)
                    {
                        possYP[i] = new ChessPosition(x, y + 1);
                        moveList.Add(possYP[i]);
                        foreach (Figure figure in White)
                        {
                            if (possYP[i].x == figure.x && possYP[i].y == figure.y)
                            {
                                FoundYP = true;
                                possYP[i].PriceTile = 100 + figure.Price;
                                moveList.Add(possYP[i]);
                                return moveList;
                            }
                        }
                        foreach (Figure figure in Black)
                        {
                            if ((possYP[i].x == figure.x && possYP[i].y + 1 == figure.y) || (possYP[i].y + 1 > 8))
                            {
                                FoundYP = true;
                                break;
                            }
                        }
                    }
                }
                //////////////////////////////////////X MINUS///////////////////////////////
                for (int i = 1; i < 8; i++)
                {
                    if (!FoundXM)
                    {
                        possXM[i] = new ChessPosition(x - 1, y);
                        moveList.Add(possXM[i]);
                        foreach (Figure figure in White)
                        {
                            if (possXM[i].x == figure.x && possXM[i].y == figure.y)
                            {
                                FoundXM = true;
                                possXM[i].PriceTile = 100 + figure.Price;
                                moveList.Add(possXM[i]);
                                return moveList;
                            }
                        }
                        foreach (Figure figure in Black)
                        {
                            if ((possXM[i].x - 1 == figure.x && possXM[i].y == figure.y) || (possXM[i].x - 1 < 0))
                            {
                                FoundXM = true;
                                break;
                            }
                        }
                    }
                }
                ////////////////////////////////////////Y MINUS//////////////////////////////////////////////////
                for (int i = 1; i < 8; i++)
                {
                    if (!FoundYM)
                    {
                        possYM[i] = new ChessPosition(x, y - 1);
                        moveList.Add(possYM[i]);
                        foreach (Figure figure in White)
                        {
                            if (possYM[i].x == figure.x && possYM[i].y == figure.y)
                            {
                                FoundYM = true;
                                possYM[i].PriceTile = 100 + figure.Price;
                                moveList.Add(possYM[i]);
                                return moveList;
                            }
                        }
                        foreach (Figure figure in Black)
                        {
                            if ((possYM[i].x - 1 == figure.x && possYM[i].y == figure.y) || (possYM[i].y - 1 < 0))
                            {
                                FoundYM = true;
                                break;
                            }
                        }
                    }
                }
            }
            return moveList;
        }

        public override void draw(Graphics g, int x, int y, string ChessColor)
        {
            if (ChessColor == "BLACK")
            {
                string fileName = "ROOK_BLACK.png";
                string path = Path.Combine(local, fileName);
                Image img = Image.FromFile(path);
                g.DrawImage(img, new Point(x, y));
            }
            if (ChessColor == "WHITE")
            {
                string fileName = "ROOK_WHITE.png";
                string path = Path.Combine(local, fileName);
                Image img = Image.FromFile(path);
                g.DrawImage(img, new Point(x, y));
            }
        }

        public override void update()
        {
            throw new NotImplementedException();
        }
    }
}

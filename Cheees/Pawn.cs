using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cheees
{
    public class Pawn : Figure
    {
        //ChessPosition cheesPosition;
        public Pawn(string color)
        {
            int x = 0;
            int y = 0;
            this.ChessColor = color;
            Price = 100;
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
                ChessPosition y1 = new ChessPosition(x, y - 1);

                moveList.Add(y1);
                foreach (Figure figure in White)
                {
                    if ((y - 1 == figure.y && x == figure.x) || y - 1 < 0)
                    {
                        moveList.Remove(y1);

                    }
                }

                foreach (Figure figure in Black)
                {
                    if ((y - 1 == figure.y && x == figure.x) || y - 1 < 0)
                    {
                        moveList.Remove(y1);

                    }
                    if ((y - 1 == figure.y && x + 1 == figure.x) || y - 1 < 0)
                    {
                        ChessPosition Kill = new ChessPosition(x + 1, y - 1);
                        Kill.PriceTile = 100 + figure.Price;
                        List<ChessPosition> kill2 = new List<ChessPosition>();
                        kill2.Add(Kill);
                        return kill2;
                    }
                    if ((y - 1 == figure.y && x - 1 == figure.x) || y - 2 < 0)
                    {
                        ChessPosition Kill = new ChessPosition(x - 1, y - 1);
                        Kill.PriceTile = 100 + figure.Price;
                        List<ChessPosition> kill2 = new List<ChessPosition>();
                        kill2.Add(Kill);
                        return kill2;
                    }


                }
            }


            if (ChessColor == "BLACK")
            {
                ChessPosition y1 = new ChessPosition(x, y + 1);

                moveList.Add(y1);

                if (y + 1 > 8)
                {
                    moveList.Remove(y1);
                }

                foreach (Figure figure in Black)
                {
                    if ((y + 1 == figure.y && x == figure.x) || y - 1 < 0)
                    {
                        return moveList;

                    }
                }

                foreach (Figure figure in White)
                {
                    if ((y + 1 == figure.y && x == figure.x) || y - 1 < 0)
                    {
                        moveList.Remove(y1);

                    }
                    if ((y + 1 == figure.y && x + 1 == figure.x) || y - 1 < 0)
                    {
                        ChessPosition Kill = new ChessPosition(x + 1, y + 1);
                        Kill.PriceTile = 100 + figure.Price;
                        List<ChessPosition> kill2 = new List<ChessPosition>();
                        kill2.Add(Kill);
                        return kill2;
                    }
                    if (y + 1 == figure.y && x - 1 == figure.x)
                    {
                        ChessPosition Kill = new ChessPosition(x - 1, y + 1);
                        Kill.PriceTile = 100 + figure.Price;
                        List<ChessPosition> kill2 = new List<ChessPosition>();
                        kill2.Add(Kill);
                        return kill2;
                    }
                }
            }
                return moveList;
            
        }


        override public int AlpBet(ChessBoard chessBoard)
        {
            int Score1 = 50;
            int Score2 = 50;
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
                

                moveList.Add(y1);
                
                if(y-1 < 0)
                {
                    return 0;
                }

                foreach (Figure figure in White)
                {
                    if ((y - 1 == figure.y && x == figure.x) || y - 1 < 0)
                    {
                        Score1 = 0;
                        
                    }
                    
                }
   
                foreach (Figure figure in Black)
                {
                    if ((y - 1 == figure.y && x + 1 == figure.x) || y - 1 < 0)
                    {
                        Score1 = 100 + figure.Price; 

                    }
                    if ((y - 1 == figure.y && x - 1 == figure.x) || y - 2 < 0)
                    {
                        Score2 = 100 + figure.Price; 
                    }
                }
                
                
            }
            if (ChessColor == "BLACK")
            {
                ChessPosition y1 = new ChessPosition(x, y + 1);
                moveList.Add(y1);
                if (y + 1 > 8)
                {
                    return 0;
                }

                foreach (Figure figure in White)
                {
                    if (y + 1 == figure.y && x + 1 == figure.x)
                    {
                        Score1 = 100 + figure.Price;

                    }
                    if (y + 1 == figure.y && x - 1 == figure.x) 
                    {
                        Score2 = 100 + figure.Price; ;
                    }
                }
                foreach (Figure figure in Black)
                {
                    if (y + 1 == figure.y && x == figure.x)
                    {
                        Score1 = 0;

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


        public override void draw(Graphics g, int x, int y, string ChessColor)
        {
           
            if (ChessColor == "BLACK")
            {
                string fileName = "PAWN_BLACK.png";
                string path = Path.Combine(local, fileName);
                Image img = Image.FromFile(path);
                g.DrawImage(img, new Point(x, y));
            }
            if (ChessColor == "WHITE")
            {
                string fileName = "PAWN_WHITE.png";
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

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

    override public ChessPosition move(ChessBoard chessBoard)
        {
            List<ChessPosition> moveList = new List<ChessPosition>();
            List<ChessPosition> kill2 = new List<ChessPosition>();
            int buffer = 0;
            int Best = 0;
            
            if (ChessColor == "WHITE")
            {
                for (int yy = this.y - 1; yy >= 0; yy--)
                {
                    if (chessBoard.chessTiles[yy, this.x].currentFigure == null)
                    {
                        moveList.Add(new ChessPosition(this.x, yy));
                    }
                    else if (chessBoard.chessTiles[yy, this.x + 1].currentFigure.ChessColor != this.ChessColor)
                    {
                        ChessPosition Kill = new ChessPosition(x + 1, y - 1);
                        Kill.PriceTile = 100 + chessBoard.chessTiles[yy, this.x+1].currentFigure.Price;
                        kill2.Add(Kill);
                    }
                    else if (chessBoard.chessTiles[yy, this.x - 1].currentFigure.ChessColor != this.ChessColor)
                    {
                        ChessPosition Kill = new ChessPosition(x - 1, y - 1);
                        Kill.PriceTile = 100 + chessBoard.chessTiles[yy, this.x-1].currentFigure.Price;         
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
                        Kill.PriceTile = 100 + chessBoard.chessTiles[yy, this.x+1].currentFigure.Price;
                        kill2.Add(Kill);
                    }
                    else if (chessBoard.chessTiles[yy, this.x - 1].currentFigure.ChessColor != this.ChessColor)
                    {
                        ChessPosition Kill = new ChessPosition(x - 1, y + 1);
                        Kill.PriceTile = 100 + chessBoard.chessTiles[yy, this.x-1].currentFigure.Price;
                        kill2.Add(Kill);
                    }
                    else { break; }
                }
            }
            if(kill2 != null)
            {
                for(int i = 0; i < kill2.Count; i++)
                {
                    buffer = kill2[i].PriceTile;
                    if(buffer > Best) { Best = kill2[i].PriceTile; }
                }
                for (int i = 0; i < kill2.Count; i++)
                {
                    if (kill2[i].PriceTile == Best) { return kill2[i]; }
                }
            }
            return moveList[0];
        }


        override public int AlpBet(ChessBoard chessBoard, int ScoreDepth = 0, int Depth = 1)
        {
            int Score = 50;
            if (ChessColor == "WHITE")
            {
                for (int yy = this.y - 1; yy >= 0; yy--)
                {
                    if (chessBoard.chessTiles[yy, this.x].currentFigure == null)
                    {
                        Score = 50+ScoreDepth;
                    }
                    else if (chessBoard.chessTiles[yy, this.x + 1].currentFigure.ChessColor != this.ChessColor)
                    {   
                        Score = 100 + chessBoard.chessTiles[yy, this.x].currentFigure.Price + ScoreDepth;
                    }
                    else if (chessBoard.chessTiles[yy, this.x - 1].currentFigure.ChessColor != this.ChessColor)
                    {
                        Score = 100 + chessBoard.chessTiles[yy, this.x].currentFigure.Price + ScoreDepth;
                    }
                    else { Score = 0;  }
                }
            }
            if (ChessColor == "BLACK")
            {
                for (int yy = this.y + 1; yy < 8; yy++)
                {
                    if (chessBoard.chessTiles[yy, this.x].currentFigure == null)
                    {
                        Score = 50 + ScoreDepth;
                    }
                    else if (chessBoard.chessTiles[yy, this.x + 1].currentFigure.ChessColor != this.ChessColor)
                    {
                        Score = 100 + chessBoard.chessTiles[yy, this.x].currentFigure.Price + ScoreDepth;
                    }
                    else if (chessBoard.chessTiles[yy, this.x - 1].currentFigure.ChessColor != this.ChessColor)
                    {
                        Score = 100 + chessBoard.chessTiles[yy, this.x].currentFigure.Price + ScoreDepth;
                    }
                    else { Score = 0; }
                }
            }           
                return Score;
        
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

    }
}

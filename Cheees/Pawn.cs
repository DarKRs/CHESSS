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

        bool FirstStep = true;
        public Pawn(string color)
        {
            Name = "Pawn";
            int x = 0;
            int y = 0;
            this.ChessColor = color;
            Price = 100;
        }

    override public List<ChessPosition> move(ChessBoard chessBoard)
        {
            List<ChessPosition> moveList = new List<ChessPosition>();

            if (ChessColor == "WHITE")
            {
                int yy = this.y - 1;
                
                    if (FirstStep && yy-1 >= 0 && chessBoard.chessTiles[this.x, yy].currentFigure == null)
                    {
                        moveList.Add(new ChessPosition(this.x, yy-1,this));
                        this.FirstStep = false;
                    }
                    if (yy >= 0 && chessBoard.chessTiles[this.x, yy].currentFigure == null)
                    {
                        moveList.Add(new ChessPosition(this.x, yy,this));
                    }
                    if (yy >= 0 && this.x + 1 < 8 && chessBoard.chessTiles[this.x + 1, yy].currentFigure != null && chessBoard.chessTiles[this.x + 1, yy].currentFigure.ChessColor != this.ChessColor)
                    {
                        ChessPosition Kill = new ChessPosition(x + 1, yy,this);
                    Kill.PriceTile = 100 + chessBoard.chessTiles[x + 1, yy].currentFigure.Price;
                    moveList.Add(Kill);
                }
                    if (yy >= 0 && this.x - 1 >= 0 && chessBoard.chessTiles[this.x - 1, yy].currentFigure != null && chessBoard.chessTiles[this.x - 1, yy].currentFigure.ChessColor != this.ChessColor)
                    {
                        ChessPosition Kill = new ChessPosition(this.x - 1, yy,this);
                    Kill.PriceTile = 100 + chessBoard.chessTiles[x-1, yy].currentFigure.Price;
                    moveList.Add(Kill);
                }
                    
                
            }
            if (ChessColor == "BLACK")
            {
                int yy = this.y + 1;
                
                    if (FirstStep && yy+1 < 8 && chessBoard.chessTiles[this.x, yy].currentFigure == null)
                    {
                        moveList.Add(new ChessPosition(this.x, yy + 1,this));
                        this.FirstStep = false;
                    }
                    if (yy < 8 && chessBoard.chessTiles[this.x, yy].currentFigure == null)
                    {
                        moveList.Add(new ChessPosition(this.x, yy,this));
                    }
                    if (yy < 8 && this.x + 1 < 8 && chessBoard.chessTiles[this.x + 1, yy].currentFigure != null &&  chessBoard.chessTiles[this.x + 1, yy].currentFigure.ChessColor != this.ChessColor)
                    {
                        ChessPosition Kill = new ChessPosition(x + 1, yy,this);
                    Kill.PriceTile = 100 + chessBoard.chessTiles[x+1, yy].currentFigure.Price;
                    moveList.Add(Kill);
                }
                   if (yy < 8 && this.x - 1 >= 0 && chessBoard.chessTiles[this.x - 1, yy].currentFigure != null &&chessBoard.chessTiles[this.x - 1, yy].currentFigure.ChessColor != this.ChessColor)
                    {
                        ChessPosition Kill = new ChessPosition(this.x - 1, yy,this);
                    Kill.PriceTile = 100 + chessBoard.chessTiles[x-1, yy].currentFigure.Price;
                    moveList.Add(Kill);
                }
                    
                
            }
           

            return moveList;
        }


        override public int AlpBet(ChessBoard chessBoard, int ScoreDepth = 0, int Depth = 1)
        {
            int[] Score = new int[256];
            int BestScore = 0;
            int buff;
            int i = 0;
            if (ChessColor == "WHITE")
            {
                int yy = this.y - 1;
                
                    if (yy >= 0 && chessBoard.chessTiles[this.x, yy].currentFigure == null)
                    {
                        Score[i] = 50+ScoreDepth;
                        i++;
                    }
                   
                   if (yy >= 0 && this.x + 1 < 8 && chessBoard.chessTiles[this.x + 1, yy].currentFigure != null && chessBoard.chessTiles[this.x + 1, yy].currentFigure.ChessColor != this.ChessColor)
                        {
                            Score[i] = 100 + chessBoard.chessTiles[this.x + 1, yy].currentFigure.Price + ScoreDepth; i++;

                           }
                    
                    
                    if (yy >= 0 && this.x - 1 >= 0 && chessBoard.chessTiles[this.x - 1, yy].currentFigure != null && chessBoard.chessTiles[this.x - 1, yy].currentFigure.ChessColor != this.ChessColor)
                        {
                            Score[i] = 100 + chessBoard.chessTiles[this.x - 1, yy].currentFigure.Price + ScoreDepth; i++;
                        }
                    
                    else { Score[i] = 0; i++; }
                
            }
            if (ChessColor == "BLACK")
            {
                int yy = this.y + 1;
                
                    if (yy < 8 && chessBoard.chessTiles[this.x, yy].currentFigure == null)
                    {
                        Score[i] = 50 + ScoreDepth; i++;
                    }
                    if (yy < 8 && this.x + 1 < 8 && chessBoard.chessTiles[this.x + 1, yy].currentFigure != null && chessBoard.chessTiles[this.x + 1, yy].currentFigure.ChessColor != this.ChessColor)
                    {
                        Score[i] = 100 + chessBoard.chessTiles[this.x + 1, yy].currentFigure.Price + ScoreDepth; i++;
                    }
                    if (yy < 8 && this.x - 1 >= 0 && chessBoard.chessTiles[this.x - 1, yy].currentFigure != null && chessBoard.chessTiles[this.x - 1, yy].currentFigure.ChessColor != this.ChessColor)
                    {
                        Score[i] = 100 + chessBoard.chessTiles[this.x - 1, yy].currentFigure.Price + ScoreDepth; i++;
                    }
                    else { Score[i] = 0; i++; }
                
            }
            for (int j = 0; j < Score.Length; j++)
            {
                buff = Score[j];
                if (buff > BestScore) { BestScore = buff; }
            }
            return BestScore;

        }

        public override void step(ChessPosition chessPosition)
        {
            
            x = chessPosition.x;
            y = chessPosition.y;

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

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
            Name = "Tower";
            int x = 0;
            int y = 0;
            this.ChessColor = color;
            Price = 150;
        }

        override public int AlpBet(ChessBoard chessBoard, int ScoreDepth = 0, int Depth = 1)
        {
            int[] Score = new int[256];
            int BestScore = 0;
            int buff;
            int i = 0;
            ////////////////////////////////////////////////VERTICAL & HORIZANTAL////////////////////////////////
            ////////////////////////////////////////////////////DOWN/////////////////////////////////////////////
            for (int yy = this.y + 1, xx = this.x; yy < 8; yy++)
            {
                if (chessBoard.chessTiles[xx, yy].currentFigure == null)
                {
                    Score[i] = 50 + ScoreDepth;
                    i++;
                }
                else if (chessBoard.chessTiles[xx, yy].currentFigure.ChessColor != this.ChessColor)
                {
                    Score[i] = 100 + chessBoard.chessTiles[xx, yy].currentFigure.Price + ScoreDepth;
                    i++;
                    break;
                }
                else{ Score[i] = 0; i++; break; }
            }
            ////////////////////////////////////////////////////LEFT/////////////////////////////////////////////
            for (int yy = this.y, xx = this.x - 1; xx >= 0; xx--)
            {
                if (chessBoard.chessTiles[xx, yy].currentFigure == null)
                {
                    Score[i] = 50 + ScoreDepth;
                    i++;
                }
                else if (chessBoard.chessTiles[xx, yy].currentFigure.ChessColor != this.ChessColor)
                {
                    Score[i] = 100 + chessBoard.chessTiles[xx, yy].currentFigure.Price + ScoreDepth;
                    i++;
                    break;
                }
                else { Score[i] = 0; i++; break; }
            }
            ////////////////////////////////////////////////////RIGHT/////////////////////////////////////////////
            for (int yy = this.y, xx = this.x + 1; xx < 8; xx++)
            {
                if (chessBoard.chessTiles[xx, yy].currentFigure == null)
                {
                    Score[i] = 50 + ScoreDepth;
                    i++;
                }
                else if (chessBoard.chessTiles[xx, yy].currentFigure.ChessColor != this.ChessColor)
                {
                    Score[i] = 100 + chessBoard.chessTiles[xx, yy].currentFigure.Price + ScoreDepth;
                    i++;
                    break;
                }
                else { Score[i] = 0; i++; break; }
            }
            ////////////////////////////////////////////////////UP/////////////////////////////////////////////
            for (int yy = this.y - 1, xx = this.x; yy >= 0; yy--)
            {
                if (chessBoard.chessTiles[xx, yy].currentFigure == null)
                {
                    Score[i] = 50 + ScoreDepth;
                    i++;
                }
                else if (chessBoard.chessTiles[xx, yy].currentFigure.ChessColor != this.ChessColor)
                {
                    Score[i] = 100 + chessBoard.chessTiles[xx, yy].currentFigure.Price + ScoreDepth;
                    i++;
                    break;
                }
                else { Score[i] = 0; i++; break; }
            }
            for (int j = 0; j < Score.Length; j++)
            {
                buff = Score[j];
                if (buff > BestScore) { BestScore = buff; }
            }
            return BestScore;

        }

        override public List<ChessPosition> move(ChessBoard chessBoard)
        {
            List<ChessPosition> moveList = new List<ChessPosition>();

            ////////////////////////////////////////////////VERTICAL & HORIZANTAL////////////////////////////////
            ////////////////////////////////////////////////////DOWN/////////////////////////////////////////////
            for (int yy = this.y + 1, xx = this.x; yy < 8; yy++)
            {
                if (chessBoard.chessTiles[xx, yy].currentFigure == null)
                {
                    moveList.Add(new ChessPosition(xx, yy,this));
                }
                else if (chessBoard.chessTiles[xx, yy].currentFigure.ChessColor != this.ChessColor)
                {
                    ChessPosition Kill = new ChessPosition(xx, yy,this);
                    
                    moveList.Add(Kill);
                    break;
                }
                else { break; }
            }
            ////////////////////////////////////////////////////LEFT/////////////////////////////////////////////
            for (int yy = this.y, xx = this.x - 1; xx >= 0; xx--)
            {
                if (chessBoard.chessTiles[xx, yy].currentFigure == null)
                {
                    moveList.Add(new ChessPosition(xx, yy,this));
                }
                else if (chessBoard.chessTiles[xx, yy].currentFigure.ChessColor != this.ChessColor)
                {
                    ChessPosition Kill = new ChessPosition(xx, yy,this);
                    
                    moveList.Add(Kill);
                    break;
                }
                else { break; }
            }
            ////////////////////////////////////////////////////RIGHT/////////////////////////////////////////////
            for (int yy = this.y, xx = this.x + 1; xx < 8; xx++)
            {
                if (chessBoard.chessTiles[xx, yy].currentFigure == null)
                {
                    moveList.Add(new ChessPosition(xx, yy,this));
                }
                else if (chessBoard.chessTiles[xx, yy].currentFigure.ChessColor != this.ChessColor)
                {
                    ChessPosition Kill = new ChessPosition(xx, yy,this);
                    
                    moveList.Add(Kill);
                    break;
                }
                else { break; }
            }
            ////////////////////////////////////////////////////UP/////////////////////////////////////////////
            for (int yy = this.y - 1, xx = this.x; yy >= 0; yy--)
            {
                if (chessBoard.chessTiles[xx, yy].currentFigure == null)
                {
                    moveList.Add(new ChessPosition(xx, yy,this));
                }
                else if (chessBoard.chessTiles[xx, yy].currentFigure.ChessColor != this.ChessColor)
                {
                    ChessPosition Kill = new ChessPosition(xx, yy,this);
                    
                    moveList.Add(Kill);
                    break;
                }
                else { break; }
            }
            ////////////////////////////////////////////////OUTPUT//////////////////////////////////////////////

            return moveList;
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
    }
}

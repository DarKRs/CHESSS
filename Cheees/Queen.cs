using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cheees
{
    class Queen : Figure
    {
        public Queen(string color)
        {
            Name = "Queen";
            int x = 0;
            int y = 0;
            this.ChessColor = color;
            Price = 500;
        }

        override public int AlpBet(ChessBoard chessBoard,int ScoreDepth = 0, int Depth = 1)
        {
            int[] Score = new int[256];
            int BestScore = 0;
            int buff;
            int i = 0;
            /////////////////////////////////////////////DIAGONALS//////////////////////////////////////
            /////////////////////////////////////////////DOWN & LEFT////////////////////////////////////
            for (int yy = this.y + 1, xx = this.x - 1; yy < 8 && xx >= 0; xx--, yy++)
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
            /////////////////////////////////////////////DOWN & RIGHT////////////////////////////////////
            for (int yy = this.y + 1, xx = this.x + 1; yy < 8 && xx < 8; xx++, yy++)
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
            /////////////////////////////////////////////UP && LEFT////////////////////////////////////
            for (int yy = this.y - 1, xx = this.x - 1; yy >= 0 && xx >= 0; xx--, yy--)
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
            /////////////////////////////////////////////UP && RIGHT////////////////////////////////////
            for (int yy = this.y - 1, xx = this.x + 1; yy >= 0 && xx < 8; xx++, yy--)
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
                else { Score[i] = 0; i++; break; }
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

        override public ChessPosition move(ChessBoard chessBoard)
        {
            List<ChessPosition> moveList = new List<ChessPosition>();
            List<ChessPosition> kill2 = new List<ChessPosition>();
            int buffer = 0;
            int Best = 0;
            /////////////////////////////////////////////DIAGONALS//////////////////////////////////////
            /////////////////////////////////////////////DOWN & LEFT////////////////////////////////////
            for (int yy = this.y + 1,xx = this.x - 1; yy <8 && xx >= 0; xx--, yy++)
            {
                if (chessBoard.chessTiles[xx, yy].currentFigure == null)
                {
                    moveList.Add(new ChessPosition(xx, yy));
                }
                else if (chessBoard.chessTiles[xx, yy].currentFigure.ChessColor != this.ChessColor)
                {
                    ChessPosition Kill = new ChessPosition(xx, yy);
                    Kill.PriceTile = 100 + chessBoard.chessTiles[xx, yy].currentFigure.Price;
                    kill2.Add(Kill);
                    break;
                }
                else { break; }
            }
            /////////////////////////////////////////////DOWN & RIGHT////////////////////////////////////
            for (int yy = this.y + 1, xx = this.x + 1; yy < 8 && xx < 8; xx++, yy++)
            {
                if (chessBoard.chessTiles[xx, yy].currentFigure == null)
                {
                    moveList.Add(new ChessPosition(xx, yy));
                }
                else if (chessBoard.chessTiles[xx, yy].currentFigure.ChessColor != this.ChessColor)
                {
                    ChessPosition Kill = new ChessPosition(xx, yy);
                    Kill.PriceTile = 100 + chessBoard.chessTiles[xx, yy].currentFigure.Price;
                    kill2.Add(Kill);
                    break;
                }
                else { break; }
            }
            /////////////////////////////////////////////UP && LEFT////////////////////////////////////
            for (int yy = this.y - 1, xx = this.x - 1; yy >= 0 && xx >= 0; xx--, yy--)
            {
                if (chessBoard.chessTiles[xx, yy].currentFigure == null)
                {
                    moveList.Add(new ChessPosition(xx, yy));
                }
                else if (chessBoard.chessTiles[xx, yy].currentFigure.ChessColor != this.ChessColor)
                {
                    ChessPosition Kill = new ChessPosition(xx, yy);
                    Kill.PriceTile = 100 + chessBoard.chessTiles[xx, yy].currentFigure.Price;
                    kill2.Add(Kill);
                    break;
                }
                else { break; }
            }
            /////////////////////////////////////////////UP && RIGHT////////////////////////////////////
            for (int yy = this.y - 1, xx = this.x + 1; yy >= 0 && xx < 8; xx++, yy--)
            {
                if (chessBoard.chessTiles[xx, yy].currentFigure == null)
                {
                    moveList.Add(new ChessPosition(xx, yy));
                }
                else if (chessBoard.chessTiles[xx, yy].currentFigure.ChessColor != this.ChessColor)
                {
                    ChessPosition Kill = new ChessPosition(xx, yy);
                    Kill.PriceTile = 100 + chessBoard.chessTiles[xx, yy].currentFigure.Price;
                    kill2.Add(Kill);
                    break;
                }
                else { break; }
            }
            ////////////////////////////////////////////////VERTICAL & HORIZANTAL////////////////////////////////
            ////////////////////////////////////////////////////DOWN/////////////////////////////////////////////
            for (int yy = this.y + 1, xx = this.x; yy < 8;yy++)
            {
                if (chessBoard.chessTiles[xx, yy].currentFigure == null)
                {
                    moveList.Add(new ChessPosition(xx, yy));
                }
                else if (chessBoard.chessTiles[xx, yy].currentFigure.ChessColor != this.ChessColor)
                {
                    ChessPosition Kill = new ChessPosition(xx, yy);
                    Kill.PriceTile = 100 + chessBoard.chessTiles[xx, yy].currentFigure.Price;
                    kill2.Add(Kill);
                    break;
                }
                else { break; }
            }
            ////////////////////////////////////////////////////LEFT/////////////////////////////////////////////
            for (int yy = this.y, xx = this.x - 1; xx >= 0; xx--)
            {
                if (chessBoard.chessTiles[xx, yy].currentFigure == null)
                {
                    moveList.Add(new ChessPosition(xx, yy));
                }
                else if (chessBoard.chessTiles[xx, yy].currentFigure.ChessColor != this.ChessColor)
                {
                    ChessPosition Kill = new ChessPosition(xx, yy);
                    Kill.PriceTile = 100 + chessBoard.chessTiles[xx, yy].currentFigure.Price;
                    kill2.Add(Kill);
                    break;
                }
                else { break; }
            }
            ////////////////////////////////////////////////////RIGHT/////////////////////////////////////////////
            for (int yy = this.y, xx = this.x + 1; xx < 8; xx++)
            {
                if (chessBoard.chessTiles[xx, yy].currentFigure == null)
                {
                    moveList.Add(new ChessPosition(xx, yy));
                }
                else if (chessBoard.chessTiles[xx, yy].currentFigure.ChessColor != this.ChessColor)
                {
                    ChessPosition Kill = new ChessPosition(xx, yy);
                    Kill.PriceTile = 100 + chessBoard.chessTiles[xx, yy].currentFigure.Price;
                    kill2.Add(Kill);
                    break;
                }
                else { break; }
            }
            ////////////////////////////////////////////////////UP/////////////////////////////////////////////
            for (int yy = this.y - 1, xx = this.x; yy >= 0; yy--)
            {
                if (chessBoard.chessTiles[xx, yy].currentFigure == null)
                {
                    moveList.Add(new ChessPosition(xx, yy));
                }
                else if (chessBoard.chessTiles[xx, yy].currentFigure.ChessColor != this.ChessColor)
                {
                    ChessPosition Kill = new ChessPosition(xx, yy);
                    Kill.PriceTile = 100 + chessBoard.chessTiles[xx, yy].currentFigure.Price;
                    kill2.Add(Kill);
                    break;
                }
                else { break; }
            }
            ////////////////////////////////////////////////OUTPUT//////////////////////////////////////////////
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
            if (moveList.Count == 0)
            {
                return null;
            }
            int rand = rnd.Next(0, moveList.Count);
            return moveList[rand];
        }

        public override void draw(Graphics g, int x, int y, string ChessColor)
        {
            if (ChessColor == "BLACK")
            {
                string fileName = "QUEEN_BLACK.png";
                string path = Path.Combine(local, fileName);
                Image img = Image.FromFile(path);
                g.DrawImage(img, new Point(x, y));
            }
            if (ChessColor == "WHITE")
            {
                string fileName = "QUEEN_WHITE.png";
                string path = Path.Combine(local, fileName);
                Image img = Image.FromFile(path);
                g.DrawImage(img, new Point(x, y));
            }
        }

    }
}

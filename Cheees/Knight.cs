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

        override public int AlpBet(ChessBoard chessBoard,int ScoreDepth = 0, int Depth = 1)
        {
            int Score = 50;
            /////////////////////////////////////////////////////////////////////////////////////
            /////////////////////////////////////UP///////////////////////////////////////////////
            if (chessBoard.chessTiles[this.y - 3, this.x - 1].currentFigure == null && this.y - 3 >= 0 && this.x - 1 >= 0)
            {
                Score = 50 + ScoreDepth;
            }
            if (chessBoard.chessTiles[this.y - 3, this.x - 1].currentFigure.ChessColor != this.ChessColor)
            {
                Score = 100 + chessBoard.chessTiles[this.y - 3, this.x-1].currentFigure.Price + ScoreDepth;
            }
            /////////////////////////////////////////////////////////////////////////////////////////
            if (chessBoard.chessTiles[this.y - 3, this.x + 1].currentFigure == null && this.y - 3 >= 0 && this.x + 1 < 8)
            {
                Score = 50 + ScoreDepth;
            }
            if (chessBoard.chessTiles[this.y - 3, this.x + 1].currentFigure.ChessColor != this.ChessColor)
            {
                Score = 100 + chessBoard.chessTiles[this.y -3, this.x+1].currentFigure.Price + ScoreDepth;
            }
            /////////////////////////////////////////////////////////////////////////////////////////
            ////////////////////////////////////////DOWN/////////////////////////////////////////////
            if (chessBoard.chessTiles[this.y + 3, this.x - 1].currentFigure == null && this.y + 3 < 8 && this.x - 1 >= 0)
            {
                Score = 50 + ScoreDepth;
            }
            if (chessBoard.chessTiles[this.y + 3, this.x - 1].currentFigure.ChessColor != this.ChessColor)
            {
                Score = 100 + chessBoard.chessTiles[this.y + 3, this.x-1].currentFigure.Price + ScoreDepth;
            }
            /////////////////////////////////////////////////////////////////////////////////////////
            if (chessBoard.chessTiles[this.y + 3, this.x + 1].currentFigure == null && this.y + 3 < 8 && this.x + 1 < 8)
            {
                Score = 50 + ScoreDepth;
            }
            if (chessBoard.chessTiles[this.y + 3, this.x + 1].currentFigure.ChessColor != this.ChessColor)
            {
                Score = 100 + chessBoard.chessTiles[this.y + 3, this.x+1].currentFigure.Price + ScoreDepth;
            }
            ////////////////////////////////////////////////////////////////////////////////////////////////
            ////////////////////////////////////////////////LEFT///////////////////////////////////////////
            if (chessBoard.chessTiles[this.y - 1, this.x - 3].currentFigure == null && this.y - 1 >= 0 && this.x - 3 >= 0)
            {
                Score = 50 + ScoreDepth;
            }
            if (chessBoard.chessTiles[this.y - 1, this.x - 3].currentFigure.ChessColor != this.ChessColor)
            {
                Score = 100 + chessBoard.chessTiles[this.y-1, this.x-3].currentFigure.Price + ScoreDepth;
            }
            /////////////////////////////////////////////////////////////////////////////////////////
            if (chessBoard.chessTiles[this.y + 1, this.x - 3].currentFigure == null && this.y + 1 < 8 && this.x - 3 >= 0)
            {
                Score = 50 + ScoreDepth;
            }
            if (chessBoard.chessTiles[this.y + 1, this.x - 3].currentFigure.ChessColor != this.ChessColor)
            {
                Score = 100 + chessBoard.chessTiles[this.y+1, this.x-3].currentFigure.Price + ScoreDepth;
            }
            ////////////////////////////////////////////////////////////////////////////////////////////////
            ////////////////////////////////////////////////RIGHT///////////////////////////////////////////
            if (chessBoard.chessTiles[this.y - 1, this.x + 3].currentFigure == null && this.y - 1 >= 0 && this.x + 3 < 8)
            {
                Score = 50 + ScoreDepth;
            }
            if (chessBoard.chessTiles[this.y - 1, this.x + 3].currentFigure.ChessColor != this.ChessColor)
            {
                Score = 100 + chessBoard.chessTiles[this.y-1, this.x+3].currentFigure.Price + ScoreDepth;
            }
            /////////////////////////////////////////////////////////////////////////////////////////
            if (chessBoard.chessTiles[this.y + 1, this.x + 3].currentFigure == null && this.y + 1 < 8 && this.x + 3 < 8)
            {
                Score = 50 + ScoreDepth;
            }
            if (chessBoard.chessTiles[this.y + 1, this.x + 3].currentFigure.ChessColor != this.ChessColor)
            {
                Score = 100 + chessBoard.chessTiles[this.y+1, this.x+3].currentFigure.Price + ScoreDepth;
            }
            return Score;

        }

        override public ChessPosition move(ChessBoard chessBoard)
        {
            List<ChessPosition> moveList = new List<ChessPosition>();
            List<ChessPosition> kill2 = new List<ChessPosition>();
            int buffer = 0;
            int Best = 0;
            /////////////////////////////////////////////////////////////////////////////////////
            /////////////////////////////////////UP///////////////////////////////////////////////
            if(chessBoard.chessTiles[this.y - 3, this.x - 1].currentFigure == null && this.y-3 >=0 && this.x -1 >= 0)
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
            if (chessBoard.chessTiles[this.y - 3, this.x + 1].currentFigure == null && this.y - 3 >= 0 && this.x + 1 < 8)
            {
                moveList.Add(new ChessPosition(this.x + 1, this.y - 3));
            }
            if (chessBoard.chessTiles[this.y - 3, this.x + 1].currentFigure.ChessColor != this.ChessColor)
            {
                ChessPosition Kill = new ChessPosition(this.x + 1,this.y - 3);
                Kill.PriceTile = 100 + chessBoard.chessTiles[this.y - 3, this.x + 1].currentFigure.Price;
                kill2.Add(Kill);
            }
            /////////////////////////////////////////////////////////////////////////////////////////
            ////////////////////////////////////////DOWN/////////////////////////////////////////////
            if (chessBoard.chessTiles[this.y + 3, this.x - 1].currentFigure == null && this.y + 3 < 8 && this.x - 1 >= 0)
            {
                moveList.Add(new ChessPosition(this.x - 1, this.y + 3));
            }
            if (chessBoard.chessTiles[this.y + 3, this.x - 1].currentFigure.ChessColor != this.ChessColor)
            {
                ChessPosition Kill = new ChessPosition(this.x - 1, this.y + 3);
                Kill.PriceTile = 100 + chessBoard.chessTiles[this.y + 3, this.x - 1].currentFigure.Price;
                kill2.Add(Kill);
            }
            /////////////////////////////////////////////////////////////////////////////////////////
            if (chessBoard.chessTiles[this.y + 3, this.x + 1].currentFigure == null && this.y + 3 < 8 && this.x + 1 < 8)
            {
                moveList.Add(new ChessPosition(this.x + 1, this.y - 3));
            }
            if (chessBoard.chessTiles[this.y + 3, this.x + 1].currentFigure.ChessColor != this.ChessColor)
            {
                ChessPosition Kill = new ChessPosition(this.x + 1, this.y + 3);
                Kill.PriceTile = 100 + chessBoard.chessTiles[this.y + 3, this.x + 1].currentFigure.Price;
                kill2.Add(Kill);
            }
            ////////////////////////////////////////////////////////////////////////////////////////////////
            ////////////////////////////////////////////////LEFT///////////////////////////////////////////
            if (chessBoard.chessTiles[this.y - 1, this.x - 3].currentFigure == null && this.y - 1 >= 0 && this.x -3 >= 0)
            {
                moveList.Add(new ChessPosition(this.x - 3, this.y - 1));
            }
            if (chessBoard.chessTiles[this.y - 1, this.x - 3].currentFigure.ChessColor != this.ChessColor)
            {
                ChessPosition Kill = new ChessPosition(this.x - 3, this.y - 1);
                Kill.PriceTile = 100 + chessBoard.chessTiles[this.y - 1, this.x - 3].currentFigure.Price;
                kill2.Add(Kill);
            }
            /////////////////////////////////////////////////////////////////////////////////////////
            if (chessBoard.chessTiles[this.y + 1, this.x - 3].currentFigure == null && this.y + 1 < 8 && this.x - 3 >= 0)
            {
                moveList.Add(new ChessPosition(this.x - 3, this.y + 1));
            }
            if (chessBoard.chessTiles[this.y + 1, this.x - 3].currentFigure.ChessColor != this.ChessColor)
            {
                ChessPosition Kill = new ChessPosition(this.x - 3, this.y + 1);
                Kill.PriceTile = 100 + chessBoard.chessTiles[this.y +1, this.x - 3].currentFigure.Price;
                kill2.Add(Kill);
            }
            ////////////////////////////////////////////////////////////////////////////////////////////////
            ////////////////////////////////////////////////RIGHT///////////////////////////////////////////
            if (chessBoard.chessTiles[this.y - 1, this.x + 3].currentFigure == null && this.y - 1 >= 0 && this.x + 3 < 8)
            {
                moveList.Add(new ChessPosition(this.x + 3, this.y - 1));
            }
            if (chessBoard.chessTiles[this.y - 1, this.x + 3].currentFigure.ChessColor != this.ChessColor)
            {
                ChessPosition Kill = new ChessPosition(this.x + 3, this.y - 1);
                Kill.PriceTile = 100 + chessBoard.chessTiles[this.y - 1, this.x + 3].currentFigure.Price;
                kill2.Add(Kill);
            }
            /////////////////////////////////////////////////////////////////////////////////////////
            if (chessBoard.chessTiles[this.y + 1, this.x + 3].currentFigure == null && this.y + 1 < 8 && this.x + 3 < 8)
            {
                moveList.Add(new ChessPosition(this.x + 3, this.y + 1));
            }
            if (chessBoard.chessTiles[this.y + 1, this.x + 3].currentFigure.ChessColor != this.ChessColor)
            {
                ChessPosition Kill = new ChessPosition(this.x + 3, this.y + 1);
                Kill.PriceTile = 100 + chessBoard.chessTiles[this.y + 1, this.x + 3].currentFigure.Price;
                kill2.Add(Kill);
            }
            ///////////////////////////////////////////////Вывод Мува////////////////////////////////////////////
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

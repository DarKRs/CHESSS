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
            Name = "Knight";
            int x = 0;
            int y = 0;
            this.ChessColor = color;
            Price = 200;
        }

        override public int AlpBet(ChessBoard chessBoard,int ScoreDepth = 0, int Depth = 1)
        {
            int[] Score = new int[256];
            int BestScore = 0;
            int buff;
            int i = 0;
            /////////////////////////////////////////////////////////////////////////////////////
            /////////////////////////////////////UP///////////////////////////////////////////////
            if (this.y - 2 >= 0 && this.x - 1 >= 0)
            {
                if (chessBoard.chessTiles[this.x - 1, this.y - 2].currentFigure == null)
                {
                    Score[i] = 50 + ScoreDepth;
                    i++;
                }
                else if (chessBoard.chessTiles[this.x - 1, this.y - 2].currentFigure != null && chessBoard.chessTiles[this.x - 1, this.y - 2].currentFigure.ChessColor != this.ChessColor)
                {
                    Score[i] = 100 + chessBoard.chessTiles[this.x - 1, this.y - 2].currentFigure.Price + ScoreDepth; i++;
                }
            }
            /////////////////////////////////////////////////////////////////////////////////////////
            if (this.y - 2 >= 0 && this.x + 1 < 8)
            {
                if (chessBoard.chessTiles[this.x + 1, this.y - 2].currentFigure == null)
                {
                    Score[i] = 50 + ScoreDepth; i++;
                }
                else if (chessBoard.chessTiles[this.x + 1, this.y - 2].currentFigure != null && chessBoard.chessTiles[this.x + 1, this.y - 2].currentFigure.ChessColor != this.ChessColor)
                {
                    Score[i] = 100 + chessBoard.chessTiles[this.x + 1, this.y - 2].currentFigure.Price + ScoreDepth; i++;
                }
            }
            /////////////////////////////////////////////////////////////////////////////////////////
            ////////////////////////////////////////DOWN/////////////////////////////////////////////
            if (this.y + 3 < 8 && this.x - 1 >= 0) {
                if (chessBoard.chessTiles[this.x - 1, this.y + 2].currentFigure == null)
                {
                    Score[i] = 50 + ScoreDepth; i++;
                }
                else if (chessBoard.chessTiles[this.x - 1, this.y + 2].currentFigure != null && chessBoard.chessTiles[this.x - 1, this.y + 2].currentFigure.ChessColor != this.ChessColor)
                {
                    Score[i] = 100 + chessBoard.chessTiles[this.x - 1, this.y + 2].currentFigure.Price + ScoreDepth; i++;
                }
            }
            /////////////////////////////////////////////////////////////////////////////////////////
            if (this.y + 2 < 8 && this.x + 1 < 8)
            {
                if (chessBoard.chessTiles[this.x + 1, this.y + 2].currentFigure == null)
                {
                    Score[i] = 50 + ScoreDepth; i++;
                }
                else if (chessBoard.chessTiles[this.x + 1, this.y + 2].currentFigure != null && chessBoard.chessTiles[this.x + 1, this.y + 2].currentFigure.ChessColor != this.ChessColor)
                {
                    Score[i] = 100 + chessBoard.chessTiles[this.x + 1, this.y + 2].currentFigure.Price + ScoreDepth; i++;
                }
            }
            ////////////////////////////////////////////////////////////////////////////////////////////////
            ////////////////////////////////////////////////LEFT///////////////////////////////////////////
            if (this.y - 1 >= 0 && this.x - 2 >= 0)
            {
                if (chessBoard.chessTiles[this.x - 2, this.y - 1].currentFigure == null)
                {
                    Score[i] = 50 + ScoreDepth; i++;
                }
                else if (chessBoard.chessTiles[this.x - 2, this.y - 1].currentFigure != null && chessBoard.chessTiles[this.x - 2, this.y - 1].currentFigure.ChessColor != this.ChessColor)
                {
                    Score[i] = 100 + chessBoard.chessTiles[this.x - 2, this.y - 1].currentFigure.Price + ScoreDepth; i++;
                }
            }
            /////////////////////////////////////////////////////////////////////////////////////////
            if (this.y + 1 < 8 && this.x - 2 >= 0)
            {
                if (chessBoard.chessTiles[this.x - 2, this.y + 1].currentFigure == null)
                {
                    Score[i] = 50 + ScoreDepth; i++;
                }
                else if (chessBoard.chessTiles[this.x - 2, this.y + 1].currentFigure != null && chessBoard.chessTiles[this.x - 2, this.y + 1].currentFigure.ChessColor != this.ChessColor)
                {
                    Score[i] = 100 + chessBoard.chessTiles[this.x - 2, this.y + 1].currentFigure.Price + ScoreDepth; i++;
                }
            }
            ////////////////////////////////////////////////////////////////////////////////////////////////
            ////////////////////////////////////////////////RIGHT///////////////////////////////////////////
            if (this.y - 1 >= 0 && this.x + 2 < 8)
            {
                if (chessBoard.chessTiles[this.x + 2, this.y - 1].currentFigure == null)
                {
                    Score[i] = 50 + ScoreDepth; i++;
                }
                else if (chessBoard.chessTiles[this.x + 2, this.y - 1].currentFigure != null && chessBoard.chessTiles[this.x + 2, this.y - 1].currentFigure.ChessColor != this.ChessColor)
                {
                    Score[i] = 100 + chessBoard.chessTiles[this.x + 2, this.y - 1].currentFigure.Price + ScoreDepth; i++;
                }
            }
            /////////////////////////////////////////////////////////////////////////////////////////
            if (this.y + 1 < 8 && this.x + 2 < 8)
            {
                if (chessBoard.chessTiles[this.x + 2, this.y + 1].currentFigure == null)
                {
                    Score[i] = 50 + ScoreDepth; i++;
                }
                else if (chessBoard.chessTiles[this.x + 2, this.y + 1].currentFigure != null && chessBoard.chessTiles[this.x + 2, this.y + 1].currentFigure.ChessColor != this.ChessColor)
                {
                    Score[i] = 100 + chessBoard.chessTiles[this.x + 2, this.y + 1].currentFigure.Price + ScoreDepth; i++;
                }
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
            /////////////////////////////////////////////////////////////////////////////////////
            /////////////////////////////////////UP///////////////////////////////////////////////
            if (this.y - 2 >= 0 && this.x - 1 >= 0)
            {
                if (chessBoard.chessTiles[this.x - 1, this.y - 2].currentFigure == null)
                {
                    moveList.Add(new ChessPosition(this.x - 1, this.y - 2));
                }
                else if (chessBoard.chessTiles[this.x - 1, this.y - 2].currentFigure != null && chessBoard.chessTiles[this.x - 1, this.y - 2].currentFigure.ChessColor != this.ChessColor)
                {
                    ChessPosition Kill = new ChessPosition(this.x - 1, this.y - 2);
                    Kill.PriceTile = 100 + chessBoard.chessTiles[this.x - 1, this.y - 2].currentFigure.Price;
                    kill2.Add(Kill);
                }
            }
            /////////////////////////////////////////////////////////////////////////////////////////
            if (this.y - 2 >= 0 && this.x + 1 < 8)
            {
                if (chessBoard.chessTiles[this.x + 1, this.y - 2].currentFigure == null)
                {
                    moveList.Add(new ChessPosition(this.x + 1, this.y - 2));
                }
                else if (chessBoard.chessTiles[this.x + 1, this.y - 2].currentFigure != null && chessBoard.chessTiles[this.x + 1, this.y - 2].currentFigure.ChessColor != this.ChessColor)
                {
                    ChessPosition Kill = new ChessPosition(this.x + 1, this.y - 2);
                    Kill.PriceTile = 100 + chessBoard.chessTiles[this.x + 1, this.y - 2].currentFigure.Price;
                    kill2.Add(Kill);
                }
            }
            /////////////////////////////////////////////////////////////////////////////////////////
            ////////////////////////////////////////DOWN/////////////////////////////////////////////
            if (this.y + 2 < 8 && this.x - 1 >= 0)
            {
                if (chessBoard.chessTiles[this.x - 1, this.y + 2].currentFigure == null)
                {
                    moveList.Add(new ChessPosition(this.x - 1, this.y + 2));
                }
                else if (chessBoard.chessTiles[this.x - 1, this.y + 2].currentFigure != null && chessBoard.chessTiles[this.x - 1, this.y + 2].currentFigure.ChessColor != this.ChessColor)
                {
                    ChessPosition Kill = new ChessPosition(this.x - 1, this.y + 2);
                    Kill.PriceTile = 100 + chessBoard.chessTiles[this.x - 1, this.y + 2].currentFigure.Price;
                    kill2.Add(Kill);
                }
            }
            /////////////////////////////////////////////////////////////////////////////////////////
            if (this.y + 2 < 8 && this.x + 1 < 8)
            {
                if (chessBoard.chessTiles[this.x + 1, this.y + 2].currentFigure == null)
                {
                    moveList.Add(new ChessPosition(this.x + 1, this.y + 2));
                }
                else if (chessBoard.chessTiles[this.x + 1, this.y + 2].currentFigure != null && chessBoard.chessTiles[this.x + 1, this.y + 2].currentFigure.ChessColor != this.ChessColor)
                {
                    ChessPosition Kill = new ChessPosition(this.x + 1, this.y + 2);
                    Kill.PriceTile = 100 + chessBoard.chessTiles[this.x + 1, this.y + 2].currentFigure.Price;
                    kill2.Add(Kill);
                }
            }
            ////////////////////////////////////////////////////////////////////////////////////////////////
            ////////////////////////////////////////////////LEFT///////////////////////////////////////////
            if (this.y - 1 >= 0 && this.x - 2 >= 0)
            {
                if (chessBoard.chessTiles[this.x - 2, this.y - 1].currentFigure == null)
                {
                    moveList.Add(new ChessPosition(this.x - 2, this.y - 1));
                }
                else if (chessBoard.chessTiles[this.x - 2, this.y - 1].currentFigure != null && chessBoard.chessTiles[this.x - 2, this.y - 1].currentFigure.ChessColor != this.ChessColor)
                {
                    ChessPosition Kill = new ChessPosition(this.x - 2, this.y - 1);
                    Kill.PriceTile = 100 + chessBoard.chessTiles[this.x - 2, this.y - 1].currentFigure.Price;
                    kill2.Add(Kill);
                }
            }
            /////////////////////////////////////////////////////////////////////////////////////////
            if (this.y + 1 < 8 && this.x - 2 >= 0)
            {
                if (chessBoard.chessTiles[this.x - 2, this.y + 1].currentFigure == null)
                {
                    moveList.Add(new ChessPosition(this.x - 2, this.y + 1));
                }
                else if (chessBoard.chessTiles[this.x - 2, this.y + 1].currentFigure != null && chessBoard.chessTiles[this.x - 2, this.y + 1].currentFigure.ChessColor != this.ChessColor)
                {
                    ChessPosition Kill = new ChessPosition(this.x - 2, this.y + 1);
                    Kill.PriceTile = 100 + chessBoard.chessTiles[this.x - 2, this.y + 1].currentFigure.Price;
                    kill2.Add(Kill);
                }
            }
            ////////////////////////////////////////////////////////////////////////////////////////////////
            ////////////////////////////////////////////////RIGHT///////////////////////////////////////////
            if (this.y - 1 >= 0 && this.x + 2 < 8)
            {
                if (chessBoard.chessTiles[this.x + 2, this.y - 1].currentFigure == null)
                {
                    moveList.Add(new ChessPosition(this.x + 2, this.y - 1));
                }
                else if (chessBoard.chessTiles[this.x + 2, this.y - 1].currentFigure != null && chessBoard.chessTiles[this.x + 2, this.y - 1].currentFigure.ChessColor != this.ChessColor)
                {
                    ChessPosition Kill = new ChessPosition(this.x + 2, this.y - 1);
                    Kill.PriceTile = 100 + chessBoard.chessTiles[this.x + 2, this.y - 1].currentFigure.Price;
                    kill2.Add(Kill);
                }
            }
            /////////////////////////////////////////////////////////////////////////////////////////
            if (this.y + 1 < 8 && this.x + 2 < 8)
            {
                if (chessBoard.chessTiles[this.x + 2, this.y + 1].currentFigure == null)
                {
                    moveList.Add(new ChessPosition(this.x + 2, this.y + 1));
                }
                else if (chessBoard.chessTiles[this.x + 2, this.y + 1].currentFigure != null && chessBoard.chessTiles[this.x + 2, this.y + 1].currentFigure.ChessColor != this.ChessColor)
                {
                    ChessPosition Kill = new ChessPosition(this.x + 2, this.y + 1);
                    Kill.PriceTile = 100 + chessBoard.chessTiles[this.x + 2, this.y + 1].currentFigure.Price;
                    kill2.Add(Kill);
                }
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

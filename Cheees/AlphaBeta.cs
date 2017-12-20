using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cheees
{
    class AlphaBeta
    {
        int HeightBoard;
        int HeightWhite;
        int HeightBlack;
        Graphics g;
        private ChessBoard chessBoard;




        public AlphaBeta(ChessBoard chessBoard)
        {
            this.chessBoard = chessBoard;

        }

        int CalculateBoard(ChessBoard board)
        {
            for(int i=0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++) {
                    if (board.chessTiles[i, j].currentFigure != null)
                    {
                        if (board.chessTiles[i, j].currentFigure.ChessColor == "BLACK")
                        {
                            HeightBlack += board.chessTiles[i, j].currentFigure.Price;
                        }
                        if (board.chessTiles[i, j].currentFigure.ChessColor == "WHITE")
                        {
                            HeightWhite += board.chessTiles[i, j].currentFigure.Price;
                        }
                    }
                }
            }
            HeightBoard = HeightWhite - HeightBlack;
            return HeightBoard;
        }

       public ChessPosition MinMaxRoot(int depth, ChessBoard board, string Color)
        {

            List<ChessPosition> movelist = new List<ChessPosition>();
            int bestValue;
            int currentValue;
            ChessPosition currentBestMove = null;
            if (Color == "WHITE")
            {
                bestValue = -9999;
                for (int i = 0; i < board.CheeesWhite.Count; i++)
                {
                    movelist.AddRange(board.CheeesWhite[i].move(board));
                }
                foreach (ChessPosition cPos in movelist)
                {
                    board = new ChessBoard(g);
                    combine(board);
                    board.step(cPos);
                    currentValue = minMax(depth - 1, board, "BLACK", -10000, 10000);
                    board.undo();
                    // System.out.println(boardValue + " " + cPos.figure.x + " " + cPos.figure.y + " " + cPos.figure);
                    if (currentValue > bestValue)
                    {
                        bestValue = currentValue;
                        currentBestMove = cPos;
                    }
                }

                return currentBestMove;
            }
            if (Color == "BLACK")
            {
                bestValue = 9999;

                for (int i = 0; i < board.CheeesBlack.Count; i++)
                {
                    movelist.AddRange(board.CheeesBlack[i].move(board));
                }
                foreach (ChessPosition cPos in movelist)
                {
                    board = new ChessBoard(g);
                    combine(board);
                    board.step(cPos);
                    currentValue = minMax(depth - 1, board, "WHITE", -10000, 10000);
                    board.undo();
                    // System.out.println(boardValue);
                    if (currentValue <= bestValue)
                    {
                        bestValue = currentValue;
                        
                        currentBestMove = cPos;
                    }
                }

                return currentBestMove;
            }


            return null;
        }

        private int minMax(int depth, ChessBoard newChessBoard, string Color, int alpha, int beta)
        {
            if (depth == 0)
            {
                return CalculateBoard(newChessBoard);
            }

            List<ChessPosition> moveList = new List<ChessPosition>();
            int bestValue = 0;


            if (Color == "WHITE")
            {
                bestValue = -9999;

                foreach (Figure fW in newChessBoard.CheeesWhite)
                {
                    moveList.AddRange(fW.move(newChessBoard));
                }
                foreach (ChessPosition cPos in moveList)
                {
                    newChessBoard = new ChessBoard(g);
                    combine(newChessBoard);
                    newChessBoard.step(cPos);
                    bestValue = Math.Max(bestValue, minMax(depth - 1, newChessBoard, "BLACK", alpha, beta));
                    newChessBoard.undo(); // return removed figures
                    alpha = Math.Max(alpha, bestValue);
                    if (beta <= alpha)
                    {
                        return bestValue;
                    }
                }
                return bestValue;
            }

            if (Color == "BLACK")
            {
                bestValue = 9999;
                foreach (Figure fW in newChessBoard.CheeesBlack)
                {
                    moveList.AddRange(fW.move(newChessBoard));
                }
                foreach (ChessPosition cPos in moveList)
                {
                    newChessBoard = new ChessBoard(g);
                    combine(newChessBoard);
                    newChessBoard.step(cPos);
                    bestValue = Math.Min(bestValue, minMax(depth - 1, newChessBoard, "WHITE", alpha, beta));
                    newChessBoard.undo(); // return removed figures

                    beta = Math.Min(beta, bestValue);
                    if (beta <= alpha)
                    {
                        return bestValue;
                    }
                }
                return bestValue;
            }

            return bestValue;
        }


        private void combine(ChessBoard combinedBoard)
        {
            combinedBoard.CheeesBlack = chessBoard.CheeesBlack;
            combinedBoard.CheeesWhite = chessBoard.CheeesWhite;
        }

    }
}

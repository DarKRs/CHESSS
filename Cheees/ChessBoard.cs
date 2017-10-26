using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cheees
{
    class ChessBoard
    {
        public TileChess[,] chessTiles;

        public List<Pawn> pawnsWhite;
        public List<Pawn> pawnsBlack;

        public List<Rook> RookWhite;
        public List<Rook> RookBlack;
        public List<Figure> CheeesWhite;
        public List<Figure> CheeesBlack;
        public ChessBoard()
        {
            chessTiles = new TileChess[8, 8];


            CheeesWhite = new List<Figure>();
            CheeesBlack = new List<Figure>();

            pawnsWhite = new List<Pawn>();
            pawnsBlack = new List<Pawn>();
            ////////////////////////////////
            RookWhite = new List<Rook>();
            RookBlack = new List<Rook>();
            for(int i = 0; i < 8; i++)
            {
                for(int j=0; j < 8; j++)
                {
                    chessTiles[i, j] = new TileChess();
                    chessTiles[i, j].xReal = i * 50;
                    chessTiles[i, j].yReal = j * 50;
                    chessTiles[i, j].x = i;
                    chessTiles[i, j].y = j;
                }
            }

            for(int i=0; i <8; i++)
            {
                CheeesWhite.Add(new Pawn("WHITE"));
                CheeesWhite[i].x = i;
                CheeesWhite[i].y = 6;
                CheeesBlack.Add(new Pawn("BLACK"));
                CheeesBlack[i].x = i;
                CheeesBlack[i].y = 1;
               

                /*pawnsWhite.Add(new Pawn("WHITE"));
                pawnsWhite[i].x = i;
                pawnsWhite[i].y = 6;
                pawnsBlack.Add(new Pawn("BLACK"));
                pawnsBlack[i].x = i;
                pawnsBlack[i].y = 1;*/

            }
            //////ROOT/////
            CheeesWhite.Add(new Rook("WHITE"));
            CheeesWhite[8].x = 0;
            CheeesWhite[8].y = 7;
            CheeesBlack.Add(new Rook("BLACK"));
            CheeesBlack[8].x = 0;
            CheeesBlack[8].y = 0;

            CheeesWhite.Add(new Rook("WHITE"));
            CheeesWhite[9].x = 7;
            CheeesWhite[9].y = 7;
            CheeesBlack.Add(new Rook("BLACK"));
            CheeesBlack[9].x = 7;
            CheeesBlack[9].y = 0;
            ////////KNIGHT////////
            CheeesWhite.Add(new Knight("WHITE"));
            CheeesWhite[10].x = 1;
            CheeesWhite[10].y = 7;
            CheeesBlack.Add(new Knight("BLACK"));
            CheeesBlack[10].x = 1;
            CheeesBlack[10].y = 0;

            CheeesWhite.Add(new Knight("WHITE"));
            CheeesWhite[11].x = 6;
            CheeesWhite[11].y = 7;
            CheeesBlack.Add(new Knight("BLACK"));
            CheeesBlack[11].x = 6;
            CheeesBlack[11].y = 0;
            /////////Bishop///////
            CheeesWhite.Add(new Bishop("WHITE"));
            CheeesWhite[12].x = 2;
            CheeesWhite[12].y = 7;
            CheeesBlack.Add(new Bishop("BLACK"));
            CheeesBlack[12].x = 2;
            CheeesBlack[12].y = 0;
            CheeesWhite.Add(new Bishop("WHITE"));
            CheeesWhite[13].x = 5;
            CheeesWhite[13].y = 7;
            CheeesBlack.Add(new Bishop("BLACK"));
            CheeesBlack[13].x = 5;
            CheeesBlack[13].y = 0;
            ///////////QUEEEN/////////
            CheeesWhite.Add(new Queen("WHITE"));
            CheeesWhite[14].x = 3;
            CheeesWhite[14].y = 7;
            CheeesBlack.Add(new Queen("BLACK"));
            CheeesBlack[14].x = 3;
            CheeesBlack[14].y = 0;
            //////////KING/////////////
            CheeesWhite.Add(new KING("WHITE"));
            CheeesWhite[15].x = 4;
            CheeesWhite[15].y = 7;
            CheeesBlack.Add(new KING("BLACK"));
            CheeesBlack[15].x = 4;
            CheeesBlack[15].y = 0;
            /*    ///////////////////
                RookWhite.Add(new Rook("WHITE"));
                RookWhite[0].x = 0;
                RookWhite[0].y = 7;
                RookBlack.Add(new Rook("BLACK"));
                RookBlack[0].x = 0;
                RookBlack[0].y = 0;

                RookWhite.Add(new Rook("WHITE"));
                RookWhite[1].x = 8;
                RookWhite[1].y = 7;
                RookBlack.Add(new Rook("BLACK"));
                RookBlack[1].x = 8;
                RookBlack[1].y = 0;*/
        }





        public void draw(Graphics g)
        {
            
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if ((i + j) % 2 == 0)
                    {
                        chessTiles[i,j].draw(g, "WHITE");
                    }
                    else
                    {
                        chessTiles[i,j].draw(g, "BLACK");
                    }
                }
            }
            for(int i=0; i < CheeesBlack.Count; i++)
            {
                chessTiles[CheeesBlack[i].x, CheeesBlack[i].y].drawFigure(g, CheeesBlack[i]);
            }

            for (int i = 0; i < CheeesWhite.Count; i++)
            {
                chessTiles[CheeesWhite[i].x, CheeesWhite[i].y].drawFigure(g, CheeesWhite[i]);
            }

            /*  for (int i = 0; i < pawnsWhite.Count; i++)
              {
                  chessTiles[pawnsWhite[i].x , pawnsWhite[i].y].drawFigure(g, pawnsWhite[i]);
              }

             for (int i = 0; i < RookWhite.Count; i++)
              {
                  chessTiles[RookWhite[i].x, RookWhite[i].y].drawFigure(g, RookWhite[i]);
              }
              for (int i = 0; i < RookBlack.Count; i++)
              {
                  chessTiles[RookBlack[i].x, RookBlack[i].y].drawFigure(g, RookBlack[i]);
              }
              if (pawnsBlack.Count != 0)
                  for (int i = 0; i < pawnsBlack.Count; i++)
                  {
                      chessTiles[pawnsBlack[i].x , pawnsBlack[i].y].drawFigure(g, pawnsBlack[i]);
                  }*/
        }
    }
    }


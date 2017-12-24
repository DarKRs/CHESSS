using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cheees
{
    public class ChessBoard //16x16
    {
        Graphics g;
        AlphaBeta aIalpha;

        Random rnd = new Random();
        public TileChess[,] chessTiles;
       
        public List<Pawn> pawnsWhite;
        public List<Pawn> pawnsBlack;
        public List<ChessPosition> moveList;
        public ChessPosition move;
        public List<Rook> RookWhite;
        public List<Rook> RookBlack;
        

        private List<ChessPosition> saveMoves;
        private List<Figure> saveFigs;

        public List<Figure> CheeesWhite;
        public List<Figure> CheeesBlack;

        public ChessBoard(Graphics graphics)
        {
            g = graphics;
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

            aIalpha = new AlphaBeta(this);
            saveMoves = new List<ChessPosition>();
            saveFigs = new List<Figure>();
        }

        public void stepsUp()
        {
            List<Figure> allFig = new List<Figure>();
            allFig.AddRange(CheeesBlack);
            allFig.AddRange(CheeesWhite);


            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    chessTiles[i,j].currentFigure= null;
                }
            }
            foreach (Figure figure in allFig)
            {
                // System.out.println(figure.x + " " + figure.y + " --" + figure);
                chessTiles[figure.x,figure.y].currentFigure = figure;
            }
        }

        public void step(ChessPosition chessPosition)
        {
            saveMoves.Add(new ChessPosition(chessPosition.TileFigure.x, chessPosition.TileFigure.y, chessPosition.TileFigure));
            chessPosition.TileFigure.step(chessPosition);
            if (chessPosition.TileFigure.ChessColor == "WHITE")
            {
                for (int i = 0; i < CheeesWhite.Count; i++)
                {
                    for (int j = 0; j < CheeesBlack.Count; j++)
                    {
                        if (CheeesWhite[i].y == CheeesBlack[j].y && CheeesWhite[i].x == CheeesBlack[j].x)
                        {
                            saveFigs.Add(CheeesBlack[j]);
                            CheeesBlack.RemoveAt(j);
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < CheeesBlack.Count; i++)
                {
                    for (int j = 0; j < CheeesWhite.Count; j++)
                    {
                        if (CheeesWhite[j].y == CheeesBlack[i].y && CheeesWhite[j].x == CheeesBlack[i].x)
                        {
                            saveFigs.Add(CheeesWhite[j]);
                            CheeesWhite.RemoveAt(j);
                        }
                    }
                }
            }

            stepsUp();
        }

        public void undo()
        {
            if (saveFigs.Count != 0)
            {
                foreach (Figure figure in saveFigs)
                {
                    if (figure.ChessColor == "BLACK")
                    {
                        CheeesBlack.Add(figure);
                    }
                    else
                    {
                        CheeesWhite.Add(figure);
                    }
                }
            }

            if (saveMoves.Count != 0)
                foreach (ChessPosition csSave in saveMoves)
                {
                    csSave.TileFigure.step(csSave);
                }
            saveFigs.Clear();
            saveMoves.Clear();
        }


        public void updateBlack()
        {
            int CurrentChees=999;
            for (int i = 0; i < CheeesBlack.Count; i++)
            {
                if (CheeesBlack[i].AlpBet(this) == 9999 + 100)
                {
                    CurrentChees = i;
                }
            }
            if (CurrentChees != 999)
            {
                List<ChessPosition> killKingList = CheeesBlack[CurrentChees].move(this);
                ChessPosition killKing = new ChessPosition(0, 0, CheeesBlack[CurrentChees]);
                int bestvalue = 0;
                for (int k = 0; k < killKingList.Count; k++)
                {
                    if (killKingList[k].PriceTile > bestvalue)
                    {
                        bestvalue = killKingList[k].PriceTile;
                        killKing = killKingList[k];
                    }
                }
                CheeesBlack[CurrentChees].step(killKing);
             
                for (int i = 0; i < CheeesBlack.Count; i++)
                {
                    for (int j = 0; j < CheeesWhite.Count; j++)
                    {
                        if (CheeesBlack[i].y == CheeesWhite[j].y && CheeesBlack[i].x == CheeesWhite[j].x)
                        {

                            CheeesWhite.RemoveAt(j);
                        }
                      
                    }
                }
                draw();
                update();
                MessageBox.Show("GAME OWER (ВСЕ КОНЕЦ)",
                                "Победа черных", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                step(aIalpha.MinMaxRoot(4, this, "BLACK"));

                for (int i = 0; i < CheeesBlack.Count; i++)
                {
                    for (int j = 0; j < CheeesWhite.Count; j++)
                    {
                        if (CheeesWhite[j].y == CheeesBlack[i].y && CheeesWhite[j].x == CheeesBlack[i].x)
                        {
                            saveFigs.Add(CheeesWhite[j]);
                            CheeesWhite.RemoveAt(j);
                        }
                      
                    }
                }
                draw();
                update();
            }
            /*   int ChessRand = rnd.Next(CheeesBlack.Count-1);
               int CurrentChees = 0;
               int buffer = 0;
               int Best = 0;
               for (int i = 0; i < CheeesBlack.Count; i++)
               {
                   buffer = CheeesBlack[i].AlpBet(this);
                   if (buffer > Best) { Best = buffer; CurrentChees = i; }
               }
               if (Best == 50)
               {
                   CurrentChees = ChessRand;
               }
               /////////////////////////////////Проверка на безопасность короля///////////////////////////////
              
              // move = CheeesBlack[CurrentChees].move(this);
               if (move != null)
               {
                   CheeesBlack[CurrentChees].x = move.x;
                   CheeesBlack[CurrentChees].y = move.y;

                   for (int i = 0; i < CheeesWhite.Count; i++)
                   {
                       if (CheeesWhite[i].x == CheeesBlack[CurrentChees].x && CheeesWhite[i].y == CheeesBlack[CurrentChees].y)
                       {
                           if(CheeesWhite[i].Name == "KING")
                           {
                               MessageBox.Show("GAME OWER (ВСЕ КОНЕЦ)",
                                "Победа черных", MessageBoxButtons.OK, MessageBoxIcon.Information);
                           }
                           CheeesWhite.RemoveAt(i);
                       }
                   }
                   draw();
                   update();
               }
               else
               {
                   updateBlack();
                   return;
               }*/
        }

        public void updateWhite()
        {
            int CurrentChees = 999;
            for (int i = 0; i < CheeesWhite.Count; i++)
            {
                if (CheeesWhite[i].AlpBet(this) == 9999 + 100)
                {
                    CurrentChees = i;
                }
            }
            if (CurrentChees != 999)
            {
                List<ChessPosition> killKingList = CheeesWhite[CurrentChees].move(this);
                ChessPosition killKing = new ChessPosition(0,0,CheeesWhite[CurrentChees]);
                int bestvalue = 0;
                for(int k = 0; k < killKingList.Count; k++)
                {
                    if(killKingList[k].PriceTile > bestvalue)
                    {
                        bestvalue = killKingList[k].PriceTile;
                        killKing = killKingList[k];
                    }
                }
                CheeesWhite[CurrentChees].step(killKing);
                for (int i = 0; i < CheeesWhite.Count; i++)
                {
                    for (int j = 0; j < CheeesBlack.Count; j++)
                    {
                        if (CheeesWhite[i].y == CheeesBlack[j].y && CheeesWhite[i].x == CheeesBlack[j].x)
                        {
                            
                            CheeesBlack.RemoveAt(j);
                        }
                    }
                }
                
                MessageBox.Show("GAME OWER (ВСЕ КОНЕЦ)",
                              "Победа белых", MessageBoxButtons.OK, MessageBoxIcon.Information);
                draw();
                update();
            }
            else
            {
                step(aIalpha.MinMaxRoot(4, this, "WHITE"));
                for (int i = 0; i < CheeesWhite.Count; i++)
                {
                    for (int j = 0; j < CheeesBlack.Count; j++)
                    {
                        if (CheeesWhite[i].y == CheeesBlack[j].y && CheeesWhite[i].x == CheeesBlack[j].x)
                        {
                            
                            CheeesBlack.RemoveAt(j);
                        }
                    }
                }
                draw();
                update();
            }
            /* int ChessRand = rnd.Next(CheeesWhite.Count - 1);
             int CurrentChees = 0;
             int buffer = 0;
             int Best = 0;
             for (int i = 0; i < CheeesWhite.Count; i++)
             {
                 buffer = CheeesWhite[i].AlpBet(this);
                 if (buffer > Best) { Best = buffer; CurrentChees = i; }
             }
             if (Best == 50)
             {
                 CurrentChees = ChessRand;
             }
             /////////////////////////////////Проверка на безопасность короля///////////////////////////////
             for (int i = 0; i < CheeesBlack.Count; i++)
             {
                 if(CheeesBlack[i].AlpBet(this) == 9999 + 100)
                 {
                     for(int j=0; i < CheeesWhite.Count; i++)
                     {
                         if(CheeesWhite[i].Name == "KING")
                         {
                             CurrentChees = i;
                         }
                     }
                 }
             }

            // move = CheeesWhite[CurrentChees].move(this);
             if(move != null)
             {
                 CheeesWhite[CurrentChees].x = move.x;
                 CheeesWhite[CurrentChees].y = move.y;
                 for(int i = 0; i < CheeesBlack.Count; i++)
                 {
                     if(CheeesBlack[i].x == CheeesWhite[CurrentChees].x && CheeesBlack[i].y == CheeesWhite[CurrentChees].y)
                     {
                         if (CheeesBlack[i].Name == "KING")
                         {
                             MessageBox.Show("GAME OWER (ВСЕ КОНЕЦ)",
                              "Победа белых", MessageBoxButtons.OK, MessageBoxIcon.Information);
                         }
                         CheeesBlack.RemoveAt(i);
                     }
                 }
                 draw();
                 update();
             }
             else
             {
                 updateWhite();
                 return;
             }*/
        }


        public void draw()
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
                chessTiles[CheeesBlack[i].x, CheeesBlack[i].y].currentFigure = CheeesBlack[i];
            }

            for (int i = 0; i < CheeesWhite.Count; i++)
            {
                chessTiles[CheeesWhite[i].x, CheeesWhite[i].y].drawFigure(g, CheeesWhite[i]);
                chessTiles[CheeesWhite[i].x, CheeesWhite[i].y].currentFigure = CheeesWhite[i];
            }

       
        }

        public void update()
        {
            ///CLEAR ALL FIGURE
            for(int i = 0; i < 8; i++)
            {
                for(int j = 0; j < 8; j++)
                {
                    chessTiles[i, j].currentFigure = null;
                }
            }
            
            for (int i = 0; i < CheeesBlack.Count; i++)
            {
                
                chessTiles[CheeesBlack[i].x, CheeesBlack[i].y].drawFigure(g, CheeesBlack[i]);
                chessTiles[CheeesBlack[i].x, CheeesBlack[i].y].currentFigure = CheeesBlack[i];

            }

            for (int i = 0; i < CheeesWhite.Count; i++)
            {
                
                chessTiles[CheeesWhite[i].x, CheeesWhite[i].y].drawFigure(g, CheeesWhite[i]);
                chessTiles[CheeesWhite[i].x, CheeesWhite[i].y].currentFigure = CheeesWhite[i];
            }
        }


    }
    }


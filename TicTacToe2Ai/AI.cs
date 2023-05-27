using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TicTacToe2Ai.Properties;

namespace TicTacToe2Ai
{
    public static class AI
    {
        public static void RandomMove(PictureBox[,] MyTab, int flags, int number)
        {
            Random random = new Random();
            int randomnumber = random.Next(number);
            int randomnumber2 = random.Next(number);
            if (MyTab[randomnumber, randomnumber2].Name != "O" && MyTab[randomnumber, randomnumber2].Name != "X")
            {
                MyTab[randomnumber, randomnumber2].Image = Resources.X;
                MyTab[randomnumber, randomnumber2].Name = "X";
            }
            else
            {
                RandomMove(MyTab, flags, number);
            }
        }

        public static void MakeBestMove(PictureBox[,] MyTab, int number)
        {
            var X = BestMove(MyTab, number);
            X.Image = Resources.X;
            X.Name = "X";
        }


        public static int Evaluate(PictureBox[,] MyBoard, int number)
        {
            if (Mechanic.CHeckIfWins(MyBoard, number, 0))
                return 10;
            else if (Mechanic.CHeckIfWins(MyBoard, number, 1))
                return -10;
            else
                return 0;
        }
        public static bool IsMovePossible(PictureBox[,] MyTab)
        {
            if (Mechanic.CheckifDraw(MyTab) == false)
                return true;
            return false;
        }


        public static int MiniMax(PictureBox[,] MyTab, int depth, bool IsMax, int number)
        {
            int score = Evaluate(MyTab, number);
            if(score == 10)
                return score;
            if (score == -10)
                return score;
            if (IsMovePossible(MyTab) == false)
                return 0;
            if(IsMax)
            {
                int best = -1000;
                for (int i = 0; i < number; i++)
                {
                    for (int j = 0; j < number; j++)
                    {
                        if (MyTab[i, j].Name != "O" && MyTab[i, j].Name != "X")
                        {
                            MyTab[i, j].Name = "X";
                            best = Math.Max(best, MiniMax(MyTab, depth + 1, !IsMax, number));
                            MyTab[i, j].Name = null;
                        }
                    }
                }
                return best;
            }
            else
            {
                int best = 1000;
                for (int i = 0; i < number; i++)
                {
                    for (int j = 0; j < number; j++)
                    {
                        if (MyTab[i, j].Name != "O" && MyTab[i, j].Name != "X")
                        {
                            MyTab[i, j].Name = "O";
                            best = Math.Min(best, MiniMax(MyTab, depth + 1, !IsMax, number));
                            MyTab[i, j].Name = null;
                        }
                    }
                }
                return best;
            }

        }
        public static PictureBox BestMove(PictureBox[,] MyTab, int number)
        {
            int bestVal = -1000;
            PictureBox BestMove = new PictureBox();
            for (int i = 0; i < number; i++)
                for (int j = 0; j < number; j++)
                {
                    if (MyTab[i, j].Name != "O" && MyTab[i, j].Name != "X")
                    {
                        MyTab[i, j].Name = "X";
                        int MoveValue = AlphaBetaPruning(MyTab, 0, false, number, -1000, 1000);
                        //best = Math.Max(best, MiniMax(MyTab, depth + 1, !IsMax, number));
                        MyTab[i, j].Name = null;
                        if(MoveValue > bestVal)
                        {
                            BestMove = MyTab[i, j];
                            bestVal = MoveValue;
                        }
                    }
                }
            return BestMove;
        }



        public static int AlphaBetaPruning(PictureBox[,] MyTab, int depth, bool IsMax, int number, int alpha, int beta)
        {
            int score = Evaluate(MyTab, number);
            if (score == 10)
                return score;
            if (score == -10)
                return score;
            if (IsMovePossible(MyTab) == false)
                return 0;
            if (IsMax)
            {
                int best = -1000;
                for (int i = 0; i < number; i++)
                {
                    for (int j = 0; j < number; j++)
                    {
                        if (MyTab[i, j].Name != "O" && MyTab[i, j].Name != "X")
                        {
                            MyTab[i, j].Name = "X";
                            //MyTab[i, j].Name = "X";
                            int MyScore = AlphaBetaPruning(MyTab, depth + 1, !IsMax, number, alpha, beta);
                            MyTab[i, j].Name = null;
                            
                            best = Math.Max(best, MyScore);
                            alpha = Math.Max(alpha, MyScore);
                            if(beta <= alpha)
                            {
                                break;
                            }
                        }
                    }
                }
                return best;
            }
            else
            {
                int best = 1000;
                for (int i = 0; i < number; i++)
                {
                    for (int j = 0; j < number; j++)
                    {
                        if (MyTab[i, j].Name != "O" && MyTab[i, j].Name != "X")
                        {
                            MyTab[i, j].Name = "O";
                            int MyScore = AlphaBetaPruning(MyTab, depth + 1, !IsMax, number, alpha, beta);
                            MyTab[i, j].Name = null;
                            best = Math.Min(best,MyScore);
                            beta = Math.Min(beta,MyScore);
                            if (beta <= alpha)
                            {
                                break;
                            }
                        }
                    }
                }
                return best;
            }
        }
    }
}

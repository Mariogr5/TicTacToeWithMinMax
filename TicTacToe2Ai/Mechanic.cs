using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TicTacToe2Ai.Properties;

namespace TicTacToe2Ai
{
    public static class Mechanic
    {
        public static void Newgame(PictureBox[,] MyTable, ref int flags)
        {
            foreach(PictureBox X in MyTable)
            {
                X.Image = null;
                X.Name = null;
                flags = 1;
            }
        }


        public static void ClickWithBot(PictureBox[,] MyTable, int flags, int number)
        {
            for(int i = 0; i < number; i++)
                for(int j = 0; j < number; j++)
                {
                    MyTable[i, j].Click += (sender, e) =>
                    {
                        PictureBox x = sender as PictureBox;
                        if (flags == 1 && x.Image == null)
                        {
                            x.Image = Resources.Circleeee;
                            x.Name = "O";
                            if (CHeckIfWins(MyTable, number, flags))
                            {
                                MessageBox.Show("KÓłko wygrało!!");
                                Newgame(MyTable, ref flags);
                                flags = 1;
                            }
                            else if(CheckifDraw(MyTable))
                            {
                                MessageBox.Show("Remis!!");
                                Newgame(MyTable, ref flags);
                                flags = 1;
                            }
                            else
                                flags = 0;
                            if (flags == 0)
                            {
                                AI.MakeBestMove(MyTable, number);
                                if (CHeckIfWins(MyTable, number, flags))
                                {
                                    MessageBox.Show("Krzyżyk wygrał!!");
                                    Newgame(MyTable, ref flags);
                                }
                                else if (CheckifDraw(MyTable))
                                {
                                    MessageBox.Show("Remis!!");
                                    Newgame(MyTable, ref flags);
                                    flags = 1;
                                }
                                else
                                    flags = 1;
                            }
                        }

                    };
                }
        }
        public static void ClickWithPlayer(PictureBox[,] MyTable, int flags, int number)
        {
            for (int i = 0; i < number; i++)
                for (int j = 0; j < number; j++)
                {
                    MyTable[i, j].Click += (sender, e) =>
                    {
                        PictureBox x = sender as PictureBox;
                        if (flags == 1 && x.Image == null)
                        {
                            x.Image = Resources.Circleeee;
                            x.Name = "O";
                            if (CHeckIfWins(MyTable, number, flags))
                            {
                                MessageBox.Show("KÓłko wygrało!!");
                                Newgame(MyTable, ref flags);
                                flags = 1;
                            }
                            else if (CheckifDraw(MyTable))
                            {
                                MessageBox.Show("Remis!!");
                                Newgame(MyTable, ref flags);
                                flags = 1;
                            }
                            else
                                flags = 0;
                        }
                        else if(flags == 0 && x.Image == null)
                        {
                            x.Image = Resources.X;
                            x.Name = "X";
                            if (CHeckIfWins(MyTable, number, flags))
                            {
                                MessageBox.Show("Krzyżyk wygrał!!");
                                Newgame(MyTable, ref flags);
                                flags = 1;
                            }
                            else if (CheckifDraw(MyTable))
                            {
                                MessageBox.Show("Remis!!");
                                Newgame(MyTable, ref flags);
                                flags = 1;
                            }
                            else
                                flags = 1;

                        }

                    };
                }
        }

        public static bool CHeckIfWins(PictureBox[,] MyTable, int number, int flags)
        {
            //number = 3;
            int sum = 0;
            for (int x = 0; x < number; x++)
            {
                for (int y = 0; y < number; y++)
                {
                    if (flags == 1)
                    {
                        if (MyTable[x, y].Name == "O")
                            sum++;
                    }
                    else if (flags == 0)
                    {
                        if (MyTable[x, y].Name == "X")
                            sum++;
                    }
                    if (sum == number)
                        return true;
                }
                sum = 0;
            }
            sum = 0;
            for (int x = 0; x < number; x++)
            {
                for (int y = 0; y < number; y++)
                {
                    if (flags == 1)
                    {
                        if (MyTable[y, x].Name == "O")
                            sum++;
                    }
                    else if (flags == 0)
                    {
                        if (MyTable[y, x].Name == "X")
                            sum++;
                    }
                    if (sum == number)
                        return true;
                }
                sum = 0;
            }
            sum = 0;
                for (int y = 0; y < number; y++)
                {
                    if (flags == 1)
                    {
                        if (MyTable[y, y].Name == "O")
                            sum++;
                    }
                    else if (flags == 0)
                    {
                        if (MyTable[y, y].Name == "X")
                            sum++;
                    }
                }
                if (sum == number)
                    return true;
            sum = 0;
            for (int y = number - 1; y >= 0; y--)
            {
                if (flags == 1)
                {
                    if (MyTable[number - 1 - y, y].Name == "O")
                        sum++;
                }
                else if (flags == 0)
                {
                    if (MyTable[number - 1 - y, y].Name == "X")
                        sum++;
                }
            }
            if (sum == number)
                return true;
            return false;
        }

        public static bool CheckifDraw(PictureBox[,] MyBoard)
        {
            foreach(var x in MyBoard)
            {
                if (x.Name != "X" && x.Name != "O")
                    return false;
            }
            return true;
        }
    }
}

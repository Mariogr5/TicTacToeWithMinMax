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



        public static void BestMove(PictureBox[,] MyTab)
        {

        }

        public static int Evaluate(PictureBox[,] MyBoard, int number)
        {
            if (Mechanic.CHeckIfWins(MyBoard, number, 1))
                return 10;
            else if (Mechanic.CHeckIfWins(MyBoard, number, 0))
                return -10;
            //else if (Mechanic.CheckifDraw(MyBoard))
            else
                return 0;
        }
        public static bool IsMovePossible(PictureBox[,] MyTab)
        {
            if (Mechanic.CheckifDraw(MyTab))
                return false;
            return true;
        }
    }
}

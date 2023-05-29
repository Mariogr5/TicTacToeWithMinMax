using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TicTacToe2Ai.Properties;

namespace TicTacToe2Ai
{
    public class Board
    {
        public Board(int number)
        {
            Number = number;
        }

        int Number { get; set; }

        public void MakeBard(Panel panel1)
        {
            int iterator = panel1.Width;
            for (int i = 0; i < iterator; i+=10)
            {
                int z = 0;
                for (int j = 0; j < iterator; j+=10)
                {
                    z += 50;
                    var NewObject = new PictureBox();
                    NewObject.BackColor = Color.Black;
                    NewObject.Size = new Size(10, 10);
                    if(i % 100 == 0 && i != 0 && i != panel1.Width)
                    {
                        NewObject.Location = new Point(i, j);
                        panel1.Controls.Add(NewObject);
                    }
                    if(j % 100 == 0 && j != 0 && j != panel1.Width)
                    {
                        NewObject.Location = new Point(i, j);
                        panel1.Controls.Add(NewObject);
                    }

                }
            }
        }

        public PictureBox[,] MakeFields(Panel panel1)
        {
            var MyFields = new PictureBox[Number, Number];
            for(int i = 0; i < Number; i++)
                for(int j = 0; j < Number; j++)
                {
                    var NewObject = new PictureBox();
                    NewObject.BackColor = Color.White;
                    NewObject.SizeMode = PictureBoxSizeMode.StretchImage;
                    NewObject.Name = null;
                    NewObject.Size = new Size(100, 100);
                    if(i == 0 && j != 0)
                        NewObject.Location = new Point(i * 100, 10 + (j * 100));
                    else if(i != 0 && j == 0)
                        NewObject.Location = new Point((i*100) + 10,j * 100);
                    else if (i != 0 && j != 0)
                        NewObject.Location = new Point((i*100) + 10, (j*100) + 10);
                    else if (i == 0 && j == 0)
                        NewObject.Location = new Point(i, j);
                    MyFields[i, j] = NewObject;
                    panel1.Controls.Add(NewObject);
                }
            return MyFields;
        
        }


        public void Clearpanel(Panel panel1)
        {
            panel1.Controls.Clear();
        }
    }
}

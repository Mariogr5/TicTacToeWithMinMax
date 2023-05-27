using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe2Ai
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //Mechanic.Newgame();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int number = 3;
            var MyBoard = new Board(number);
            int flags = 1;
            //MyBoard.MakeBard(panel1);
            panel1.Size = new Size(number * 100, number * 100); //+ //(number - 1) * 10);
             
            //panel1.Size = new Size(500, 500);
            panel1.Location = new Point(0, 0);
            MyBoard.MakeBard(panel1);
            var MyTableofPictureBoxes = MyBoard.MakeFields(panel1);
            Mechanic.Newgame(MyTableofPictureBoxes, ref flags);
            Mechanic.ClickWithBot(MyTableofPictureBoxes, flags, number);
            //MessageBox.Show("Siema");
            //Xforeach(PictureBox pictureBox in X)
            //{
            //    pictureBox.BackColor = Color.Red;
            //}
            // X[1, 1].BackColor = Color.Red;
            // for (int i = 0; i < panel1.Width; i++)
            //     for (int j = 0; j < panel1.Width; j++)
            //         panel1.Controls.Add(P[i, j]);
        }
    }
}

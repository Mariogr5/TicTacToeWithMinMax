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
        int number = 0;
        int Defender = -1;
        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //number = 5;
            var MyBoard = new Board(number);
            int flags = 1;
            var buttons = new Button[4] { button1, button2, button3, button4 };
           
            MyBoard.Clearpanel(panel1);
            panel1.Size = new Size(number * 100, number * 100);
            panel1.Location = new Point(0, 0);
            MyBoard.MakeBard(panel1);
            var MyTableofPictureBoxes = MyBoard.MakeFields(panel1);
            //Mechanic.ClickWithBot(MyTableofPictureBoxes, flags, number);
            if(Defender == 1)
                Mechanic.ClickWithPlayer(MyTableofPictureBoxes, flags, number);
            if(Defender == 2)
               Mechanic.ClickWithBot(MyTableofPictureBoxes, flags, number);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            number = 3;
            if(Defender != -1)
            Form1_Load(sender, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            number = 4;
            if (Defender != -1)
                Form1_Load(sender, e);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            number = 5;
            if (Defender != -1)
                Form1_Load(sender, e);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            number = 6;
            if (Defender != -1)
                Form1_Load(sender, e);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Defender = 1;
            panel1.Controls.Clear();
            if (number != 0)
                Form1_Load(sender, e);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Defender = 2;
            panel1.Controls.Clear();
            if(number != 0)
                Form1_Load(sender, e);
        }
    }
}

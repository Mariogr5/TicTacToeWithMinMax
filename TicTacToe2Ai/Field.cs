using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe2Ai
{
    public class Field : PictureBox
    {
        public Field(PictureBox pictureBox, string numberoffield, int value)
        {
            this.pictureBox = pictureBox;
            this.Numberoffield = numberoffield;
            this.Value = value;
        }

        PictureBox pictureBox { get; set; }
        string Numberoffield { get; set; }
        int Value { get; set; } // 1 - Circel, 0 - Empty, -1 - X
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cheees
{
    public partial class Form1 : Form
    {
        Graphics g;
        ChessBoard cb;
        public Form1()
        {
            InitializeComponent();
            g = pictureBox1.CreateGraphics();
            cb = new ChessBoard(g);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            cb.draw();
           

        }

        private void button2_Click(object sender, EventArgs e)
        {
            cb.updateChess();
        }
    }
}

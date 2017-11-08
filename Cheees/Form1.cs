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
        bool FlagHod;
        public Form1()
        {
            InitializeComponent();
            g = pictureBox1.CreateGraphics();
            cb = new ChessBoard(g);
            FlagHod = false; // 0 == WHITE ;; 1 == BLACK
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            cb.draw();

            Hod.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            updateChess();
        }

        private void updateChess()
        {
            if (FlagHod == false)
            {
                Hod.Text = "Ход черных";
                cb.updateWhite();
                FlagHod = true;
                return;
            }
            if (FlagHod == true)
            {
                Hod.Text = "Ход белых";
                cb.updateBlack();
                FlagHod = false;
                return;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Tic_Tac_Toe_Game
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        enum enTurnPlayers { Player1 = 1, Player2 = 2};


        enTurnPlayers TurnPlayers;
        


        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Color White = Color.FromArgb(255, 255, 255);
            Pen wPen = new Pen(White);
            wPen.Width = 7;

            wPen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            wPen.EndCap = System.Drawing.Drawing2D.LineCap.Round;

            e.Graphics.DrawLine(wPen, 400, 300, 1050, 300);
            e.Graphics.DrawLine(wPen, 400, 460, 1050, 460);

            e.Graphics.DrawLine(wPen, 610, 140, 610, 620);
            e.Graphics.DrawLine(wPen, 840, 140, 840, 620);
        }

        
        private void button2_Click(object sender, EventArgs e)
        {
            button2.Image = Properties.Resources.X;
        }

        private void button3_Click(object sender, EventArgs e)
        {

            button3.Image = Properties.Resources.O;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button4.Image = Properties.Resources.X;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            button5.Image = Properties.Resources.O;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            button6.Image = Properties.Resources.X;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            button7.Image = Properties.Resources.O;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            button8.Image = Properties.Resources.X;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            button9.Image = Properties.Resources.O;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            button10.Image = Properties.Resources.X;
        }


    }
}

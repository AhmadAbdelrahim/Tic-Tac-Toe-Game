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
                
        enum enPlayer
        { 
            Player1,
            Player2
        };

        enum enWinner
        {
            Player1,
            Player2,
            Draw,
            GameInProgress
        };

        struct stGameStatus
        {
            public enWinner Winner;
            public bool GameOver;
            public short PlayCount;
        }

        stGameStatus GameStatus;

        enPlayer PlayerTurn = enPlayer.Player1;




        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Color White = Color.FromArgb(255, 255, 155);
            Pen wPen = new Pen(White);
            wPen.Width = 7;
            
            //whitePen.DashStyle = System.Drawomg.Drawing2D.DashStyle.Dash;
            wPen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            wPen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
            
            //draw Horizental lines
            e.Graphics.DrawLine(wPen, 400, 300, 1050, 300);
            e.Graphics.DrawLine(wPen, 400, 460, 1050, 460);
            
            //draw Vertical lines
            e.Graphics.DrawLine(wPen, 610, 140, 610, 620);
            e.Graphics.DrawLine(wPen, 840, 140, 840, 620);
        }

        void EndGame()
        {
            lblPlayer.Text = "Game Over";
            switch (GameStatus.Winner)
            {
                case enWinner.Player1:
                    lblProgress.Text = "Player 1";
                    break;
                case enWinner.Player2:
                    lblProgress.Text = "Player 2";
                    break;
                default:
                    lblProgress.Text = "Draw";
                    break;
            }
            MessageBox.Show("Game Over", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        public bool CheckValue(Button btn1, Button btn2, Button btn3)
        {
            if(btn1.Tag.ToString() != "?" && btn1.Tag.ToString() == btn2.Tag.ToString() && btn1.Tag.ToString() == btn3.Tag.ToString())
            {
                btn1.BackColor = Color.GreenYellow;
                btn2.BackColor = Color.GreenYellow;
                btn3.BackColor = Color.GreenYellow;

                if(btn1.Tag.ToString() == "X")
                {
                    GameStatus.Winner = enWinner.Player1;
                    GameStatus.GameOver = true;
                    EndGame();
                    return true;
                }
                else
                {
                    GameStatus.Winner = enWinner.Player2;
                    GameStatus.GameOver = true;
                    EndGame();
                    return true;
                }
            }
            GameStatus.GameOver = false;
            return false;
        }

        public void CheckWinner()
        {
            // Checked Rows
            //Row1
            if (CheckValue(button2, button3, button4))
                return;
            //Row2
            if (CheckValue(button5, button6, button7))
                return;
            //Row3
            if (CheckValue(button8, button9, button10))
                return;

            //Checked Columns
            //Col1
            if (CheckValue(button2, button5, button8))
                return;
            //Col2
            if (CheckValue(button3, button6, button9))
                return;
            //Col3
            if (CheckValue(button4, button7, button10))
                return;

            //Checked Diagonal
            //Diagonal1
            if (CheckValue(button2, button6, button10))
                return;
            //Diagonal2
            if (CheckValue(button4, button6, button8))
                return;
        }

        public void ChangeImage(Button btn)
        {
            if(btn.Tag.ToString() == "?")
            {
                switch(PlayerTurn)
                {
                    case enPlayer.Player1:
                        btn.Image = Properties.Resources.O;
                        PlayerTurn = enPlayer.Player2;
                        lblPlayer.Text = "Player 2";
                        GameStatus.PlayCount++;
                        btn.Tag = "O";
                        CheckWinner();
                        break;
                    case enPlayer.Player2:
                        btn.Image = Properties.Resources.X;
                        PlayerTurn = enPlayer.Player1;
                        lblPlayer.Text = "Player 1";
                        GameStatus.PlayCount++;
                        btn.Tag = "X";
                        CheckWinner();
                        break;
                }
            }
            else
            {
                MessageBox.Show("Wrong Choice", "Wrong", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            if(GameStatus.PlayCount == 9)
            {
                GameStatus.GameOver = true;
                GameStatus.Winner = enWinner.Draw;
                EndGame();
            }
        }        

        private void button2_Click(object sender, EventArgs e)
        {
            ChangeImage(button2);
        }

        private void button3_Click(object sender, EventArgs e)
        {

            ChangeImage(button3);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ChangeImage(button4);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ChangeImage(button5);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ChangeImage(button6);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ChangeImage(button7);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ChangeImage(button8);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            ChangeImage(button9);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            ChangeImage(button10);
        }

        private void RestButton(Button btn)
        {
            btn.Image = Properties.Resources.question_mark_96;
            btn.Tag = "?";
            btn.BackColor = Color.Transparent;
        }

        private void RestartGame()
        {
            RestButton(button2);
            RestButton(button3);
            RestButton(button4);
            RestButton(button5);
            RestButton(button6);
            RestButton(button7);
            RestButton(button8);
            RestButton(button9);
            RestButton(button10);

            PlayerTurn = enPlayer.Player1;
            lblPlayer.Text = "Player 1";
            GameStatus.PlayCount = 0;
            GameStatus.GameOver = false;
            GameStatus.Winner = enWinner.GameInProgress;
            lblProgress.Text = "In Progress";
        }

        private void btnRestartGame_Click(object sender, EventArgs e)
        {
            RestartGame();
        }
    }
}

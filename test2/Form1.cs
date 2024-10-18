using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Color Red = Color.FromName("red");

            Pen RedPen = new Pen(Red, 3);

            RedPen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            RedPen.EndCap = System.Drawing.Drawing2D.LineCap.Round;

            e.Graphics.DrawLine(RedPen, 300, 50, 800, 50);
            e.Graphics.DrawLine(RedPen, 300, 200, 800, 200);
            e.Graphics.DrawLine(RedPen, 300, 350, 800, 350);
            e.Graphics.DrawLine(RedPen, 300, 500, 800, 500);

            e.Graphics.DrawLine(RedPen, 450, 50, 450, 500);
            e.Graphics.DrawLine(RedPen, 650, 50, 650, 500);
        }

        enum enPlayer { Player1, Player2 }

        enPlayer PlayerTurn = enPlayer.Player1;

        enum enWinner { Player1, player2, Draw, GameInProgress }

        struct stGameStatus
        {
            public enWinner winner;
            public bool GameOver;
            public short PlayCount;
        }
        stGameStatus GameStatus;
        
        void EndGame()
        {
            lblTurn.Text = "Game Over";

            switch (GameStatus.winner)
            {
                case enWinner.Player1:
                    lblWinner.Text = "Player 1";
                break;

                case enWinner.player2:
                    lblWinner.Text = "Player 2";
                break;

                default:
                    lblWinner.Text = "Draw";
                break;
            }
            MessageBox.Show("Game Over", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        public bool CheckValue(Button btn1, Button btn2, Button btn3)
        {
            if (btn1.Tag.ToString() != "?" && btn1.Tag.ToString() == btn2.Tag.ToString() && btn1.Tag.ToString() == btn3.Tag.ToString())
            {
                btn1.BackColor = Color.IndianRed;
                btn2.BackColor = Color.IndianRed;
                btn3.BackColor = Color.IndianRed;

                if (btn1.Tag.ToString() == "X")
                {
                    GameStatus.winner = enWinner.Player1;
                    GameStatus.GameOver = true;
                    EndGame();
                    return true;
                }
                else
                {
                    GameStatus.winner = enWinner.player2;
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
            //Rows
            if (CheckValue(button1, button2, button3))
                return;
            if (CheckValue(button4, button5, button6))
                return;
            if (CheckValue(button7, button8, button9))
                return;

            //Columns
            if (CheckValue(button1, button4, button7))
                return;
            if (CheckValue(button2, button5, button8))
                return;
            if (CheckValue(button3, button6, button9))
                return;

            //Diagonals
            if (CheckValue(button1, button5, button9))
                return;
            if (CheckValue(button3, button5, button7))
                return;
        }
        
        public void ChangeImage(Button btn)
        {
           if(btn.Tag.ToString() == "?")
            {
                switch (PlayerTurn)
                {
                    case enPlayer.Player1:
                        btn.Image = Properties.Resources.X;
                        PlayerTurn = enPlayer.Player2;
                        lblTurn.Text = "Player 2";
                        GameStatus.PlayCount++;
                        btn.Tag = "X";
                        CheckWinner();
                        break;
                    case enPlayer.Player2:
                        btn.Image = Properties.Resources.O;
                        PlayerTurn = enPlayer.Player1;
                        lblTurn.Text = "Player 1";
                        GameStatus.PlayCount++;
                        btn.Tag = "O";
                        CheckWinner();
                        break;
                }
            }
            else
            {
                MessageBox.Show("Wrong Choice","Wrong",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

           if (GameStatus.PlayCount == 9 && !GameStatus.GameOver)
            {
                GameStatus.GameOver = true;
                GameStatus.winner = enWinner.Draw;               
                EndGame();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ChangeImage(button1);
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

        private void RestButton(Button btn)
        {
            btn.Image = Properties.Resources.question_mark_96;
            btn.Tag = "?";
            btn.BackColor = Color.Transparent;
        }
        private void RestartGame()
        {
            RestButton(button1);
            RestButton(button2);
            RestButton(button3);
            RestButton(button4);
            RestButton(button5);
            RestButton(button6);
            RestButton(button7);
            RestButton(button8);
            RestButton(button9);

            PlayerTurn = enPlayer.Player1;
            lblTurn.Text = "Player 1";
            GameStatus.PlayCount = 0;
            GameStatus.GameOver = false;
            GameStatus.winner = enWinner.GameInProgress;
            lblWinner.Text = "In Progress";
        }
        private void button10_Click(object sender, EventArgs e)
        {
            RestartGame();
        }
    }
}

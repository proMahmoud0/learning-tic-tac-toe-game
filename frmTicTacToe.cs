using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tic_Tac_Toe_Game
{
    public partial class frmTicTacToe : Form
    {
        public frmTicTacToe()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Color White = Color.FromArgb(255, 255, 255, 255);
            Pen Pen = new Pen(White);
            Pen.Width = 15;

            //Pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            Pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            Pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;

            e.Graphics.DrawLine(Pen, 400, 300, 1050, 300); // left line
            e.Graphics.DrawLine(Pen, 400, 460, 1050, 460); // right line

            e.Graphics.DrawLine(Pen, 610, 140, 610, 620); // Top line
            e.Graphics.DrawLine(Pen, 840, 140, 840, 620); // Bottom line

        }

        private void GameButtons_Click(object sender, EventArgs e)
        {
            if (GameStatus.GameOver)
            {
                MessageBox.Show("The game has ended, press restart to play again.", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ChangeImage((Button)sender);
        }

        // old code (Long method)
        /*
        private void button1_Click(object sender, EventArgs e)
        {
            if (GameStatus.GameOver)
            {
                MessageBox.Show("The game has ended, press restart to play again.", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
                
            ChangeImage(button1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (GameStatus.GameOver)
            {
                MessageBox.Show("The game has ended, press restart to play again.", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            ChangeImage(button2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (GameStatus.GameOver)
            {
                MessageBox.Show("The game has ended, press restart to play again.", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            ChangeImage(button3);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (GameStatus.GameOver)
            {
                MessageBox.Show("The game has ended, press restart to play again.", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            ChangeImage(button4);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (GameStatus.GameOver)
            {
                MessageBox.Show("The game has ended, press restart to play again.", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            ChangeImage(button5);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (GameStatus.GameOver)
            {
                MessageBox.Show("The game has ended, press restart to play again.", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            ChangeImage(button6);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (GameStatus.GameOver)
            {
                MessageBox.Show("The game has ended, press restart to play again.", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            ChangeImage(button7);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (GameStatus.GameOver)
            {
                MessageBox.Show("The game has ended, press restart to play again.", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            ChangeImage(button8);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (GameStatus.GameOver)
            {
                MessageBox.Show("The game has ended, press restart to play again.", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            ChangeImage(button9);
        }
        */

        struct stGameStatus
        {
            public enWinner Winner;
            public bool GameOver;
            public short PlayCount;
        }

        stGameStatus GameStatus;

        private enum enPlayer { Player1, Player2 };
        private enum enWinner { Player1, Player2, Draw, InProgress };

        private enPlayer PlayerTurn = enPlayer.Player1;

        private void EndGame()
        {
            lblTurn.Text = "Game Over";
            switch  (GameStatus.Winner)
            {
                case enWinner.Player1:
                    lblWinner.Text = "Player 1";
                    break;
                case enWinner.Player2:
                    lblWinner.Text = "Player 2";
                    break;
                default:
                    lblWinner.Text = "Draw";
                    break;
            }

            MessageBox.Show("Game Over!", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        public bool CheckValues(Button btn1, Button btn2, Button btn3)
        {
            if (btn1.Tag.ToString() != "?" && btn1.Tag.ToString() == btn2.Tag.ToString() && btn1.Tag.ToString() == btn3.Tag.ToString())
            {

                btn1.BackColor = Color.FromArgb(255, 232, 60, 52);
                btn2.BackColor = Color.FromArgb(255, 232, 60, 52);
                btn3.BackColor = Color.FromArgb(255, 232, 60, 52);

                if (btn1.Tag.ToString() == "X")
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
            // Checked rows
            // Check Row 1
            if (CheckValues(button1, button2, button3))
                return;

            // Check Row 2
            if (CheckValues(button4, button5, button6))
                return;

            // Check Row 3
            if (CheckValues(button7, button8, button9))
                return;

            // Checked columns
            // Check Column 1
            if (CheckValues(button1, button4, button7))
                return;

            // Check Column 2
            if (CheckValues(button2, button5, button8))
                return;

            // Check Column 3
            if (CheckValues(button3, button6, button9))
                return;

            // Checked Diagonals
            // Check Diagonal 1
            if (CheckValues(button1, button5, button9))
                return;

            // Check Diagonal 2
            if (CheckValues(button3, button5, button7))
                return;
        }

        private void ChangeImage(Button btn)
        {
            if (btn.Tag.ToString() == "?")
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
                MessageBox.Show("Wrong Choice", "Wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (GameStatus.PlayCount == 9)
            {
                GameStatus.GameOver = true;
                GameStatus.Winner = enWinner.Draw;
                EndGame();
            }
        }

        private void RestButton(Button btn)
        {
            btn.Image = null;
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
            GameStatus.Winner = enWinner.InProgress;
            lblWinner.Text = "In Progress";
        }

        private void btnRestartGame_Click(object sender, EventArgs e)
        {
            RestartGame();
        }
    }
}

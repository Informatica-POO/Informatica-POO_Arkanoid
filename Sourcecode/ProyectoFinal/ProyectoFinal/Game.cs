using System;
using System.Windows.Forms;

namespace ProyectoFinal
{
    public partial class Game : Form
    {
        public Game()
        {
            InitializeComponent();
        }

        int ball_x = 4;
        int ball_y = 4;
        int score = 0;

        private void Game_over()
        {
            if (score > 17)
            {
                timer1.Stop();
                MessageBox.Show("You Wins..");
            }

            if (ball.Top + ball.Height > ClientSize.Height)
            {
                timer1.Stop();
                MessageBox.Show("Game-Over");
            }
        }
        
        private void Get_Score()
        {
            foreach(Control x in this.Controls)
            {
                if(x is PictureBox &&x.Tag=="block")
                {
                    if(ball.Bounds.IntersectsWith(x.Bounds))
                    {
                        Controls.Remove(x);
                        ball_y = -ball_y;
                        score++;
                        lbl_score.Text = "Score :" + score;
                    }
                }
            }
        }

        private void Ball_Movment()
        {

            ball.Left += ball_x;
            ball.Top += ball_y;
            if (ball.Left + ball.Width > ClientSize.Width || ball.Left < 0)
            {
                ball_x = -ball_x;
            }

            if (ball.Top < 0 || ball.Bounds.IntersectsWith(Player.Bounds))
            {
                ball_y = -ball_y;
            }
        }

        private void Game_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left && Player.Left > 0)
            {
                Player.Left -= 6;
            }

            if (e.KeyCode == Keys.Right && Player.Right < 410)
            {
                Player.Left += 6;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            Ball_Movment();
            Get_Score();
            Game_over();
        }
    }
}
            
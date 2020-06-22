using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ProyectoFinal
{
    public partial class Game : Form
    {
        Player u ;
    
        public Game(Player p)
        {
            InitializeComponent();
            u = p ;
            
            
        }

        int ball_x = 4;
        int ball_y = 4;
        int Puntuacion = 0;

        private void Game_over()
        {
            if (Puntuacion >= 36)
            {
                timer1.Stop();
                MessageBox.Show("Has Ganado");
                AddScore();
                
            }

            if (ball.Top + ball.Height > ClientSize.Height)
            {
                u.Lives--;
                timer1.Stop();
                if (u.Lives > 0)
                {
                    MessageBox.Show("Reiniciar");
                }

                if (u.Lives == 0)
                {
                    MessageBox.Show("Fin del juego");

                    this.Close();
                    AddScore();

                }

                ball.Left = 190;
                ball.Top = 310;
                ball_x = -4;
                ball_y = -4;
                Player.Left = 170;
                timer1.Start();
                
            }
        }


        private void AddScore()
        {
            DataTable dt = SQL.query($"SELECT *FROM PLAYER ");

            bool Exist = false;

            foreach (DataRow row in dt.Rows)
            {
                if (row[0].ToString().Equals(u.Username1))
                {
                    if (u.Score1 > (Convert.ToInt32(row[1].ToString())))
                    {
                        Exist = true;
                    }
                }
            }

            if (Exist)
            {
                string sql = $"UPDATE PLAYER SET score = {u.Score1} WHERE player = '{u.Username1}'";
                SQL.nonquery(sql);
            }

            else
            {
                string sql2 = $"INSERT INTO PLAYER(player,score) VALUES('{u.Username1}',{u.Score1}) ";
                SQL.nonquery(sql2);
            }
        }
        
        private void Get_Score()
        {
            foreach(Control x in this.Controls)
            {
                if(x is PictureBox &&x.Tag=="block1")
                {
                    if(ball.Bounds.IntersectsWith(x.Bounds))
                    {
                        Controls.Remove(x);
                        ball_y = -ball_y;
                        Puntuacion++;
                        lbl_puntuacion.Text = "Puntuacion :" + Puntuacion;
                    }
                }
                if (x is PictureBox && x.Tag == "block2")
                {
                    if (ball.Bounds.IntersectsWith(x.Bounds))
                    {
                        ball_y = -ball_y;
                        x.Tag = "block1";
                        x.BackColor = Color.Lime;
                        Puntuacion++;
                    }
                }
                if (x is PictureBox && x.Tag == "block3")
                {
                    if (ball.Bounds.IntersectsWith(x.Bounds))
                    {
                        ball_y = -ball_y;
                        x.Tag = "block2";
                        x.BackColor = Color.Fuchsia;
                        Puntuacion ++;
                    }
                }

                u.Score1 = Puntuacion;
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
            lblLives.Text = u.Lives.ToString();
            Ball_Movment();
            Get_Score();
            Game_over();
        }
        
        
    }
}
            
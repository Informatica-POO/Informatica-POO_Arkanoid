using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinal
{
  public partial class Form1 : Form
  {
      private Player p;
      public Form1()
      {
          InitializeComponent();
          
      }


      private void btnIniciar_Click(object sender, EventArgs e)
        {
            p = new Player(txtUsuario.Text);
            Game window = new Game(p);
            window.Show();
        }

      private void btnTop_Click(object sender, EventArgs e)
      {
          Top10 window2 = new Top10();
          window2.Show();
      }
  }
}
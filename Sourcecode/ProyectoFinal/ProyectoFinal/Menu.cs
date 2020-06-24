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
          // Hace una comparacion para ver si esta en blanco el usuario
          if (txtUsuario.Text.Equals(""))
          {
              MessageBox.Show("Ingrese un usuario válido");
          }
          else
          {
              // Se crea un instancia del objeto player con los datos que proporcionó el usuario e inicia el juego
              p = new Player(txtUsuario.Text);
              Game window = new Game(p);
              window.Show();

          } 
      }

      private void btnTop_Click(object sender, EventArgs e)
      {
          //Se inicia la ventana del top 10
          Top10 window2 = new Top10();
          window2.Show();
      }
  }
}
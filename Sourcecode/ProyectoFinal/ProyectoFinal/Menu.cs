﻿using System;
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

      public Form1()
      {
          InitializeComponent();
      }


      private void btnIniciar_Click(object sender, EventArgs e)
        {
            Player player = new Player(txtUsuario.Text,0);
            Game window = new Game();
            window.Show();
        }

      private void btnTop_Click(object sender, EventArgs e)
      {
          Top10 window2 = new Top10();
          window2.Show();
      }
  }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ProyectoFinal
{
    public partial class Top10 : Form
    {
        private Player p;

        public Top10()
        {
            InitializeComponent();
            cargar();
           
        }
        
        private void cargar()
        {
            // Se carga el top 10 a una tabla y se muestra
            try
            {
                var dt = SQL.query("SELECT player, score FROM player ORDER BY score DESC LIMIT 10;");
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = dt;    

            }
            catch (Exception )
            {
                MessageBox.Show("Error!");
            }



        }


    }
}
using System.Windows.Forms;

namespace ProyectoFinal
{
    public partial class Top10 : Form
    {
        private Player p;

        public Top10()
        {
            InitializeComponent();
           
        }

        public Top10(Player jPlayer)
        {
            p = jPlayer;
            cargar();
        }
        

        private void cargar()
        {
            var dt = SQL.query($"SELECT FROM TOP" +
                               $"WHERE player= '{p.Username.ToString()}");
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = dt;
        }
    }
}
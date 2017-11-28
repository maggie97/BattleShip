using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BattleShip_Game
{
    public partial class Menu2 : Form
    {
        public string name;
        public Menu2()
        {
            InitializeComponent();
        }

        private void Jugar_Click(object sender, EventArgs e)
        {
            name = Player.Text;
            Client c = new Client(name);
            c.IntentaConexion();
            //Form1 f = new Form1(name);
            //this.Close();
           // f.Visible = true;
            this.Visible = false;
        }
    }
}

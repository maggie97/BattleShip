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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Jugar_MouseClick(object sender, MouseEventArgs e)
        {
            Menu2 m = new Menu2();
            //this.Close();
            m.Visible = true;
            this.Visible = false;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace BattleShips
{
    public partial class Menu : Form
    {
        SoundPlayer player;
        string n;
        Form1 f;
        public Menu()
        {
            InitializeComponent();
            music();
        }

        private void music()
        {
            player = new SoundPlayer(@"Musica\Mar.wav");
            player.Play();
        }

        private void btnJugar_Click(object sender, EventArgs e)
        {
            n = txtName.Text;
            f = new Form1(n);
            f.Visible = true;
            this.Visible = false;
            player.Stop();
        }
    }
}

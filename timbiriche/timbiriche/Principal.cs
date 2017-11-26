using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace timbiriche
{
    public partial class Principal : Form
    {
        string nombre;
        string color;
        Form1 f;
        public Principal()
        {
            InitializeComponent();
        }

        private void buttonJugar_Click(object sender, EventArgs e)
        {
            nombre = txtName.Text;
            color = Colors.Text;
            f = new Form1();
            f.Visible = true;
            this.Visible = false;
        }
    }
}

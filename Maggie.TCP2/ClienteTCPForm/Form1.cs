using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClienteTCPForm
{
    public partial class Form1 : Form
    {
        string name;
        public Form1()
        {
            InitializeComponent();
            Text = "Cliente";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            name = txtNombre.Text;
            this.Visible = false;
            Juego nuevo = new Juego(name);
            nuevo.IntentaConexion();
            nuevo.Visible = true;
            
        }
    }
}

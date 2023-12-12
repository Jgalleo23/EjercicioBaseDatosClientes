using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaseDatos
{
    public partial class Formulario : Form
    {
        public Formulario()
        {
            InitializeComponent();
            this.Size = new Size(620, 170);
            txtFecha.Text = DateTime.Now.ToString("yyyy/M/d");
        }

        private void btRellenar_Click(object sender, EventArgs e)
        {
            this.Size = new Size(620, 400);
        }
    }
}

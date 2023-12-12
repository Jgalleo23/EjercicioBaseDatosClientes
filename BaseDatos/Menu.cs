using MySql.Data.MySqlClient;
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
    public partial class formMenu : Form
    {
        public MySqlCommand Comando { get; private set; }
        public MySqlDataReader Lector { get; private set; }

        public MySqlConnection connection;
        public formMenu()
        {
            InitializeComponent();
            timer1.Start();
        }

        public void VerTabla()
        {
            string Consulta = "SELECT * FROM presupuestos"; // Declaración de la consulta

            using (MySqlConnection conn = new MySqlConnection($"server={Login.HOST};user id={Login.ID};password={Login.PASSWORD};database=clientes;persistsecurityinfo=True"))
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(Consulta, conn))
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    presupuestosDataGridView.DataSource = ds.Tables[0];
                }
            }
        }

        private void presupuestosBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.presupuestosBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.clientesDataSet);

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'clientesDataSet.presupuestos' Puede moverla o quitarla según sea necesario.
            this.presupuestosTableAdapter.Fill(this.clientesDataSet.presupuestos);

        }

        private void btAnadir_Click(object sender, EventArgs e)
        {

        }

        private void añadirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Formulario form3 = new Formulario();
            form3.ShowDialog();

            string COD_PRESUPUESTO = form3.txtCodFact.Text;
            string COD_ARTICULO = form3.txtCodArt.Text;
            string DESCRIPCION = form3.txtDescripcion.Text;
            string CANTIDAD = form3.txtCantidad.Text;
            string PRECIO = form3.txtPrecio.Text;
            string DATE = form3.txtFecha.Text;

            if (form3.DialogResult == DialogResult.OK)
            {


                string Consulta = $"INSERT INTO lineas (COD_PRESUPUESTO, COD_ARTICULO, DESCRIPCION, CANTIDAD, PRECIO) VALUES ('{COD_PRESUPUESTO}', '{COD_ARTICULO}', '{DESCRIPCION}', '{CANTIDAD}', '{PRECIO}')"; // Declaración de la consulta
                string Consulta2 = $"INSERT INTO presupuestos (COD, FECHA, TOTAL) VALUES ((SELECT COD_PRESUPUESTO FROM lineas WHERE COD_PRESUPUESTO = '{COD_PRESUPUESTO}'), ('{DATE}'), (SELECT (CANTIDAD * PRECIO) AS TOTAL FROM lineas WHERE COD_PRESUPUESTO = '{COD_PRESUPUESTO}'))"; // Declaración de la consulta

                connection = new MySqlConnection($"server={Login.HOST};user id={Login.ID};password={Login.PASSWORD};database=clientes;persistsecurityinfo=True");
                connection.Open();
                MySqlCommand comando = new MySqlCommand(Consulta, connection);
                MySqlCommand comando2 = new MySqlCommand(Consulta2, connection);

                comando.ExecuteNonQuery();
                comando2.ExecuteNonQuery();

                connection.Close();
                VerTabla();
            }
        }
    }
}

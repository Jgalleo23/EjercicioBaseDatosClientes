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

    public partial class Login : Form
    {
        public static string HOST = "localhost";
        public static string ID = "root";
        public static string PASSWORD = "root";


        public MySqlCommand Comando { get; private set; }
        public MySqlDataReader Lector { get; private set; }

        public MySqlConnection connection;
        public Login()
        {
            InitializeComponent();
            txtHost.Text = HOST;
            txtID.Text = ID;
            txtPassword.Text = PASSWORD;
        }

        private void btLogin_Click(object sender, EventArgs e)
        {
            
            HOST = txtHost.Text;
            ID = txtID.Text;
            PASSWORD = txtPassword.Text;

            string CadenaConexion = $"server={HOST};user id={ID};password={PASSWORD};database=clientes;persistsecurityinfo=True";

            try
            {
                formMenu form2 = new formMenu();
                
                string Consulta = "SELECT * FROM presupuestos"; // Declaración de la consulta

                    using (MySqlConnection conn = new MySqlConnection(CadenaConexion))
                    {
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(Consulta, conn))
                        {
                            DataSet ds = new DataSet();
                            adapter.Fill(ds);
                            form2.presupuestosDataGridView.DataSource = ds.Tables[0];
                        }
                    }
                
                form2.Show();
                this.Hide();
            }
            catch
            {
                MessageBox.Show(CadenaConexion);
            }
        }
    }
}

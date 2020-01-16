using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OracleClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoOracle
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }


        OracleConnection conexion = new OracleConnection("DATA SOURCE = CODINGRAPH ; PASSWORD = 123 ; USER ID = tester");
        private void btnLogin_Click(object sender, EventArgs e)
        {

            conexion.Open();
            OracleCommand comando = new OracleCommand("SELECT * FROM PERSONA WHERE USUARIO = :usuario AND CLAVE = :contra", conexion);

            comando.Parameters.AddWithValue(":usuario", txtUsuario.Text);
            comando.Parameters.AddWithValue(":contra", txtContrasena.Text);

            OracleDataReader lector = comando.ExecuteReader();


            if (lector.Read())
            {
                Form1 formulario = new Form1();
                conexion.Close();
                formulario.Show();

            }
            else
            {
                MessageBox.Show("No se pudo ingresar");
            }


        }

       

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}

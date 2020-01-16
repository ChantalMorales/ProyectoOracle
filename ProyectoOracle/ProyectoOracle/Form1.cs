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
    public partial class Form1 : Form
    {
        OracleConnection ora = new OracleConnection("DATA SOURCE = CODINGRAPH ; PASSWORD=123;USER ID = proy;");

        public Form1()
        {
            InitializeComponent();
        }

        private void btnConectar_Click(object sender, EventArgs e)
        {
            

            ora.Open();
            MessageBox.Show("Conectado");
            ora.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            ora.Open();
            OracleCommand comando = new OracleCommand("seleccionarPersonas",ora);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.Add("registros",OracleType.Cursor).Direction=ParameterDirection.Output;

            OracleDataAdapter adaptador = new OracleDataAdapter();
            adaptador.SelectCommand = comando;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            dgvPersonas.DataSource = tabla;

            ora.Close();

        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {

        }

        private void btnInsertar_Click_1(object sender, EventArgs e)
        {
            ora.Open();
            OracleCommand comando = new OracleCommand("insertar", ora);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.Add("nom", OracleType.VarChar).Value = txtNombre.Text;
            comando.Parameters.Add("cont", OracleType.VarChar).Value = txtContrasena.Text;
            comando.ExecuteNonQuery();
            MessageBox.Show("Persona insertada");
            ora.Close();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ora.Open();
            OracleCommand comando = new OracleCommand("actualizar", ora);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.Add("idp", OracleType.Number).Value = Convert.ToInt32( txtId.Text);
            comando.Parameters.Add("nom", OracleType.VarChar).Value = txtNombre.Text;
            comando.Parameters.Add("cont", OracleType.VarChar).Value = txtContrasena.Text;
            comando.ExecuteNonQuery();
            MessageBox.Show("Persona actualizada");
            ora.Close();
        }

        private void Eliminar_Click(object sender, EventArgs e)
        {
            ora.Open();
            OracleCommand comando = new OracleCommand("eliminar", ora);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.Add("idp", OracleType.Number).Value = Convert.ToInt32(txtId.Text);
            comando.ExecuteNonQuery();
            MessageBox.Show("Eliminado");
            ora.Close();
        }
    }
}

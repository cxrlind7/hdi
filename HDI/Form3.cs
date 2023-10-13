using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HDI
{
    public partial class Form3 : Form
    {
        bool camposCompletos = false;

        public Form3(Reporte reporte)
        {
            InitializeComponent();
            string[] opciones = { "Asegurado", "Acompañante", "Familiar" };
            comboBox1.Items.AddRange(opciones);
            button1.Enabled = camposCompletos;
            textBox8.Text = reporte.nombreAjustador;
            textBox7.Text = reporte.numeroPoliza;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Reporte reporte = ObtenerReporte();
                string constring = @"Data Source=DESKTOP-4IRJCK4\SQLEXPRESS;Initial Catalog=ejemplo;Integrated Security=True;";
                using (SqlConnection connection = new SqlConnection(constring))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_InsertReporte", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@nombreAjustador", reporte.nombreAjustador);
                        cmd.Parameters.AddWithValue("@numeroPoliza", reporte.numeroPoliza);
                        cmd.Parameters.AddWithValue("@lugarOcurrencia", reporte.lugarOcurrencia);
                        cmd.Parameters.AddWithValue("@nombreReporta", reporte.nombreReporta);
                        cmd.Parameters.AddWithValue("@telefonoContacto", reporte.telefonoContacto);
                        cmd.Parameters.AddWithValue("@correoContacto", reporte.correoContacto);
                        cmd.Parameters.AddWithValue("@placas", reporte.placas);
                        cmd.Parameters.AddWithValue("@color", reporte.color);
                        cmd.Parameters.AddWithValue("@descripcionSiniestro", reporte.descripcionSiniestro);
                        cmd.Parameters.AddWithValue("@observaciones", reporte.observaciones);
                        cmd.Parameters.AddWithValue("@relacionAsegurado", reporte.relacionAsegurado);

                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Inserción correcta", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar en la base de datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public Reporte ObtenerReporte()
        {
            Reporte reporte = new Reporte();
            reporte.nombreAjustador = textBox8.Text;
            reporte.numeroPoliza = textBox7.Text;
            reporte.lugarOcurrencia = textBox1.Text;
            reporte.nombreReporta = textBox2.Text;
            reporte.telefonoContacto = textBox3.Text;
            reporte.correoContacto = textBox4.Text;
            reporte.placas = textBox5.Text;
            reporte.color = textBox6.Text;
            reporte.descripcionSiniestro = richTextBox1.Text;
            reporte.observaciones = richTextBox2.Text;
            reporte.relacionAsegurado = comboBox1.Text;
            return reporte;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            camposCompletos = VerificarCamposCompletos();
            button1.Enabled = camposCompletos;
        }

        private bool VerificarCamposCompletos()
        {
            bool camposCompletos = true; // Inicialmente suponemos que todos los campos están completos

            // Verificar TextBox
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text) || string.IsNullOrWhiteSpace(textBox4.Text) ||
                string.IsNullOrWhiteSpace(textBox5.Text) || string.IsNullOrWhiteSpace(textBox6.Text) ||
                string.IsNullOrWhiteSpace(textBox7.Text) || string.IsNullOrWhiteSpace(textBox8.Text))
            {
                camposCompletos = false;
            }

            // Verificar ComboBox
            if (comboBox1.SelectedIndex == -1)
            {
                camposCompletos = false;
            }

            // Verificar RichTextBox
            if (string.IsNullOrWhiteSpace(richTextBox1.Text) || string.IsNullOrWhiteSpace(richTextBox2.Text))
            {
                camposCompletos = false;
            }

            // Habilita o deshabilita el botón según el estado de camposCompletos
            button1.Enabled = camposCompletos;

            return camposCompletos;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            camposCompletos = VerificarCamposCompletos();
            button1.Enabled = camposCompletos;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            camposCompletos = VerificarCamposCompletos();
            button1.Enabled = camposCompletos;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            camposCompletos = VerificarCamposCompletos();
            button1.Enabled = camposCompletos;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            camposCompletos = VerificarCamposCompletos();
            button1.Enabled = camposCompletos;
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            camposCompletos = VerificarCamposCompletos();
            button1.Enabled = camposCompletos;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            camposCompletos = VerificarCamposCompletos();
            button1.Enabled = camposCompletos;
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            camposCompletos = VerificarCamposCompletos();
            button1.Enabled = camposCompletos;
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            camposCompletos = VerificarCamposCompletos();
            button1.Enabled = camposCompletos;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            camposCompletos = VerificarCamposCompletos();
            button1.Enabled = camposCompletos;
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {
            camposCompletos = VerificarCamposCompletos();
            button1.Enabled = camposCompletos;
        }
    }
}

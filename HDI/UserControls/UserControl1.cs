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


namespace HDI.UserControls
{
    public partial class UserControl1 : UserControl
    {
        private DataTable dt;
        public UserControl1()
        {
            InitializeComponent();
            BindGrid();
        }

        private void BindGrid()
        {
            string constring = System.Configuration.ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString; using (SqlConnection con = new SqlConnection(constring))
            {
                using (SqlCommand cmd = new SqlCommand("sp_GetData", con))  // Reemplaza 'NombreDeTuStoredProcedure' por el nombre real de tu procedimiento almacenado
                {
                    cmd.CommandType = CommandType.StoredProcedure;  // Indica que estás utilizando un procedimiento almacenado
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                            dt = new DataTable("poliza");
                            sda.Fill(dt);
                            dataGridView1.DataSource = dt;
                    }
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataView dv = dt.DefaultView;
            dv.RowFilter = string.Format("Poliza like '%{0}%' OR [Nombre asegurado] like '%{0}%'", textBox1.Text);
            dataGridView1.DataSource = dv.ToTable();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Reporte reporte = new Reporte();
            if (dataGridView1.SelectedRows.Count > 0)
            {                
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                reporte.nombreAjustador= Form1.instance.lbl2.Text;
                reporte.numeroPoliza=selectedRow.Cells[2].Value.ToString();
            }


            Form3 agregar = new Form3(reporte);
            agregar.StartPosition = FormStartPosition.CenterScreen;
            agregar.ShowDialog();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            button1.Visible = (dataGridView1.SelectedRows.Count > 0);
        }
    }
}
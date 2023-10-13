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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace HDI.UserControls
{
    public partial class UserControl2 : UserControl
    {
        private DataTable dt;
        public UserControl2()
        {
            InitializeComponent();
            BindGrid();
        }

        private void BindGrid()
        {
            string constring = System.Configuration.ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;

            using (SqlConnection con = new SqlConnection(constring))
            {
                using (SqlCommand cmd = new SqlCommand("sp_GetDataReportes", con))  
                {
                    cmd.CommandType = CommandType.StoredProcedure;  
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        dt = new DataTable("reporte");
                        sda.Fill(dt);
                        dataGridView1.DataSource = dt;
                        dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    }
                }
            }
        }


        private void label3_MouseClick(object sender, MouseEventArgs e)
        {
            BindGrid();
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            DataView dv = dt.DefaultView;
            dv.RowFilter = string.Format("[Numero Poliza] like '%{0}%'", textBox1.Text);
            dataGridView1.DataSource = dv.ToTable();
        }
    }
}

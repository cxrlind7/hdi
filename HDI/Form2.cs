using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HDI
{
    public partial class Form2 : Form
    {
        public static Form2 instance;
        public TextBox tb1, tb2;
        
        public Form2()
        {
            InitializeComponent();
            textBox2.UseSystemPasswordChar = true;
            instance = this;
            tb1 = textBox1;
            tb2 = textBox2;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {            
            if (tb1.Text == "Jueves" && tb2.Text== "123")
            {
                this.Close();
                Form1.instance.lbl2.Text = tb1.Text;
            }
            else
            {
                MessageBox.Show("Usuario o contraseña inválidos.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}

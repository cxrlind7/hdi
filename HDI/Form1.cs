using HDI.UserControls;
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
    public partial class Form1 : Form
    {
        NavigationControl navigationControl;
        public static Form1 instance;
        public Label lbl2;
        public Form1()
        {
            InitializeComponent();
            instance = this;
            instance.StartPosition = FormStartPosition.CenterScreen;
            lbl2 = label2;
            InitializeNavigationControl();
            Form2 login = new Form2();
            login.StartPosition = FormStartPosition.CenterScreen;
            login.ShowDialog();
        }
        
        private void InitializeNavigationControl()
        {

            userControl11.BringToFront();
            btnHome.BackColor = Color.FromArgb(0, 123, 49);
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            userControl11.BringToFront();   
            btnHome.BackColor = Color.FromArgb(0, 123, 49);
            btnAgregar.BackColor = Color.FromArgb(0, 103, 41);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            userControl21.BringToFront();
            btnAgregar.BackColor = Color.FromArgb(0, 123, 49);
            btnHome.BackColor = Color.FromArgb(0, 103, 41);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

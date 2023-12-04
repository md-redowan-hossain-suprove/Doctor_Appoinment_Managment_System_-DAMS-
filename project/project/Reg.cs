using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project
{
    public partial class Reg : Form
    {
        public Reg()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedItem.ToString()=="Patient")
            { 
                Pat_Reg pr = new Pat_Reg();
                this.Hide();
                pr.Show();
            }
            else if(comboBox1.SelectedItem.ToString() == "Employee")
            {
                Emp_Reg er = new Emp_Reg();
                this.Hide();
                er.Show();
            }
        }

        private void F_Form_Click(object sender, EventArgs e)
        {
            Log_In reg = new Log_In();
            this.Hide();
            reg.Show();
        }

        private void Close_button_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

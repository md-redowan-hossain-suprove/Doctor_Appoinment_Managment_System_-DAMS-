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
    public partial class Pat_Home : Form
    {
        public Pat_Home()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Pat_Profile pp = new Pat_Profile();
            this.Hide();
            pp.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Appoinment Successful","Information",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Log_In log_In = new Log_In();
            log_In.Show();
            this.Hide();
        }

        private void Close_button_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox5_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

        }
    }
}
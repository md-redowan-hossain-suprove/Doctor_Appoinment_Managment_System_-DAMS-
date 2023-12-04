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

namespace project
{
    public partial class Log_In : Form
    {

        public static string L1;

        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-BVL115R7\SQLEXPRESS;Initial Catalog=DAMS;Integrated Security=True");


        public Log_In()
        {
            InitializeComponent();
        }

        private void button_reg_Click(object sender, EventArgs e)
        {
            Reg reg = new Reg();    
            this.Hide();
            reg.Show();
        }

        private void button_LogIn_Click(object sender, EventArgs e)
        {
            if (id_textBox1.Text != null && Pass_textBox.Text != null)
            {
                L1 = id_textBox1.Text;

                try
                {


                    //SqlCommand cmd = new SqlCommand("select * from Log_In where Email_ID='" + id_textBox1.Text + "'and Password='" + Pass_textBox.Text + "'and usertype = '" + Catagory_comboBox.Items + "'", con);

                    SqlCommand cmd = new SqlCommand("select * from Log_In where Email_ID='" + L1 + "'and Password='" + Pass_textBox.Text + "'", con);
                    // SqlCommand cmd = new SqlCommand(@"select * from login where id = '"+id_textBox1.Text+"' and pass = '" +Pass_textBox.Text+ "'and usertype = '"+Catagory_comboBox.Text+"'", con);
                    con.Open();

                    SqlDataReader Type = cmd.ExecuteReader();

                    if (Type.HasRows == true)
                    {
                        Type.Read();
                        if (Type[2].ToString() == "Patient")
                        {
                            Pat_Home customerHome = new Pat_Home();
                            customerHome.Show();
                            this.Hide();
                        }
                        else if (Type[2].ToString() == "Employee")
                        {
                            Emp_Home empHome = new Emp_Home();
                            empHome.Show();
                            this.Hide();
                        }
                        else if (Type[2].ToString() == "admin")
                        {
                            Admin_Home ad = new Admin_Home();
                            ad.Show();
                            this.Hide();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid Password or User Name. \n Try Again!! ", "Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    }
                    // Pass_textBox.Focus();
                    // return;
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                Pass_textBox.UseSystemPasswordChar = false;
            }

            else
            {
                Pass_textBox.UseSystemPasswordChar = true;
            }
        }

        private void button_fp_Click(object sender, EventArgs e)
        {
            Forget_pass fr = new Forget_pass();
            fr.Show();
            this.Hide();
        }

        private void Close_button_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

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
    public partial class Emp_Reg : Form
    {


        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-BVL115R7\SQLEXPRESS;Initial Catalog=DAMS;Integrated Security=True");



        public Emp_Reg()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txt_firstname.Text != null && txt_lastname.Text != null && Gender_emp.Text != null && dateTimePicker1.Text != null && edu.Text != null && ex.Text != null && number.Text != null && txt_gmail.Text != null && Pass.Text != null)
            {
                try
                {
                    Random rnd = new Random();
                    int rndnum = rnd.Next(99999999);
                    con.Open();
                    SqlCommand cmd = new SqlCommand(@"INSERT INTO [dbo].[Emp_Reg]
           ([First_name]
           ,[Last_Name]
           ,[Gender]
           ,[DOB]
           ,[Edu]
           ,[Ex]
           ,[P_N]
           ,[Gmail])
     VALUES('" + txt_firstname.Text + "','" + txt_lastname.Text + "','" + Gender_emp.Text + "','" + dateTimePicker1.Text + "', '" + edu.Text + "', '" + ex.Text + "', '" + number.Text + "','" + txt_gmail.Text + "')", con);
                    SqlCommand cmd1 = new SqlCommand(@"INSERT INTO [dbo].[Log_In]
           ([Email_ID]
           ,[Password]
           ,[usertype])
     VALUES('" + txt_gmail.Text + "','" + Pass.Text + "','" + Emp_lvl.Text + "')", con);


                    //cmd.Parameters.AddWithValue("@image", Sphoto());
                    //cmd.Parameters.Add(new SqlParameter("@image", images));
                    cmd.ExecuteNonQuery();
                    cmd1.ExecuteNonQuery();
                    //cmd2.ExecuteNonQuery();
                    con.Close();
                    //MessageBox.Show("Registration Successfull and your id:" + rndnum, "Registration", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    Log_In ln = new Log_In();
                    ln.Show();


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please complete all the fildes", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Log_In em = new Log_In();
            this.Hide();
            em.Show();
        }

        private void Close_button_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

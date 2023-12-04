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
    public partial class Emp_Profile : Form
    {

        string email = Log_In.L1;
        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-BVL115R7\SQLEXPRESS;Initial Catalog=DAMS;Integrated Security=True");


        public Emp_Profile()
        {
            InitializeComponent();
            dis();
        }

        private void Emp_Profile_Load(object sender, EventArgs e)
        {
        }

        private void dis()
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select First_name from Emp_Reg where Gmail = '" + email + "'", con);
                SqlCommand cmd1 = new SqlCommand("Select Last_name from Emp_Reg where Gmail = '" + email + "'", con);
                SqlCommand cmd2 = new SqlCommand("Select Gender from Emp_Reg where Gmail = '" + email + "'", con);
                SqlCommand cmd3 = new SqlCommand("Select DOB from Emp_Reg where Gmail = '" + email + "'", con);
                SqlCommand cmd4 = new SqlCommand("Select Edu from Emp_Reg where Gmail = '" + email + "'", con);
                SqlCommand cmd5 = new SqlCommand("Select Ex from Emp_Reg where Gmail = '" + email + "'", con);
                SqlCommand cmd6 = new SqlCommand("Select P_N from Emp_Reg where Gmail = '" + email + "'", con);
                SqlCommand cmd7 = new SqlCommand("Select Gmail from Emp_Reg where Gmail = '" + email + "'", con);

                txt_firstname.Text = cmd.ExecuteScalar().ToString();
                txt_lastname.Text = cmd1.ExecuteScalar().ToString();
                Gender_emp.Text = cmd2.ExecuteScalar().ToString();
                dateTimePicker1.Text = cmd3.ExecuteScalar().ToString();
                edu.Text = cmd4.ExecuteScalar().ToString();
                ex.Text = cmd5.ExecuteScalar().ToString();
                number.Text = cmd6.ExecuteScalar().ToString();
                txt_gmail.Text = cmd7.ExecuteScalar().ToString();

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txt_firstname.Text != null && txt_lastname.Text != null && Gender_emp.Text != null && dateTimePicker1.Text != null && edu.Text != null && ex.Text != null && number.Text != null && txt_gmail.Text != null )
            {
                try
                {

                    con.Open();
                    SqlCommand cmd = new SqlCommand(@"UPDATE [dbo].[Emp_Reg]
   SET [First_name] = '" + txt_firstname.Text + "',[Last_Name] = '" + txt_lastname.Text + "',[Gender]= '" + Gender_emp.Text + "',[DOB]= '" + dateTimePicker1.Text + "', [Edu]= '" + edu.Text + "'    ,   [Ex]= '" + ex.Text + "'    [P_N]= '" + number.Text + "',[Gmail]= '" + txt_gmail.Text + "' WHERE Gmail= '" + txt_gmail.Text + "'", con);
                    SqlCommand cmd1 = new SqlCommand(@"UPDATE [dbo].[Log_In]
   SET [Password] = '" + Pass.Text + "' WHERE Email_ID = '" + txt_gmail.Text + "'", con);


                    cmd.ExecuteNonQuery();
                    cmd1.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Update Successfull", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Pat_Profile p = new Pat_Profile();
                    this.Hide();
                    p.Show();


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

        private void button3_Click(object sender, EventArgs e)
        {
            Emp_Home em = new Emp_Home();
            this.Hide();
            em.Show();
        }
    }
}

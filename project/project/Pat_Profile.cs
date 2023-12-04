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
    public partial class Pat_Profile : Form
    {

        string email = Log_In.L1;
        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-BVL115R7\SQLEXPRESS;Initial Catalog=DAMS;Integrated Security=True");


        public Pat_Profile()
        {
            InitializeComponent();
            dis();
        }

        private void dis()
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select first_name_pr from Pat_Reg where email_pr = '" + email + "'", con);
                SqlCommand cmd1 = new SqlCommand("Select last_name_pr from Pat_Reg where email_pr = '" + email + "'", con);
                SqlCommand cmd2 = new SqlCommand("Select gender_pr from Pat_Reg where email_pr = '" + email + "'", con);
                SqlCommand cmd3= new SqlCommand("Select dob_pr from Pat_Reg where email_pr = '" + email + "'", con);
                SqlCommand cmd4 = new SqlCommand("Select pn_pr from Pat_Reg where email_pr = '" + email + "'", con);
                SqlCommand cmd5 = new SqlCommand("Select email_pr from Pat_Reg where email_pr = '" + email + "'", con);
                SqlCommand cmd6 = new SqlCommand("Select pass_pr from Pat_Reg where email_pr = '" + email + "'", con);
            
                txt_firstname.Text = cmd.ExecuteScalar().ToString();
                txt_lastname.Text = cmd1.ExecuteScalar().ToString();
                Gender_pet.Text = cmd2.ExecuteScalar().ToString();
                dateTimePicker1.Text = cmd3.ExecuteScalar().ToString();
                Number.Text = cmd4.ExecuteScalar().ToString();
                txt_gmail.Text = cmd5.ExecuteScalar().ToString();

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txt_firstname.Text != null && txt_lastname.Text != null && Gender_pet.Text != null && dateTimePicker1.Text != null && Number.Text != null && txt_gmail.Text != null && Pass.Text != null)
            {
                try
                {

                    con.Open();
                    SqlCommand cmd = new SqlCommand(@"UPDATE [dbo].[Pat_Reg]
   SET [first_name_pr] = '" + txt_firstname.Text + "',[last_name_pr] = '" + txt_lastname.Text + "',[gender_pr]= '" + Gender_pet.Text + "',[dob_pr]= '" + dateTimePicker1.Value + "',[email_pr]= '" + txt_gmail.Text + "',[pn_pr]= '" + Number.Text + "' ,[pass_pr]= '" + Pass.Text + "' WHERE email_pr= '" + txt_gmail.Text + "'", con);
                    SqlCommand cmd1 = new SqlCommand(@"UPDATE [dbo].[Log_In]
   SET [Password] = '"+Pass.Text+ "' WHERE Email_ID = '" + txt_gmail.Text +"'", con);


                    //cmd.Parameters.AddWithValue("@image", Sphoto());
                    //cmd.Parameters.Add(new SqlParameter("@image", images));
                    cmd.ExecuteNonQuery();
                    cmd1.ExecuteNonQuery();
                    //cmd2.ExecuteNonQuery();
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

        private void button_back_Click(object sender, EventArgs e)
        {
            Pat_Home p = new Pat_Home();
            this.Hide();
            p.Show();
        }

        private void Close_button_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

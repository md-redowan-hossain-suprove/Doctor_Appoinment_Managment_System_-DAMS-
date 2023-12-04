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
    public partial class Pat_Reg : Form
    {

        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-BVL115R7\SQLEXPRESS;Initial Catalog=DAMS;Integrated Security=True");


        public Pat_Reg()
        {
            InitializeComponent();
        }

        private void Pat_Reg_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txt_firstname.Text != null && txt_lastname.Text != null && Gender_pet.Text != null && dateTimePicker1.Text != null && Number.Text != null && txt_gmail.Text != null && Pass.Text != null)
            {
                try
                {
                   
                    con.Open();
                    SqlCommand cmd = new SqlCommand(@"INSERT INTO [dbo].[Pat_Reg]
           ([first_name_pr]
           ,[last_name_pr]
           ,[gender_pr]
           ,[dob_pr]
           ,[pn_pr]
           ,[email_pr]
           ,[pass_pr])
     VALUES('" + txt_firstname.Text + "','" + txt_lastname.Text + "','" + Gender_pet.Text + "','" + dateTimePicker1.Value + "','" + Number.Text + "','" + txt_gmail.Text + "','" + Pass.Text + "')", con);
                    SqlCommand cmd1 = new SqlCommand(@"INSERT INTO [dbo].[Log_In]
           ([Email_ID]
           ,[Password]
           ,[usertype])
     VALUES('" + txt_gmail.Text + "','" + Pass.Text + "','"+ Patient_lvl .Text+ "')", con);


                    //cmd.Parameters.AddWithValue("@image", Sphoto());
                    //cmd.Parameters.Add(new SqlParameter("@image", images));
                    cmd.ExecuteNonQuery();
                    cmd1.ExecuteNonQuery();
                    //cmd2.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Registration Successfull","Registration", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void button2_Click(object sender, EventArgs e)
        {
            Log_In pat = new Log_In();
            this.Hide();
            pat.Show();
        }

        private void Close_button_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

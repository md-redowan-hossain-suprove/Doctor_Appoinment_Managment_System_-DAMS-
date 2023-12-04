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
    public partial class Emp_Home : Form
    {
        string email = Log_In.L1;
        string key = "";
        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-BVL115R7\SQLEXPRESS;Initial Catalog=DAMS;Integrated Security=True");



        public Emp_Home()
        {
            InitializeComponent();
            dis();
        }

        private void dis()
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(@"SELECT [first_name_pr]
      ,[last_name_pr]
      ,[gender_pr]
      ,[dob_pr]
      ,[pn_pr]
      ,[email_pr]
      ,[pass_pr]
  FROM [dbo].[Pat_Reg] ", con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

            //dataGridView_Cus.DataSource = ds.Tables[0];

            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Emp_Reg er = new Emp_Reg(); 
            this.Hide();
            er.Show();
        }

        private void clear()
        {
            txt_firstname.Text = "";
            txt_lastname.Text = "";
            Gender_pet.Text = "";
            dateTimePicker1.Text = "";
            Number.Text = "";
            txt_gmail.Text = "";
            Pass.Text = "";
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txt_firstname.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                txt_lastname.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                Gender_pet.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                dateTimePicker1.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                Number.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                txt_gmail.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
                Pass.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();

                if (txt_gmail.Text == "")
                {
                    key = "";
                }
                else
                {
                    key = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                }

                /*txt_firstname.Text = dataGridView_Cus.SelectedRows[0].Cells[0].Value.ToString();
                txt_lastname.Text = dataGridView_Cus.SelectedRows[0].Cells[1].Value.ToString();
                Gender_pet.Text = dataGridView_Cus.SelectedRows[0].Cells[2].Value.ToString();
                dateTimePicker1.Text = dataGridView_Cus.SelectedRows[0].Cells[3].Value.ToString();
                Number.Text = dataGridView_Cus.SelectedRows[0].Cells[4].Value.ToString();
                txt_gmail.Text = dataGridView_Cus.SelectedRows[0].Cells[5].Value.ToString();
                Pass.Text = dataGridView_Cus.SelectedRows[0].Cells[6].Value.ToString();

                if (txt_gmail.Text == "")
                {
                    key = "";
                }
                else
                {
                    key = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                }*/
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Emp_Profile ep = new Emp_Profile();
            this.Hide();
            ep.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Are you sure", "Warrning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            if (true)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(@"DELETE FROM [dbo].[Pat_Reg]
      WHERE email_pr= '" + txt_gmail.Text + "'", con);
                SqlCommand cmd1 = new SqlCommand(@"DELETE FROM [dbo].[Log_In]
      WHERE Email_ID = '" + txt_gmail.Text + "'", con);

                cmd.ExecuteNonQuery();
                cmd1.ExecuteNonQuery();
                MessageBox.Show("Account delete successful", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                con.Close();
                dis();
                clear();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (txt_firstname.Text != null && txt_lastname.Text != null && Gender_pet.Text != null && dateTimePicker1.Text != null && Number.Text != null && txt_gmail.Text != null && Pass.Text != null)
            {
                try
                {

                    con.Open();
                    SqlCommand cmd = new SqlCommand(@"UPDATE [dbo].[Pat_Reg]
   SET [first_name_pr] = '" + txt_firstname.Text + "',[last_name_pr] = '" + txt_lastname.Text + "',[gender_pr]= '" + Gender_pet.Text + "',[dob_pr]= '" + dateTimePicker1.Value + "',[email_pr]= '" + txt_gmail.Text + "',[pn_pr]= '" + Number.Text + "' ,[pass_pr]= '" + Pass.Text + "' WHERE email_pr= '" + txt_gmail.Text + "'", con);
                    SqlCommand cmd1 = new SqlCommand(@"UPDATE [dbo].[Log_In]
   SET [Password] = '" + Pass.Text + "' WHERE Email_ID = '" + txt_gmail.Text + "'", con);


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
     VALUES('" + txt_gmail.Text + "','" + Pass.Text + "','" + Patient_lvl.Text + "')", con);


                 
                    cmd.ExecuteNonQuery();
                    cmd1.ExecuteNonQuery();
                 
                    con.Close();
                    MessageBox.Show("Registration Successfull", "Registration", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    


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

        private void button6_Click(object sender, EventArgs e)
        {
            Log_In log_In = new Log_In();
            log_In.Show();
            this.Hide();
        }

        private void Close_button_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            SqlDataAdapter sda = new SqlDataAdapter("select * from Pat_Reg where first_name_pr like '%" + textBox1.Text + "%'", con);
            SqlDataAdapter sda1 = new SqlDataAdapter("select * from Pat_Reg where last_name_pr like '%" + textBox1.Text + "%'", con);
            SqlDataAdapter sda2 = new SqlDataAdapter("select * from Pat_Reg where email_pr like '%" + textBox1.Text + "%'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            sda1.Fill(dt);
            sda2.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
    
}

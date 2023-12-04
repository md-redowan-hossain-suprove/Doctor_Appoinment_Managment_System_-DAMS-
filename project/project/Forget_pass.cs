using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace project
{
    public partial class Forget_pass : Form
    {
        string email = Log_In.L1;
        string randcode;
        public static string to;
        string key = "";
        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-BVL115R7\SQLEXPRESS;Initial Catalog=DAMS;Integrated Security=True");


        public Forget_pass()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (comboBox1.SelectedItem.ToString() == "Patient")
            {
                if (randcode == (textBox_OTP.Text).ToString())
                {
                    to = txt_username.Text;
                    SqlCommand cmd = new SqlCommand(@"UPDATE [dbo].[Log_In]
   SET [Password] = '" + txt_password.Text + "' WHERE Email_ID =  '" + txt_username.Text + "'", con);
                    /*SqlCommand cmd1 = new SqlCommand(@"UPDATE [dbo].[Registration]
   SET [pass] = '" + txt_password.Text + "' WHERE email= '" + txt_username.Text + "'", con);*/

                    con.Open();
                    cmd.ExecuteNonQuery();
                   // cmd1.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Password reset successfully");
                    this.Hide();
                    Log_In ln = new Log_In();
                    ln.Show();
                }
                else
                {
                    MessageBox.Show("Wrong OTP code", "Error", MessageBoxButtons.OK);
                }
            }
            else if (comboBox1.SelectedItem.ToString() == "Employee")
            {
                if (randcode == (textBox_OTP.Text).ToString())
                {
                    to = txt_username.Text;
                    SqlCommand cmd = new SqlCommand(@"UPDATE [dbo].[Log_In]
   SET [Password] = '" + txt_password.Text + "' WHERE Email_ID =  '" + txt_username.Text + "'", con);
                    /*SqlCommand cmd1 = new SqlCommand(@"UPDATE [dbo].[Registration]
   SET [pass] = '" + txt_password.Text + "' WHERE email= '" + txt_username.Text + "'", con);*/

                    con.Open();
                    cmd.ExecuteNonQuery();
                    //cmd1.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Password reset successfully");
                    this.Hide();
                    Log_In ln = new Log_In();
                    ln.Show();
                }
                else
                {
                    MessageBox.Show("Wrong OTP code", "Error", MessageBoxButtons.OK);
                }
            }



            
        }

        private void button_fp_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from Log_In where Email_ID='" + txt_username.Text + "'", con);

            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();

            if (sdr.HasRows == true)
            {
                sdr.Read();
                Random rand = new Random();
                randcode = (rand.Next(999999).ToString());
                MailMessage mm = new MailMessage();
                to = (txt_username.Text).ToString();

                string from = "itcsbd2022@gmail.com";
                string pass = "bvtjhwnauhuwusjp";
                string messageBody = "Your OTP code is: " + randcode;

                mm.To.Add(to);
                mm.From = new MailAddress(from);
                mm.Body = messageBody;
                mm.Subject = "Your DAMS OTP code";

                SmtpClient sc = new SmtpClient("smtp.gmail.com");
                sc.EnableSsl = true;
                sc.Port = 587;
                sc.DeliveryMethod = SmtpDeliveryMethod.Network;
                sc.Credentials = new NetworkCredential(from, pass);

                try
                {
                    sc.Send(mm);
                    MessageBox.Show("OTP Send successfully");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Invalid Email id", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            con.Close();
        }

        private void Close_button_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Log_In fp = new Log_In();
            this.Hide();
            fp.Show();
        }
    }
}

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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace abcd
{

    public partial class Form1 : Form
    {
        private string connection_string = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ASUS\source\repos\STUDENT MANAGEMENT SYSTEM\DATABASE\DATABASE SERVER.mdf;Integrated Security=True;Connect Timeout=30";
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string uid = A.Text.ToString();
            string pass = passward.Text.ToString();
            if (string.IsNullOrEmpty(uid) || string.IsNullOrEmpty(pass))
            {
                DialogResult dialogResult = MessageBox.Show("No empty fields allowed", "You cannot continue", MessageBoxButtons.OK);
            }
            else
            {
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = connection_string;
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select * from [Table] where [STUDENT NAME] = '" + uid + "' and PASSWARD = '" + pass + "'";
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    Form3 formhome = new Form3();
                    formhome.Show();
                    this.Hide();
                   
                }
                else
                {
                    MessageBox.Show("Invalid user id or passward!");
                }
                //conn.Open();MessageBox.Show("Connection Succeeded");
                conn.Close();

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }
    } }


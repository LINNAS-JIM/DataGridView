using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Xml.Linq;
using System.Runtime.Remoting.Contexts;

namespace abcd
{
    public partial class Form2 : Form
    {
       private string connection_string = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ASUS\source\repos\STUDENT MANAGEMENT SYSTEM\DATABASE\DATABASE SERVER.mdf;Integrated Security=True;Connect Timeout=30";
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void student_name_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string uid = id.Text.ToString();
            string sName = student_name.Text.ToString();
            string dptName = dept_name.Text.ToString();
            string pass = password.Text.ToString();

            if (string.IsNullOrEmpty(sName) || string.IsNullOrEmpty(uid) || string.IsNullOrEmpty(dptName) || string.IsNullOrEmpty(pass))
            {
                DialogResult dialogResult = MessageBox.Show("No empty fields allowed, \nPlease fill up all the fields", "Can't Register", MessageBoxButtons.OK);
            }
            else
            {
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = connection_string;
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select * from [Table] where id = '" + uid + "'";
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    MessageBox.Show("The id is already been used.\nEnter a different valid id");
                }
                else
                {
                    reader.Close();
                    SqlCommand cmd1 = new SqlCommand();
                    cmd1.Connection = conn;
                    cmd1.CommandText = "insert into [Table] (Id, [STUDENT NAME], [DEPARTMENT NAME], PASSWARD) values ('" + uid + "', '" + sName + "', '" + dptName + "', '" + pass + "')";
                    cmd1.ExecuteNonQuery();
                    MessageBox.Show("ACCOUNT CREATED");
                    Form1 form = new Form1();
                    form.Show();
                    this.Hide();
                }
                conn.Close();
            }
        }
    }
}

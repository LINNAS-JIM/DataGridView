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

namespace abcd
{
    public partial class Form3 : Form
    {
        private string connection_string = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ASUS\source\repos\STUDENT MANAGEMENT SYSTEM\DATABASE\DATABASE SERVER.mdf;Integrated Security=True;Connect Timeout=30";
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connection_string;
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select * from [Table]";
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.DataSource = table;
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string id = idtb.Text.ToString();
            string name = nametb.Text.ToString();
            string department = departmenttb.Text.ToString();
            string password = passwordtb.Text.ToString();

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connection_string;
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select * from [Table] where id = '" + id + "'";
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                MessageBox.Show("The id already exist.\nEnter a different valid id");
            }
            else
            {
                reader.Close();
                SqlCommand cmd1 = new SqlCommand();
                cmd1.Connection = conn;
                cmd1.CommandText = "insert into [Table] (id,[student name], [department name],  passward) values (@id, @student_name, @department_name,  @passward)";
                cmd1.Parameters.AddWithValue("@id", id);
                cmd1.Parameters.AddWithValue("@student_name", name);
                cmd1.Parameters.AddWithValue("@department_name", department);
                cmd1.Parameters.AddWithValue("@passward", password);
                cmd1.ExecuteNonQuery();
                MessageBox.Show("Data Inserted");
            }


            conn.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {

            idtb.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            nametb.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            departmenttb.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            passwordtb.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            string id = idtb.Text.ToString();
            string name = nametb.Text.ToString();
            string department = departmenttb.Text.ToString();
            string password = passwordtb.Text.ToString();

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connection_string;
            conn.Open();
            
           
            
            
                
            SqlCommand cmd1 = new SqlCommand();
            cmd1.Connection = conn;
            cmd1.CommandText = "update [Table] set [student name] = @student_name, [department name] = @department_name,  passward = @passward where id = " +id;
            cmd1.Parameters.AddWithValue("@id", id);
            cmd1.Parameters.AddWithValue("@student_name", name);
            cmd1.Parameters.AddWithValue("@department_name",department );
            cmd1.Parameters.AddWithValue("@passward", password);
            cmd1.ExecuteNonQuery();
            MessageBox.Show("Row Updated");
            


            conn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string id = idtb.Text.ToString();
            string name = nametb.Text.ToString();
            string department = departmenttb.Text.ToString();
            string password = passwordtb.Text.ToString();

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connection_string;
            conn.Open();

            SqlCommand cmd1 = new SqlCommand();
            cmd1.Connection = conn;
            cmd1.CommandText = "delete from [Table] where id = " + id;
            cmd1.ExecuteNonQuery();
            MessageBox.Show("Row Deleted");

            conn.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

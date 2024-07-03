using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace LoginTest
{
    public partial class Login : Form
    {
        //MySqlConnection con = new MySqlConnection("Server=localhost;Port=3306;Database=shop_db;Uid=root;Pwd=0000;");
        //MySqlConnection con = new MySqlConnection("Server=kiosk.mysql.database.azure.com;Port=3306;Database=kiosk;Uid=youngjin;Pwd=admin123456789;;");
        MySqlConnectionStringBuilder conn = new MySqlConnectionStringBuilder();

        public Login()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Console.WriteLine("Object Sender: "+sender);
            Console.WriteLine("EventArgs e: " + e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(userid.Text.Equals(""))
            {
                MessageBox.Show("아이디를 입력해주세요.", "LOGIN ERROR!", MessageBoxButtons.OK);
                userid.Focus();
            }
            else if (password.Text.Equals(""))
            {
                MessageBox.Show("비밀번호를 입력해주세요.", "LOGIN ERROR!", MessageBoxButtons.OK);
                password.Focus();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Join join = new Join();
            join.Show();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            conn.Server = "kiosk.mysql.database.azure.com";
            conn.Port = 3306;
            conn.Database = "kiosk";
            conn.UserID = "youngjin";
            conn.Password = "admin123456789;";

            MySqlConnection con = new MySqlConnection(conn.ConnectionString);

            con.Open();
            string sql = "select * from test where idx ='1'";
            MySqlCommand command = new MySqlCommand(sql, con);
            MySqlDataReader reader = command.ExecuteReader();

            while(reader.Read())
            {
                //MessageBox.Show((string)reader["member_name"] + " " + (string)reader["member_addr"], (string)reader["member_id"], MessageBoxButtons.OK);
                MessageBox.Show((string)reader["name"], reader["idx"].ToString(),MessageBoxButtons.OK);
            }
            con.Close();
            

            /*
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "kiosk.mysql.database.azure.com";
            builder.UserID = "youngjin";
            builder.Password = "admin123456789;";
            builder.InitialCatalog = "kiosk";

            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                string sql = "select * from test where idx = 1";
                using (SqlCommand command = new SqlCommand(sql,connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            MessageBox.Show((string)reader["name"], (string)reader["idx"],MessageBoxButtons.OK);
                        }
                    }
                    connection.Close();
                }
            }
            */

            /*
            string con = "Server=kiosk.database.windows.net;Database=kiosk;User ID=youngjin;Password=admin123456789;";

            using (SqlConnection conn = new SqlConnection(con))
            {
                conn.Open();
                string sql = "select * from test where idx = '1'";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            MessageBox.Show((string)reader["name"], (string)reader["idx"], MessageBoxButtons.OK);
                        }
                    }
                }

                conn.Close();
            }
            */
        }
    }
}

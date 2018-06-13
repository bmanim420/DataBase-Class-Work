using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Labwork_3
{
    public partial class Form3 : Form
    {
        MySqlConnection connection = new MySqlConnection("server= localhost; username= root; password=; database= assignment;");
        public Form3()
        {
            InitializeComponent();
        }

   
        
        private void Form3_Load(object sender, EventArgs e)
        {/*
            connection.Open();
            string qry = "SELECT * FROM user WHERE username='" + Form2.user + "'";
            MySqlCommand cmd = new MySqlCommand(qry, connection);
            cmd.ExecuteNonQuery();
            MySqlDataReader mdr;
            mdr = cmd.ExecuteReader();
            if (mdr.Read())
            {
                username.Text=(mdr.GetString("username"));
            }
            connection.Close();
            */
        }
        


        private void button2_Click(object sender, EventArgs e)
        {
            /*
            string brand = textBox1.Text;
            connection.Open();
            string qry = "SELECT * FROM product WHERE RAM='" + brand + "'";
            MySqlCommand cmd = new MySqlCommand(qry, connection);
            cmd.ExecuteNonQuery();
            MySqlDataReader mdr;
            mdr = cmd.ExecuteReader();
            if (mdr.Read())
            {
                this.brand.Text = (mdr.GetString("RAM"));
                MessageBox.Show(mdr.GetString("RAM"));
            }
            connection.Close();
            */
        }

    

      

       

        private void button5_Click(object sender, EventArgs e)
        {
            string brand = textBox4.Text;
            connection.Open();
            int records = 0;
            string qry = "SELECT * FROM product WHERE pro_model='" + brand + "' OR pro_brand='" + brand + "'";
            MySqlCommand cmd = new MySqlCommand(qry, connection);
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            records = Convert.ToInt32(dt.Rows.Count.ToString());
            connection.Close();
            if (records == 0)
            {
                MessageBox.Show("NO");
            }
            else
            {
                MessageBox.Show("YES");
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            string pro = textBox4.Text;
            connection.Open();
            string query1 = "INSERT INTO orders (username, pro_model) VALUES ('" + Form2.user + "','" + pro + "')";

            MySqlCommand cmd1 = new MySqlCommand(query1, connection);
            cmd1.ExecuteNonQuery();
            MessageBox.Show("Order Placed!");
            connection.Close();
        }

        private void Form3_Load_1(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }

    }

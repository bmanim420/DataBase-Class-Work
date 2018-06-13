using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading; //for using multithreading
using MySql.Data.MySqlClient; //for using database

namespace Labwork_3
{
    public partial class Form1 : Form
    {
        Thread objt; //object of multithreading 
        MySqlConnection connection = new MySqlConnection("server=localhost; username=root; password=; database=assignment");

        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string uname = username.Text;
            string pw = password.Text;
            string query1 = "INSERT INTO user (username, password) VALUES ('" + uname + "','" + pw + "')";
            connection.Open();

            MySqlCommand cmd1 = new MySqlCommand(query1, connection);
            cmd1.ExecuteNonQuery();
            MessageBox.Show("Data entry Successfull!");
            connection.Close();
            
            this.Close();
            objt = new Thread(openform2);
            objt.SetApartmentState(ApartmentState.STA);
            objt.Start();

        }

        private void openform2()
        {
            Form2 f2=new Form2();
            Application.Run(f2);
        }

        private void password_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void username_TextChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
            objt = new Thread(openform2);
            objt.SetApartmentState(ApartmentState.STA);
            objt.Start();
        }
    }
}

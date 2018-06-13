using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using MySql.Data.MySqlClient;

namespace Labwork_3
{

    public partial class Form2 : Form
    {
        Thread objt;
        MySqlConnection connection = new MySqlConnection("server= localhost; username= root; password=; database= assignment;");
        public static string user = ""; 
        public Form2()
        {
            InitializeComponent();
        }
        private void ShowWarning(string value)
        {
            warning.Text = value;
            warning.ForeColor = Color.Red;
        }
        private void openform3()
        {
            Form3 f3 = new Form3();
            Application.Run(f3);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //to check if database connected
            /*try
            {
                connection.Open();
                MessageBox.Show("Connected");
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }*/
            if (username.Text =="")
           {
                ShowWarning("Please Enter Username");
                if (password.Text=="")
                {
                    ShowWarning("\nPlease Enter Password");
                }
               

           }
           else if (password.Text == "")
            {
                ShowWarning("Please Enter Password");
            }
            else
            {
                connection.Open();
                int records = 0;
                string query = "SELECT * FROM user WHERE username='" + username.Text + "' AND password='" + password.Text + "'";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                MySqlDataAdapter da=new MySqlDataAdapter(cmd);
                da.Fill(dt);
                records = Convert.ToInt32(dt.Rows.Count.ToString());
                connection.Close();
                //MessageBox.Show(records.ToString());
                if (records == 0)
                {
                    MessageBox.Show("Mismatch");
                }
                else
                {
                    MessageBox.Show("Login Successfull");
                    user= username.Text;
                    this.Close();
                    objt = new Thread(openform3);
                    objt.SetApartmentState(ApartmentState.STA);
                    objt.Start();
                }
                
            }
        }
    }
}

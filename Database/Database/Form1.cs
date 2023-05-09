using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace Database
{
    public partial class Form1 : Form
    {
        private SqlConnection sqlConnection = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Departure"].ConnectionString);
            sqlConnection.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand(
                $"INSERT INTO [Flights] (from_location, to_location, departure_time, arrival_time) VALUES (N'{textBox1.Text}', N'{textBox2.Text}', N'{textBox3.Text}', N'{textBox4.Text}')", sqlConnection);
            MessageBox.Show(command.ExecuteNonQuery().ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand(
                $"INSERT INTO [Payments] (ticket_id, payment_time, payment_amount) VALUES (N'{textBox5.Text}', N'{textBox6.Text}', N'{textBox7.Text}')", sqlConnection);
            MessageBox.Show(command.ExecuteNonQuery().ToString());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand(
                $"INSERT INTO [Tickets] (flight_id, passenger_name, passenger_passport, seat_number) VALUES (N'{textBox8.Text}', N'{textBox9.Text}', N'{textBox10.Text}', N'{textBox11.Text}')", sqlConnection);
            MessageBox.Show(command.ExecuteNonQuery().ToString());
        }

        private void select_Click(object sender, EventArgs e)
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter(
                textBox12.Text, sqlConnection);

            DataSet ds = new DataSet();

            dataAdapter.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0];  
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter(
                textBox13.Text, sqlConnection);

            DataSet ds = new DataSet();

            dataAdapter.Fill(ds);

            dataGridView2.DataSource = ds.Tables[0];
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter(
                textBox14.Text, sqlConnection);

            DataSet ds = new DataSet();

            dataAdapter.Fill(ds);

            dataGridView3.DataSource = ds.Tables[0];
        }

        
    }
}

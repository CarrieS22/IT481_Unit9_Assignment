using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace IT481_Unit9
{
    public partial class Form1 : Form
    {
        DB database;
        private string user;
        private string password;
        private string server;
        private string Database;
        public Form1()
        {
            InitializeComponent();
            textBox4.Text = "DESKTOP-MKGI3I1\\SQLEXPRESS";
            textBox5.Text = "Northwind";
            textBox3.PasswordChar = '*';
            button1.Click += new EventHandler(button1_Click);
            button2.Click += new EventHandler(button2_Click);
            button3.Click += new EventHandler(button3_Click);
            button4.Click += new EventHandler(button4_Click);
            button5.Click += new EventHandler(button5_Click);
            button6.Click += new EventHandler(button6_Click);
            button7.Click += new EventHandler(button7_Click);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            bool isValid = true;
            user = textBox1.Text;
            password = textBox3.Text;
            server = textBox4.Text;
            Database = textBox5.Text;

            if (user.Length == 0 || password.Length == 0 || server.Length == 0 || Database.Length == 0)
            {
                isValid = false;
                MessageBox.Show("You must enter user name, password, server and database value.");
            }

            else if (password.Length < 8)
            {
                isValid = false;
                MessageBox.Show("Password must be 8 characters or more.");
            }

            if (isValid)
            {
                database = new DB("Server = " + server
                    + "DESKTOP-MKGI3I1\\SQLEXPRESS;"
                    + "Trusted_Connection=true;"
                    + "Database = " + Database + ";"
                    + "User Id = " + user + ";" 
                    + "Password = " + password + ";");

                MessageBox.Show("Connection information sent");
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (user == "User_CEO")
            {
                IsAccessible = true;
                string count = database.getCustomerCount(database.GetConn());
                MessageBox.Show(count, "Customer count");
            }

            if (user == "User_Sales")
            {
                 IsAccessible = true;
                 string count = database.getCustomerCount(database.GetConn());
                 MessageBox.Show(count, "Customer count");
            }

            else if (user == "User_HR")
            {
                IsAccessible = false;
                MessageBox.Show("Access denied.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (user == "User_CEO")
            {
                IsAccessible = true;
                string name = database.getCustomerNames();
                MessageBox.Show(name, "CustomerNames");
            }

            if (user == "User_Sales")
            {
                IsAccessible = true;
                string name = database.getCustomerNames();
                MessageBox.Show(name, "CustomerNames");

            }

            else if (user == "User_HR")
            {
                IsAccessible = false;
                MessageBox.Show("Access denied.");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (user == "User_CEO")
            {
                IsAccessible = true;
                string count = database.getOrderCount();
                MessageBox.Show(count, "Order count");

            }

            if (user == "User_Sales")
            {
                IsAccessible = true;
                string count = database.getOrderCount();
                MessageBox.Show(count, "Order count");

            }

            if (user == "User_HR")
            {
                IsAccessible = true;
                string count = database.getOrderCount();
                MessageBox.Show(count, "Order count");

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

            if (user == "User_CEO")
            {
                IsAccessible = true;
                string orderid = database.getOrder();
                MessageBox.Show(orderid, "OrderID");

            }

            if (user == "User_Sales")
            {
                IsAccessible = true;
                string orderid = database.getOrder();
                MessageBox.Show(orderid, "OrderID");

            }

            if (user == "User_HR")
            {
                IsAccessible = true;
                string orderid = database.getOrder();
                MessageBox.Show(orderid, "OrderID");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (user == "User_CEO")
            {
                IsAccessible = true;
                string count = database.getEmployeeCount();
                MessageBox.Show(count, "Employee count");
            }

            if (user == "User_HR")
            {
                IsAccessible = true;
                string count = database.getEmployeeCount();
                MessageBox.Show(count, "Employee count");
            }
            else if (user == "User_Sales")
            {
                IsAccessible = false;
                MessageBox.Show("Access denied.");
            }
        }
        private void button7_Click(object sender, EventArgs e)
        {
            if (user == "User_CEO")
            {
                IsAccessible = true;
                string name = database.getEmployeeLastName();
                MessageBox.Show(name, "EmployeeLastName");
            }

            if (user == "User_HR")
            {
                IsAccessible = true;
                string name = database.getEmployeeLastName();
                MessageBox.Show(name, "EmployeeLastName");
            }
            else if (user == "User_Sales")
            {
                IsAccessible = false;
                MessageBox.Show("Access denied.");
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
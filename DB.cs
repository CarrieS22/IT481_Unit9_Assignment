using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IT481_Unit9
{
    class DB
    {
        private string user;
        private string password;
        private string server;
        private string Database;
        string connectionString;
        SqlConnection conn;

        public DB()
        {
            connectionString = "Server = " + server
                    + "DESKTOP-MKGI3I1\\SQLEXPRESS;"
                    + "Trusted_Connection=true;"
                    + "Database = " + Database + ";"
                    + "User Id = " + user + ";" 
                    + "Password = " + password + ";";
        }

        public DB(string conn)
        {
            connectionString = conn;
        }

        public SqlConnection GetConn()
        {
            return conn;
        }

        public string getCustomerCount(SqlConnection conn)
        {
            
            Int32 count = 0;


            connectionString = "Server = DESKTOP-MKGI3I1\\SQLEXPRESS; " +
                                "Trusted_Connection=true;" +
                                "Database=northwind;";
           
            conn = new SqlConnection(connectionString);
            conn.Open();
            string countQuery = "select count(*) from dbo.Customers;";
            SqlCommand cmd = new SqlCommand(countQuery, conn);

            try
            {
                count = Convert.ToInt32(cmd.ExecuteScalar());
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return count.ToString();
        }

        public string getCustomerNames()
        {
         
            string names = "";
            SqlDataReader dataReader;

            connectionString = "Server = DESKTOP-MKGI3I1\\SQLEXPRESS; " +
                                "Trusted_Connection=true;" +
                                "Database=northwind;";

            conn = new SqlConnection(connectionString);
            conn.Open();
            string countQuery = "select companyname from customers;";
            SqlCommand cmd = new SqlCommand(countQuery, conn);
            dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                try
                {
                    names = names + dataReader.GetValue(0) + "\n";
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return names;
        }

        public string getOrderCount()
        {
            Int32 count = 0;

            connectionString = "Server = DESKTOP-MKGI3I1\\SQLEXPRESS; " +
                               "Trusted_Connection=true;" +
                               "Database=northwind;";

            conn = new SqlConnection(connectionString);
            conn.Open();
            string countQuery = "select count(*) from dbo.Orders;";
            SqlCommand cmd = new SqlCommand(countQuery, conn);

            try
            {
                count = Convert.ToInt32(cmd.ExecuteScalar());
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return count.ToString();
        }

        public string getOrder()
        {
            string names = "";
            SqlDataReader dataReader;

            conn = new SqlConnection(connectionString);
            conn.Open();
            string countQuery = "select orderid from dbo.Orders;";
            SqlCommand cmd = new SqlCommand(countQuery, conn);
            dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                try
                {
                    names = names + dataReader.GetValue(0) + "\n";
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return names;
        }

        public string getCustomerID()
        {
            string names = "";
            SqlDataReader dataReader;

            conn = new SqlConnection(connectionString);
            conn.Open();
            string countQuery = "select distinct CustomerID from orders;";
            SqlCommand cmd = new SqlCommand(countQuery, conn);
            dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                try
                {
                    names = names + dataReader.GetValue(0) + "\n";
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return names;
        }

        public string getEmployeeCount()
        {
            Int32 count = 0;

            conn = new SqlConnection(connectionString);
            conn.Open();
            string countQuery = "select count(*) from dbo.Employees;";
            SqlCommand cmd = new SqlCommand(countQuery, conn);

            try
            {
                count = Convert.ToInt32(cmd.ExecuteScalar());
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return count.ToString();
        }

        public string getEmployeeLastName()
        {
            string names = "";
            SqlDataReader dataReader;

            conn = new SqlConnection(connectionString);
            conn.Open();
            string countQuery = "select lastname from employees;";
            SqlCommand cmd = new SqlCommand(countQuery, conn);
            dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                try
                {
                    names = names + dataReader.GetValue(0) + "\n";
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return names;
        }
    }
}

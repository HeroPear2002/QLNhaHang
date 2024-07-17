using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class Dataprovider
    {
        private static Dataprovider instance;

        public static Dataprovider Instance
        {
            get { if (instance == null) instance = new Dataprovider(); return instance; }
            set => instance = value;
        }
        private Dataprovider() { }
        private string consrt = @"Data Source=DD-DI05\SQLEXPRESS;Initial Catalog=QLNhaHang;User ID=sa; password=123456a@";
        public DataTable ExecuteQuery(string query, object[] Paramater = null)
        {
            DataTable data = new DataTable();
            using (SqlConnection connection = new SqlConnection(consrt))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);
                string[] ls = query.Split(' ');
                if (Paramater != null)
                {
                    int i = 0;
                    foreach (string item in ls)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, Paramater[i]);
                            i++;
                        }
                    }
                }
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(data);
                connection.Close();
            }
            return data;
        }
        public int ExecuteNonQuery(string query, object[] Paramater = null)
        {
            int data = 0;
            using (SqlConnection connection = new SqlConnection(consrt))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);
                string[] ls = query.Split(' ');
                if (Paramater != null)
                {
                    int i = 0;
                    foreach (string item in ls)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, Paramater[i]);
                            i++;
                        }
                    }
                }
                data = command.ExecuteNonQuery();
                connection.Close();
            }
            return data;
        }
        public object ExecuteScalar(string query, object[] Paramater = null)
        {
            object data;
            using (SqlConnection connection = new SqlConnection(consrt))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);
                string[] ls = query.Split(' ');
                if (Paramater != null)
                {
                    int i = 0;
                    foreach (string item in ls)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, Paramater[i]);
                            i++;
                        }
                    }
                }
                data = command.ExecuteScalar();
                connection.Close();
            }
            return data;
        }
    }
}

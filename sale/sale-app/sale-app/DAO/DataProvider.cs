using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace sale_app.DAO
{
    public class DataProvider
    {
        private static DataProvider instance;

      
        private string connectionString = "Data Source=DESKTOP-9RQ4UH6;Initial Catalog=sale_management;Integrated Security=True";

        public static DataProvider Instance
        {
            get { if (instance == null) instance = new DataProvider(); return DataProvider.instance; }
            private set => DataProvider.instance = value;
        }

        private DataProvider() { }
        public DataTable ExecuteQuery(string query, object[] parameters = null)
        {
            DataTable data = new DataTable();
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();
                SqlCommand commad = new SqlCommand(query, connection);
                if (parameters != null)
                {
                    string[] listParams = query.Split(' ');
                    int i = 0;
                    foreach (string item in listParams)
                    {
                        if (item.Contains('@'))
                        {
                            commad.Parameters.AddWithValue(item, parameters[i]);
                            i++;
                        }
                    }
                }
                SqlDataAdapter adapter = new SqlDataAdapter(commad);
                adapter.Fill(data);
                connection.Close();
            };
            return data;
        }
        public int ExecuteNoneQuery(string query, object[] parameters = null)
        {
            int data = 0;
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();
                SqlCommand commad = new SqlCommand(query, connection);
                if (parameters != null)
                {
                    string[] listParams = query.Split(' ');
                    int i = 0;
                    foreach (string item in listParams)
                    {
                        if (item.Contains('@'))
                        {
                            commad.Parameters.AddWithValue(item, parameters[i]);
                            i++;
                        }
                    }
                }
                data = commad.ExecuteNonQuery();
                connection.Close();
            };
            return data;
        }
        public object ExecuteScalar(string query, object[] parameters = null)
        {
            object data;
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();
                SqlCommand commad = new SqlCommand(query, connection);
                if (parameters != null)
                {
                    string[] listParams = query.Split(' ');
                    int i = 0;
                    foreach (string item in listParams)
                    {
                        if (item.Contains('@'))
                        {
                            commad.Parameters.AddWithValue(item, parameters[i]);
                            i++;
                        }
                    }
                }
                data = commad.ExecuteScalar();
                connection.Close();
            };
            return data;
        }
    }
    
}

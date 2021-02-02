using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace QLKS
{
    public class DataProvider
    {
        private static DataProvider instance;

        public static DataProvider Instance
        {
            get
            {
                if (instance == null)
                    instance = new DataProvider();
                return DataProvider.instance;
            }
            private set { DataProvider.instance = value; }
        }
        private DataProvider() {  }
        private string connectionSTR = @"Data Source=DESKTOP-P8S45LS\AHHUNGKNOW;Initial Catalog=QLKS_test;Integrated Security=True";
        public DataTable ExecuteQuery(string query,object[] Parameters=null)
        {
            DataTable dt=new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                if (Parameters != null)
                {
                    int i = 0;
                    string[] listParameter = query.Split(' ');
                    foreach (string item in listParameter)
                    {
                        if (item.Contains("@"))
                        {
                            cmd.Parameters.AddWithValue(item, Parameters[i]);
                            i++;
                        }
                    }
                }
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                connection.Close();
            }
        return dt;
        }
        public int ExecuteNonQuery(string query,object[] Parameters=null)
        {
            int data = 0;
            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                if (Parameters != null)
                {
                    int i = 0;
                    string[] listParameter = query.Split(' ');
                    foreach(string item in listParameter)
                    {
                        if (item.Contains("@"))
                        {
                            cmd.Parameters.AddWithValue(item, Parameters[i]);
                            i++;
                        }
                    }
                }
                data = cmd.ExecuteNonQuery();
                connection.Close();
            }
            return data;
        }
        public object ExecuteScalar(string query,object[] Parameters=null)
        {
            object data = 0;

            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                if(Parameters!=null)
                {
                    int i = 0;
                    string[] listParameter = query.Split(' ');
                    foreach(string item in listParameter)
                    {
                        if (item.Contains("@"))
                        {
                            cmd.Parameters.AddWithValue(item, Parameters[i]);
                            i++;
                        }
                    }
                }
                data = cmd.ExecuteScalar();
                connection.Close();
            }
            return data;
        }
    }
}


using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ToDoApp.App_Code
{
    public class MyDB
    {
        public static DataSet select(string qry, string[] Parameters, object[] Values)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ToDoAppDB"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = qry;
            cmd.Connection = connection;
            for (int i = 0; i < Parameters.Length; i++)
            {
                cmd.Parameters.AddWithValue(Parameters[i], Values[i]);
            }
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            connection.Close();
            return ds;
        }

        public static void updateTable(string qry ,string[] Parameters, object[] Values)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ToDoAppDB"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(connectionString);
            myConnection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = qry;
            cmd.Connection = myConnection;
            for (int i = 0; i < Parameters.Length; i++)
            {
                cmd.Parameters.AddWithValue(Parameters[i], Values[i]);
            }
            cmd.ExecuteNonQuery();
            myConnection.Close();
        }
    }
}
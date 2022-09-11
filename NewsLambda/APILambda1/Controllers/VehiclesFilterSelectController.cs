using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using APILambda.Models;

namespace APILambda.Services
{
    public class VehiclesFilterSelectController
    {
        /// <summary>
        /// Inserts Vehicles.
        /// </summary>
        public DataTable Get(FilterModel FilterModelM)
        {
            DataTable dt = new DataTable();
            string connstring = Environment.GetEnvironmentVariable("myDb");
            SqlConnection Conn = new SqlConnection(connstring);
            try
            {
                Conn.Open();
                string query = "";
                if (FilterModelM.maxRecordsCount <= 0)
                {
                    query = "select * from Vehicles where " + FilterModelM.FilterColumnName + " ='" + FilterModelM.FilterColumnValue + "' ";
                }
                else
                {
                    query = "select  top(" + FilterModelM.maxRecordsCount + ") * from Vehicles where " + FilterModelM.FilterColumnName + " ='" + FilterModelM.FilterColumnValue + "' ";
                }

                var cmd = new SqlCommand(query, Conn);
                dt.Load(cmd.ExecuteReader());
                Conn.Close();
            }
            catch (Exception ee)
            {
                dt.Columns.Add("Error", typeof(string));
                dt.Rows.Add(ee.ToString());
            }

            return dt;
        }
    }
}
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
    public class ModelDetailsInsertController
    {
        /// <summary>
        /// Inserts ModelDetails.
        /// </summary>
        public ModelDetails Post(ModelDetails ModelDetailsm)
        {
            int i = 0;
            DataTable dt = new DataTable();
            string connstring = Environment.GetEnvironmentVariable("myDb");
            SqlConnection Conn = new SqlConnection(connstring);
            try
            {
                Conn.Open();
                string query = "Insert into  ModelDetails(Vehicleid , Features , ModelDescription ) Values(@Vehicleid , @Features , @ModelDescription );";
                var cmd = new SqlCommand(query, Conn);
                cmd.Parameters.AddWithValue(@"Vehicleid", ModelDetailsm.Vehicleid);
                cmd.Parameters.AddWithValue(@"Features", ModelDetailsm.Features);
                cmd.Parameters.AddWithValue(@"ModelDescription", ModelDetailsm.ModelDescription);
                dt.Load(cmd.ExecuteReader());
                Conn.Close();
                ModelDetailsm.errorMessage = "Success";
            }
            catch (Exception ee)
            {
                ModelDetailsm.errorMessage = ee.ToString();
            }

            return ModelDetailsm;
        }
    }
}
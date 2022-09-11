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
    public class ModelDetailsUpdateController
    {
        /// <summary>
        /// Inserts ModelDetails.
        /// </summary>
        public ModelDetails Post(ModelDetails ModelDetailsm)
        {
            DataTable dt = new DataTable();
            string connstring = Environment.GetEnvironmentVariable("myDb");
            SqlConnection Conn = new SqlConnection(connstring);
            try
            {
                Conn.Open();
                string query = "Update ModelDetails set    Vehicleid = @Vehicleid ,    Features = @Features ,    ModelDescription = @ModelDescription  where Id=@Id";
                var cmd = new SqlCommand(query, Conn);
                cmd.Parameters.AddWithValue(@"Vehicleid", ModelDetailsm.Vehicleid);
                cmd.Parameters.AddWithValue(@"Features", ModelDetailsm.Features);
                cmd.Parameters.AddWithValue(@"ModelDescription", ModelDetailsm.ModelDescription);
                cmd.Parameters.AddWithValue(@"Id", ModelDetailsm.Id);
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
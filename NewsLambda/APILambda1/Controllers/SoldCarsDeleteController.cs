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
    public class SoldCarsDeleteController
    {
        /// <summary>
        /// Inserts SoldCars.
        /// </summary>
        public DeleteModel Delete(DeleteModel DeleteModelm)
        {
            DataTable dt = new DataTable();
            string connstring = Environment.GetEnvironmentVariable("myDb");
            SqlConnection Conn = new SqlConnection(connstring);
            try
            {
                Conn.Open();
                string query = "Delete  from SoldCars where Id= @Id";
                var cmd = new SqlCommand(query, Conn);
                cmd.Parameters.AddWithValue(@"Id", DeleteModelm.DeleteId);
                dt.Load(cmd.ExecuteReader());
                Conn.Close();
                DeleteModelm.errorMessage = "Success";
            }
            catch (Exception ee)
            {
                DeleteModelm.errorMessage = ee.ToString();
            }

            return DeleteModelm;
        }
    }
}
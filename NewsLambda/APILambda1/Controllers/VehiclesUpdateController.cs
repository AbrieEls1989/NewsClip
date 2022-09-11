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
    public class VehiclesUpdateController
    {
        /// <summary>
        /// Inserts Vehicles.
        /// </summary>
        public Vehicles Post(Vehicles Vehiclesm)
        {
            DataTable dt = new DataTable();
            string connstring = Environment.GetEnvironmentVariable("myDb");
            SqlConnection Conn = new SqlConnection(connstring);
            try
            {
                Conn.Open();
                string query = "Update Vehicles set    QTY = @QTY ,    Make = @Make ,    Model = @Model  where Id=@Id";
                var cmd = new SqlCommand(query, Conn);
                cmd.Parameters.AddWithValue(@"QTY", Vehiclesm.QTY);
                cmd.Parameters.AddWithValue(@"Make", Vehiclesm.Make);
                cmd.Parameters.AddWithValue(@"Model", Vehiclesm.Model);
                cmd.Parameters.AddWithValue(@"Id", Vehiclesm.Id);
                dt.Load(cmd.ExecuteReader());
                Conn.Close();
                Vehiclesm.errorMessage = "Success";
            }
            catch (Exception ee)
            {
                Vehiclesm.errorMessage = ee.ToString();
            }

            return Vehiclesm;
        }
    }
}
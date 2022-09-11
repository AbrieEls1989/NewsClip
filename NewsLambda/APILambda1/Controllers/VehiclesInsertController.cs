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
    public class VehiclesInsertController
    {
        /// <summary>
        /// Inserts Vehicles.
        /// </summary>
        public Vehicles Post(Vehicles Vehiclesm)
        {
            int i = 0;
            DataTable dt = new DataTable();
            string connstring = Environment.GetEnvironmentVariable("myDb");
            SqlConnection Conn = new SqlConnection(connstring);
            try
            {
                Conn.Open();
                string query = "Insert into  Vehicles(QTY , Make , Model ) Values(@QTY , @Make , @Model );";
                var cmd = new SqlCommand(query, Conn);
                cmd.Parameters.AddWithValue(@"QTY", Vehiclesm.QTY);
                cmd.Parameters.AddWithValue(@"Make", Vehiclesm.Make);
                cmd.Parameters.AddWithValue(@"Model", Vehiclesm.Model);
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
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
    public class SoldCarsInsertController
    {
        /// <summary>
        /// Inserts SoldCars.
        /// </summary>
        public SoldCars Post(SoldCars SoldCarsm)
        {
            int i = 0;
            DataTable dt = new DataTable();
            string connstring = Environment.GetEnvironmentVariable("myDb");
            SqlConnection Conn = new SqlConnection(connstring);
            try
            {
                Conn.Open();
                string query = "Insert into  SoldCars(Price , ModelId , QTY , VehicleId , ClientName ) Values(@Price , @ModelId , @QTY , @VehicleId , @ClientName );";
                var cmd = new SqlCommand(query, Conn);
                cmd.Parameters.AddWithValue(@"Price", SoldCarsm.Price);
                cmd.Parameters.AddWithValue(@"ModelId", SoldCarsm.ModelId);
                cmd.Parameters.AddWithValue(@"QTY", SoldCarsm.QTY);
                cmd.Parameters.AddWithValue(@"VehicleId", SoldCarsm.VehicleId);
                cmd.Parameters.AddWithValue(@"ClientName", SoldCarsm.ClientName);
                dt.Load(cmd.ExecuteReader());
                Conn.Close();
                SoldCarsm.errorMessage = "Success";
            }
            catch (Exception ee)
            {
                SoldCarsm.errorMessage = ee.ToString();
            }

            return SoldCarsm;
        }
    }
}
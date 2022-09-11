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
    public class SoldCarsUpdateController
    {
        /// <summary>
        /// Inserts SoldCars.
        /// </summary>
        public SoldCars Post(SoldCars SoldCarsm)
        {
            DataTable dt = new DataTable();
            string connstring = Environment.GetEnvironmentVariable("myDb");
            SqlConnection Conn = new SqlConnection(connstring);
            try
            {
                Conn.Open();
                string query = "Update SoldCars set    Price = @Price ,    ModelId = @ModelId ,    QTY = @QTY ,    VehicleId = @VehicleId ,    ClientName = @ClientName  where Id=@Id";
                var cmd = new SqlCommand(query, Conn);
                cmd.Parameters.AddWithValue(@"Price", SoldCarsm.Price);
                cmd.Parameters.AddWithValue(@"ModelId", SoldCarsm.ModelId);
                cmd.Parameters.AddWithValue(@"QTY", SoldCarsm.QTY);
                cmd.Parameters.AddWithValue(@"VehicleId", SoldCarsm.VehicleId);
                cmd.Parameters.AddWithValue(@"ClientName", SoldCarsm.ClientName);
                cmd.Parameters.AddWithValue(@"Id", SoldCarsm.Id);
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
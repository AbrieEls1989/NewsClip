using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Api.Models;
using Microsoft.Extensions.Configuration;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SoldCarsInsertController : ControllerBase
    {
        /// <summary>
        /// Inserts SoldCars.
        /// </summary>
        private readonly IConfiguration _configuration;
        public SoldCarsInsertController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [SwaggerResponse(200, "The SoldCars was Inserted", typeof(List<SoldCars>))]
        [SwaggerResponse(400, "The SoldCars data is invalid")]
        [HttpPost]
        public SoldCars Post(SoldCars SoldCarsm)
        {
            int i = 0;
            DataTable dt = new DataTable();
            string connstring = _configuration.GetConnectionString("myDb1");
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
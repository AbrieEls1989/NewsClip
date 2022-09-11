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
    public class VehiclesInsertController : ControllerBase
    {
        /// <summary>
        /// Inserts Vehicles.
        /// </summary>
        private readonly IConfiguration _configuration;
        public VehiclesInsertController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [SwaggerResponse(200, "The Vehicles was Inserted", typeof(List<Vehicles>))]
        [SwaggerResponse(400, "The Vehicles data is invalid")]
        [HttpPost]
        public Vehicles Post(Vehicles Vehiclesm)
        {
            int i = 0;
            DataTable dt = new DataTable();
            string connstring = _configuration.GetConnectionString("myDb1");
            SqlConnection Conn = new SqlConnection(connstring);
            try
            {
                Conn.Open();
                string query = "Insert into  Vehicles(QTY , Make , Model ,img) Values(@QTY , @Make , @Model,@img );";
                var cmd = new SqlCommand(query, Conn);
                cmd.Parameters.AddWithValue(@"QTY", Vehiclesm.QTY);
                cmd.Parameters.AddWithValue(@"Make", Vehiclesm.Make);
                cmd.Parameters.AddWithValue(@"Model", Vehiclesm.Model);
                cmd.Parameters.AddWithValue(@"img", Vehiclesm.Model);
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
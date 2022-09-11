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
    public class VehiclesUpdateController : ControllerBase
    {
        /// <summary>
        /// Inserts Vehicles.
        /// </summary>
        private readonly IConfiguration _configuration;
        public VehiclesUpdateController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [SwaggerResponse(200, "The Vehicles was Updated", typeof(List<Vehicles>))]
        [SwaggerResponse(400, "The Vehicles data is invalid")]
        [HttpPost]
        public Vehicles Post(Vehicles Vehiclesm)
        {
            DataTable dt = new DataTable();
            string connstring = _configuration.GetConnectionString("myDb1");
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
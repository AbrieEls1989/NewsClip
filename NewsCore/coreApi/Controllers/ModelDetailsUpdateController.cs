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
    public class ModelDetailsUpdateController : ControllerBase
    {
        /// <summary>
        /// Inserts ModelDetails.
        /// </summary>
        private readonly IConfiguration _configuration;
        public ModelDetailsUpdateController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [SwaggerResponse(200, "The ModelDetails was Updated", typeof(List<ModelDetails>))]
        [SwaggerResponse(400, "The ModelDetails data is invalid")]
        [HttpPost]
        public ModelDetails Post(ModelDetails ModelDetailsm)
        {
            DataTable dt = new DataTable();
            string connstring = _configuration.GetConnectionString("myDb1");
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
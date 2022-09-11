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
    public class SoldCarsDeleteController : ControllerBase
    {
        /// <summary>
        /// Inserts SoldCars.
        /// </summary>
        private readonly IConfiguration _configuration;
        public SoldCarsDeleteController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [SwaggerResponse(200, "The SoldCars was Deleted", typeof(List<SoldCars>))]
        [SwaggerResponse(400, "The SoldCars data is invalid")]
        [HttpDelete]
        public DeleteModel Delete(DeleteModel DeleteModelm)
        {
            DataTable dt = new DataTable();
            string connstring = _configuration.GetConnectionString("myDb1");
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
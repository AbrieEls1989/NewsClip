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
    public class VehiclesFilterSelectController : ControllerBase
    {
        /// <summary>
        /// Inserts Vehicles.
        /// </summary>
        private readonly IConfiguration _configuration;
        public VehiclesFilterSelectController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [SwaggerResponse(200, "The Vehicles was Selected", typeof(List<Vehicles>))]
        [SwaggerResponse(400, "The Vehicles data is invalid")]
        [HttpGet]
        public DataTable Get(FilterModel FilterModelM)
        {
            DataTable dt = new DataTable();
            string connstring = _configuration.GetConnectionString("myDb1");
            SqlConnection Conn = new SqlConnection(connstring);
            try
            {
                Conn.Open();
                string query = "";
                if (FilterModelM.maxRecordsCount <= 0)
                {
                    query = "select * from Vehicles where " + FilterModelM.FilterColumnName + " ='" + FilterModelM.FilterColumnValue + "' ";
                }
                else
                {
                    query = "select  top(" + FilterModelM.maxRecordsCount + ") * from Vehicles where " + FilterModelM.FilterColumnName + " ='" + FilterModelM.FilterColumnValue + "' ";
                }

                var cmd = new SqlCommand(query, Conn);
                dt.Load(cmd.ExecuteReader());
                Conn.Close();
            }
            catch (Exception ee)
            {
                dt.Columns.Add("Error", typeof(string));
                dt.Rows.Add(ee.ToString());
            }

            return dt;
        }
    }
}
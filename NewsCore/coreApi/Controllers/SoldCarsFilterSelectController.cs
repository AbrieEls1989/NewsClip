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
    public class SoldCarsFilterSelectController : ControllerBase
    {
        /// <summary>
        /// Inserts SoldCars.
        /// </summary>
        private readonly IConfiguration _configuration;
        public SoldCarsFilterSelectController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [SwaggerResponse(200, "The SoldCars was Selected", typeof(List<SoldCars>))]
        [SwaggerResponse(400, "The SoldCars data is invalid")]
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
                    query = "select * from SoldCars where " + FilterModelM.FilterColumnName + " ='" + FilterModelM.FilterColumnValue + "' ";
                }
                else
                {
                    query = "select  top(" + FilterModelM.maxRecordsCount + ") * from SoldCars where " + FilterModelM.FilterColumnName + " ='" + FilterModelM.FilterColumnValue + "' ";
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
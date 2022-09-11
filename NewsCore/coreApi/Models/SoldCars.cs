using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Api.Models;
using Microsoft.Extensions.Configuration;

namespace Api.Models
{
    public class SoldCars
    {
        public decimal Price
        {
            get;
            set;
        }

        public int Id
        {
            get;
            set;
        }

        public int ModelId
        {
            get;
            set;
        }

        public int QTY
        {
            get;
            set;
        }

        public int VehicleId
        {
            get;
            set;
        }

        public string ClientName
        {
            get;
            set;
        }

        public string errorMessage
        {
            get;
            set;
        }
    }
}
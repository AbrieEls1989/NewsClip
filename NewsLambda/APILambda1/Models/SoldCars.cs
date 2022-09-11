using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using APILambda.Models;

namespace APILambda.Models
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
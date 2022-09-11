using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using APILambda.Models;

namespace APILambda.Models
{
    public class Vehicles
    {
        public int Id
        {
            get;
            set;
        }

        public int QTY
        {
            get;
            set;
        }

        public string Make
        {
            get;
            set;
        }

        public string Model
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
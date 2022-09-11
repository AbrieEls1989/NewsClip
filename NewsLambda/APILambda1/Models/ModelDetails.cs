using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using APILambda.Models;

namespace APILambda.Models
{
    public class ModelDetails
    {
        public int Id
        {
            get;
            set;
        }

        public int Vehicleid
        {
            get;
            set;
        }

        public string Features
        {
            get;
            set;
        }

        public string ModelDescription
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
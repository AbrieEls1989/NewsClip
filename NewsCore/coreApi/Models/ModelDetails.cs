using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Api.Models;
using Microsoft.Extensions.Configuration;

namespace Api.Models
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
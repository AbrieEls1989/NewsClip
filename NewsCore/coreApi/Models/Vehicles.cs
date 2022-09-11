using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Api.Models;
using Microsoft.Extensions.Configuration;

namespace Api.Models
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
        public string img
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
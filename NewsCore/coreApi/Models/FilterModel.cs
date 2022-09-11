using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api.Models
{
    public class FilterModel
    {
        
        public string FilterColumnName
        {
            get;
            set;
        }

        public int maxRecordsCount
        {
            get;
            set;
        }

        public string FilterColumnValue
        {
            get;
            set;
        }

            
    }
}
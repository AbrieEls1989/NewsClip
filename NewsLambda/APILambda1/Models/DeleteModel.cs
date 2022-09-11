using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APILambda.Models
{
    public class DeleteModel
    {
        public int DeleteId
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
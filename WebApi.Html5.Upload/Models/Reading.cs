using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Html5.Upload.Models
{
    public class Reading
    {
        public DateTime Date { get; set; }
        public decimal Value { get; set; }
        public override string ToString()
        {
            return String.Format("Date: {0}; Value: {1}.", Date, Value);
        }
    }
}
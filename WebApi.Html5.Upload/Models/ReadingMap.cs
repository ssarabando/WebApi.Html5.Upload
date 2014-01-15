using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Html5.Upload.Models
{
    public class ReadingMap : CsvClassMap<Reading>
    {
        public override void CreateMap()
        {
            Map(m => m.Date).Index(0);
            Map(m => m.Value).Index(1);
        }
    }
}
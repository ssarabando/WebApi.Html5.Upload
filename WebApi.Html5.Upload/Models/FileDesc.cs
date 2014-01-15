using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebApi.Html5.Upload.Models
{
    [DataContract]
    public class FileDesc
    {
        [DataMember]
        public string name { get; set; }

        [DataMember]
        public string path { get; set; }

        [DataMember]
        public long size { get; set; }

        public FileDesc(string n, string p, long s)
        {
            name = n;
            path = p;
            size = s;
        }
    }
}
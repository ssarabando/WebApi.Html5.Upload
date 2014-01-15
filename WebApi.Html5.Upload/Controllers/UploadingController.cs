using CsvHelper;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using WebApi.Html5.Upload.Infrastructure;
using WebApi.Html5.Upload.Models;

namespace WebApi.Html5.Upload.Controllers
{
    public class UploadingController : ApiController
    {
        public void Post()
        {
            if (Request.Content.IsMimeMultipartContent()) {
                var streamProvider = new MultipartMemoryStreamProvider();
                Request.Content
                    .ReadAsMultipartAsync(streamProvider)
                    .ContinueWith(t => {
                        if (t.IsFaulted || t.IsCanceled) {
                            throw new HttpResponseException(HttpStatusCode.InternalServerError);
                        }
                        foreach (var item in streamProvider.Contents) {
                            var getContentTask = item.ReadAsStreamAsync();
                            var csvReader = new CsvReader(new StreamReader(getContentTask.Result));
                            csvReader.Configuration.CultureInfo = CultureInfo.CurrentCulture;
                            csvReader.Configuration.Delimiter = CultureInfo.CurrentCulture.TextInfo.ListSeparator;
                            csvReader.Configuration.RegisterClassMap<Models.ReadingMap>();
                            while (csvReader.Read()) {
                                Debug.WriteLine(csvReader.GetRecord<Models.Reading>());
                            }
                        }
                    });
            } else {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotAcceptable, "This request is not properly formatted"));
            }
        }
    }
}
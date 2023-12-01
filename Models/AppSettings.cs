using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentalService.Models
{
    public class AppSettings
    {
        public string WebAPIBaseUrl { get; set; }
        public string Secret { get; set; }
        public string HttpTimeOut { get; set; }
        public string WebFilePathUpload { get; set; }
        public string WebFilePathDownload { get; set; }
        public string EmailFlag { get; set; }
        public string NspsMailId { get; set; }
        public string WebPaymentFilePathUpload { get; set; }
        public string WebPaymentFilePathDownload { get; set; }
    }
}

using CarRentalService.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentalService.Controllers
{
    public class RentalServiceController : Controller
    {
        private AppSettings _options;
        private readonly IOptions<MailHelper> _mailoptions;
        private readonly IHostingEnvironment _hostingEnvironment;
        public RentalServiceController(IOptions<AppSettings> options, IHostingEnvironment hostingEnvironment, IOptions<MailHelper> mailoptions)
        {
            _options = options.Value;
            _hostingEnvironment = hostingEnvironment;
            _mailoptions = mailoptions;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Pricing()
        {
            return View();
        }
        public IActionResult Contactus()
        {
            return View();
        }

        public IActionResult SendMail()
        {
            try
            {

                string body = this.CreateEmailBody(true, "", "");
                SendHtmlFormattedEmail("", _options.NspsMailId, "Grievance Submitted Successfully || The Gambia Social Registry Information System (SRIS)", body);
            }
            catch (Exception ex)
            {
#pragma warning disable S112 // General exceptions should never be thrown
                throw new Exception(ex.Message);
            }
            return View();
        }
        private string CreateEmailBody(bool isProcess, string complainername, string ticketid)
        {
            string body = string.Empty;
            //using streamreader for reading my htmltemplate   

            //Get TemplateFile located at wwwroot/PartnerApprove.htm  
            var pathToFile = _hostingEnvironment.WebRootPath + Path.DirectorySeparatorChar.ToString() + "EmailContent/" + ("GrievanceStatusPage.html");
            using (StreamReader reader = new StreamReader(pathToFile))
            {
                body = reader.ReadToEnd();
            }
            body = body.Replace("{g_complainername}", complainername);
            body = body.Replace("{g_complainno}", ticketid);
            return body;
        }
        private void SendHtmlFormattedEmail(string ToMail, string ccMail, string subject, string body)
        {

            MailHelper mailHelper = new MailHelper();
            mailHelper.MailName = _mailoptions.Value.MailName.ToString();
            mailHelper.MailUserName = _mailoptions.Value.MailUserName.ToString();
            mailHelper.MailPassword = _mailoptions.Value.MailPassword.ToString();
            mailHelper.MailServer = _mailoptions.Value.MailServer.ToString();
            mailHelper.MailPort = _mailoptions.Value.MailPort;
            mailHelper.Sendgrievance(ToMail, ccMail, subject, body, "UTF-8", true, true);
        }
    }
}

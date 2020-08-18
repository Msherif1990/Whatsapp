using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Whatsaap.Controllers
{
    public class MessageStatusController : Controller
    {
        // GET: MessageStatus
        [HttpPost]
        public ActionResult Index()
        {
            var smsSid = Request.Form["SmsSid"];
            var messageStatus = Request.Form["MessageStatus"];
            var to = Request.Form["To"];
            var body = Request.Form["Body"];
            var errorMessage = Request.Form["ErrorMessage"];
            var logMessage = smsSid + "  " + messageStatus + "  " + to + "  " + errorMessage ;
            Trace.WriteLine(logMessage);
            return Content("Handled");
        }
    }
}
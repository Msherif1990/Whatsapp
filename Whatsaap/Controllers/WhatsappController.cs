﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Twilio;
using Twilio.AspNet.Common;
using Twilio.AspNet.Mvc;
using Twilio.Rest.Api.V2010.Account;
using Twilio.TwiML;

namespace Whatsaap.Controllers
{
    public class MessageObj
    {
        public string message;
        public string phone;
    }

    public class WhatsappController : ApiController
    {

        // POST api/<controller>
        [HttpPost]
        [Route("SendMessage")]
        public string SendMessage([FromBody] MessageObj messageObj)
        {
            TwilioClient.Init(
              ConfigurationManager.AppSettings["UserName"].ToString(),
              ConfigurationManager.AppSettings["Password"].ToString()
              );
            var response = MessageResource.Create(
                to: "whatsapp:" + messageObj.phone,
                from: "whatsapp:+14155238886",
                body: messageObj.message
                );
            return response.Sid;
        }


    }
}
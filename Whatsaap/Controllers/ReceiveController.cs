using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Twilio.AspNet.Common;
using Twilio.AspNet.Mvc;
using Twilio.TwiML;

namespace Whatsaap.Controllers
{
    public class ReceiveController : TwilioController
    {
        // GET: Receive
        [HttpPost]
        public TwiMLResult Index(SmsRequest incomingMessage)
        {
            var messagingResponse = new MessagingResponse();
            string reply = filterMessage(incomingMessage.Body);
            messagingResponse.Message(reply);

            return TwiML(messagingResponse);
        }

        private string filterMessage(string message)
        {
            string reply = "";

            if (message.ToLower().Contains("hi") || message.ToLower().Contains("hello"))
                return reply = "Hello, How can we help you";
            if (message.ToLower().Contains("problem") || message.ToLower().Contains("issue") || message.ToLower().Contains("remark"))
                return reply = "We are sorry you face this.. we will assist you ASAP";
            if (message.ToLower().Contains("enquiry") || message.ToLower().Contains("suggestion"))
                return reply = "One of our agent will assist you ASAP";

            return reply = "I didn't get your question ?!";
        }
    }
}
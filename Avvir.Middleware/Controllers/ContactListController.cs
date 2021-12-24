using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Avvir.DataLayer;

namespace Avvir.Middleware.Controllers
{
    public class ContactListController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage SendContactRequest(string token, string requestGUID)
        {
            var result = new HttpResponseMessage();

            return result;
        }

        [HttpPost]
        public HttpResponseMessage ApproveRequest(string token)
        {
            var result = new HttpResponseMessage();

            return result;
        }

        [HttpGet]
        public HttpResponseMessage GetContactList (string token)
        {
            var result = new HttpResponseMessage();

            return result;
        }
    }
}

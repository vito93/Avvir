using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Avvir.Middleware.Controllers
{
    public class AuthenticationController : ApiController
    {
        public HttpResponseMessage GetToken()
        {
            var result = new HttpResponseMessage();

            return result;
        }

        [HttpPost]
        public HttpResponseMessage RedeemToken()
        {
            var result = new HttpResponseMessage();

            return result;
        }
    }
}

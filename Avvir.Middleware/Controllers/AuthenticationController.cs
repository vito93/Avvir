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

        private static bool ValidateToken(string token, out string username)
        {
            username = null;

            var simplePrinciple = JwtManager.GetPrincipal(token);
            var identity = simplePrinciple.Identity as ClaimsIdentity;

            if (identity == null || !identity.IsAuthenticated)
                return false;

            var usernameClaim = identity.FindFirst(ClaimTypes.Name);
            username = usernameClaim?.Value;

            if (string.IsNullOrEmpty(username))
                return false;

            // More validate to check whether username exists in system

            return true;
        }

        protected Task<IPrincipal> AuthenticateJwtToken(string token)
        {
            string username;

            if (ValidateToken(token, out username))
            {
                // based on username to get more information from database 
                // in order to build local identity
                var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, username)
            // Add more claims if needed: Roles, ...
        };

                var identity = new ClaimsIdentity(claims, "Jwt");
                IPrincipal user = new ClaimsPrincipal(identity);

                return Task.FromResult(user);
            }

            return Task.FromResult<IPrincipal>(null);
        }
    }
}

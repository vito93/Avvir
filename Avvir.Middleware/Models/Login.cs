using System.Net.Http;
using System.Web.Http;

namespace Avvir.Middleware.Models
{
    public class LoginRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }

    }
    
    public class LoginResponse
    {
        public LoginResponse()
        {
            this.Token = "";
            this.responseMsg = new HttpResponseMessage() { StatusCode = System.Net.HttpStatusCode.Unauthorized };
        }

        public string Token { get; set; }
        public HttpResponseMessage responseMsg { get; set; }
    }
}
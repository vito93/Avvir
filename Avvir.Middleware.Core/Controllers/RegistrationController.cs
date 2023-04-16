using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Avvir.BusinessLogic;
using Avvir.BusinessLogic.Models;

namespace Avvir.Middleware.Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        [HttpPost]
        [Route("register")]
        public ActionResult Register([FromBody] RegisterModel input)
        {

            return Ok();
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Avvir.BusinessLogic;
using Avvir.BusinessLogic.Models;
using System;
using Avvir.BusinessLogic.Auth;

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
            try
            {
                var BPregister = new BusinessLogic.Auth.Register(input);

                if (BPregister.Result.Code == 0)
                    return Ok();
                else return StatusCode(500, new { Error = BPregister.Result.Message });
            }
            catch(Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }

        }
    }
}

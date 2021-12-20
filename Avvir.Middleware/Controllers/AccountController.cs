using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Avvir.DataLayer;
using System.Collections;

namespace Avvir.Middleware.Controllers
{
    public class AccountController : ApiController
    {
        [HttpPost]
        public void RegisterAccount()
        {
            var db = new AvvirModel();
            var account = new Account();

            //insert logic
            
        }

        [HttpPatch]
        public void UpdateAccount([FromUri] string UIN)
        {
            var db = new AvvirModel();
            var account = db.Account.FirstOrDefault(a => a.UIN == UIN);

            if (account != null)
            {
                //update logic
            }

        }
    }
}

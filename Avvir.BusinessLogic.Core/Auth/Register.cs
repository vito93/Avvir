using Avvir.BusinessLogic.Interfaces;
using Avvir.BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Avvir.DataLayer.Core;
using Avvir.BusinessLogic.Utils;
using Microsoft.EntityFrameworkCore;

namespace Avvir.BusinessLogic.Auth
{
    public class Register : ICallabaleBL
    {
        public IResult Result { get { return _result; } }
        private IResult _result;

        public RegisterModel Model { get { return _model; } }
        private RegisterModel _model;

        public Register(RegisterModel model)
        {
            _model = model;
            _result = new ProcessLogicResult();
            ProcessLogic();
        }
        public void ProcessLogic()
        {
            try
            {
                var hp = new HashPassword(_model.Password);

                if (hp.Result.Code == 0)
                {
                    using (var db = new AvvirContext())
                    {
                        // Duplicates by email
                        if (!db.Accounts.Any(a => a.Email == _model.Email))
                        {
                            db.Database.ExecuteSqlRaw("api.CreateUser @p0, @p1, @p2", parameters: new[] { _model.Name, hp.Hash, _model.Name });
                            _result.Message = "Ok";
                            _result.Code = 0;
                        }
                        else throw new Exception("Duplicate email");
                    }
                }
                else throw new Exception(hp.Result.Message);
            }
            catch (Exception ex)
            {
                _result.Code = 1;
                _result.Message = ex.Message;
            }
            finally
            {

            }
        }
    }
}

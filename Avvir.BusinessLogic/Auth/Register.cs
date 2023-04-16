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


namespace Avvir.BusinessLogic.Auth
{
    internal class Register : ICallabaleBL
    {
        public IResult Result { get; }
        private IResult _result;

        public RegisterModel Model { get; }
        private RegisterModel _model;

        public Register(RegisterModel model)
        {
            _model = model;
        }
        public void ProcessLogic()
        {
            try
            {
                var hp = new HashPassword(_model.Password);

                if (hp.Result.Code == 0)
                {
                    //using(var db = new )
                }
                else throw new Exception(hp.Result.Message);
            }
            catch (Exception ex)
            {
                //tba
            }
            finally
            {
                //tba
            }
        }
    }
}

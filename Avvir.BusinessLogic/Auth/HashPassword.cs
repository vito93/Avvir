using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Collections.Specialized;
using Avvir.BusinessLogic.Interfaces;
using Avvir.BusinessLogic.Utils;
using BcryptNet = BCrypt.Net.BCrypt;

namespace Avvir.BusinessLogic.Auth
{
    public class HashPassword : ICallabaleBL
    {
        public IResult Result { get { return _result; } }
        private IResult _result;

        public string Hash { get { return _hash; } }
        private string _hash;

        private string password;
        private readonly int defaultWorkCost = 11;
        private readonly BCrypt.Net.HashType defaultHashType = BCrypt.Net.HashType.SHA256;

        public HashPassword(string password)
        {
            this.password = password;
            _result = new ProcessLogicResult();
            ProcessLogic();
        }
        public void ProcessLogic()
        {
            try
            {
                // Set default BCryptSettings
                int workCost = defaultWorkCost;
                BCrypt.Net.HashType hashType = defaultHashType;
                int hashTypeConf;

                // Try to override default settings from App.config
                NameValueCollection bcryptSettings =
                ConfigurationManager.GetSection("BCryptConfig") as System.Collections.Specialized.NameValueCollection;

                if (bcryptSettings != null)
                {
                    Int32.TryParse(bcryptSettings["WorkCost"], out workCost);
                    Int32.TryParse(bcryptSettings["HashType"], out hashTypeConf);
                    hashType = (BCrypt.Net.HashType)hashTypeConf;
                }

                // Compute enhanced hash
                 _hash = BcryptNet.EnhancedHashPassword(this.password, hashType, workCost);

                _result.Message = "Ok";
                _result.Code = 0;
            }
            catch (Exception ex)
            {
                _result.Code = 1;
                _result.Message = ex.Message;
            }
            finally
            {
                //tba
            }
        }
    }
}

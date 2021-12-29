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
        public IResult Result { get; }
        private IResult _result;

        public string Hash { get { return _hash; } }
        private string _hash;

        private string password;
        private readonly int defaultWorkCost = 11;
        private readonly int defaultHashType = -1;

        public HashPassword(string password)
        {
            this.password = password;
            this.Result = new ProcessLogicResult();
        }
        public void ProcessLogic()
        {
            try
            {
                // Set default BCryptSettings
                int workCost = defaultWorkCost;
                int hashType = defaultHashType;

                // Try to override default settings from App.config
                NameValueCollection bcryptSettings =
                ConfigurationManager.GetSection("BCryptConfig") as System.Collections.Specialized.NameValueCollection;

                if (bcryptSettings != null)
                {
                    Int32.TryParse(bcryptSettings["WorkCost"], out workCost);
                    Int32.TryParse(bcryptSettings["HashType"], out hashType);
                }
                
                // Compute enhanced hash
                _hash = BcryptNet.EnhancedHashPassword(this.password, (BCrypt.Net.HashType)hashType, workCost);
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

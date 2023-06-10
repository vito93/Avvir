using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avvir.DataLayer.Database
{
    public partial class AvvirModel : DbContext
    {
        public AvvirModel(string connString) : base(connString)
        {
            
        }
    }
}

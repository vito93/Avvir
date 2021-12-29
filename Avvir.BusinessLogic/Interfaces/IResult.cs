using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avvir.BusinessLogic.Interfaces
{
    public interface IResult
    {
        string Message { get; }

        int Code { get; }
    }
}

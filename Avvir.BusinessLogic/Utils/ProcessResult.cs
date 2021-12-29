using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avvir.BusinessLogic.Interfaces;

namespace Avvir.BusinessLogic.Utils
{
    sealed class ProcessLogicResult : IResult
    {
        public string Message { get { return _message; } }
        private string _message;

        public int Code { get { return _code; } }
        private int _code;

        public ProcessLogicResult(string message, int code)
        {
            _message = message;
            _code = code;
        }

        public ProcessLogicResult() { }
    }
}

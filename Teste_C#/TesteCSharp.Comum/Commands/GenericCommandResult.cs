using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteCSharp.Comum.Commands
{
    public class GenericCommandResult : ICommandResult
    {

        public GenericCommandResult(bool success, string mensage, object data)
        {
            Success = success;
            Mensage = mensage;
            Data = data;
        }

        public bool Success { get; private set; }
        public string Mensage { get; private set; }
        public Object Data { get; private set; }
    }
}

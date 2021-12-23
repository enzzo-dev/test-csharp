using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteCSharp.Comum.Commands;

namespace TesteCSharp.Comum.Handlers.Contracts
{
    //<T> é um tipo de objeto genérico
    //where -> garante que este objeto genérico esteja herdando da interface ICommand
    public interface IHandler<T> where T : ICommand
    {
        ICommandResult Handler(T command);
    }
}

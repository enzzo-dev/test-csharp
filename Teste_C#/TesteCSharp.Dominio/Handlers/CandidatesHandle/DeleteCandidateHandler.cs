using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteCSharp.Comum.Commands;
using TesteCSharp.Comum.Handlers.Contracts;
using TesteCSharp.Dominio.Commands.Candidates;
using TesteCSharp.Dominio.Repositories;

namespace TesteCSharp.Dominio.Handlers.CandidatesHandle
{
    public class DeleteCandidateHandler : Notifiable<Notification>, IHandler<DeleteCandidateCommand>
    {
        private ICandidateRepository _candidateRepository;

        public DeleteCandidateHandler(ICandidateRepository candidatoRepository)
        {
            _candidateRepository = candidatoRepository;
        }


        public ICommandResult Handler(DeleteCandidateCommand command)
        {
            command.Validar();

            if (!command.IsValid)
            {
                return new GenericCommandResult
                (
                    false,
                    "Dados Incorretos!",
                    null
                );
            }

            var empresaBuscada = _candidateRepository.FindWithId(command.IdCandidate);

            if (empresaBuscada == null)
            {
                return new GenericCommandResult
                (
                    false,
                    "Candidato não encontrado!",
                    null
                );
            }

            _candidateRepository.Delete(empresaBuscada);

            return new GenericCommandResult(true, "Candidato excluído com sucesso!", null);
        }
    }
}

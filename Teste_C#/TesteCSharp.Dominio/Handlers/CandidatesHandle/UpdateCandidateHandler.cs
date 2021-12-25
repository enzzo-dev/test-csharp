using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteCSharp.Comum.Commands;
using TesteCSharp.Comum.Handlers.Contracts;
using TesteCSharp.Dominio.Commands.Candidates;
using TesteCSharp.Dominio.Entidades;
using TesteCSharp.Dominio.Repositories;

namespace TesteCSharp.Dominio.Handlers.CandidatesHandle
{
    public class UpdateCandidateHandler : Notifiable<Notification>, IHandler<UpdateCandidateCommand>
    {

        private ICandidateRepository _candidateRepository;

        public UpdateCandidateHandler(ICandidateRepository candidateRepository)
        {
            _candidateRepository = candidateRepository;
        }

        public ICommandResult Handler(UpdateCandidateCommand command)
        {
            command.Validar();

            if (!command.IsValid)
            {
                return new GenericCommandResult
                (
                    false,
                    "Há dados incorretos!",
                    command.Notifications
                );
            }

            var usuarioEncontrado = _candidateRepository.FindWithId(command.IdCandidate);

            if (usuarioEncontrado == null)
            {
                return new GenericCommandResult
                (
                    false,
                    "Usuário não encontrado para ser atualizado!",
                    usuarioEncontrado.Notifications
                );
            }

            //Realizamos a alteraçãom no command, para verificar os dados
            usuarioEncontrado.UpdateCandidate
            (
                command.Name,
                command.Surname,
                command.Birthdate
            );

            if (!usuarioEncontrado.IsValid)
            {
                return new GenericCommandResult
                (
                    false,
                    "Dados incorretos! Tente novamente! ",
                    null
                );
            }

            _candidateRepository.Update(usuarioEncontrado);

            return new GenericCommandResult(true, "Candidato atualizado com sucesso!", null);

        }
    }
}

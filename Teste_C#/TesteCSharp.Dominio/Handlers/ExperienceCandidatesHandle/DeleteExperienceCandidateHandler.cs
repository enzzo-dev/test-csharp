using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteCSharp.Comum.Commands;
using TesteCSharp.Comum.Handlers.Contracts;
using TesteCSharp.Dominio.Commands.CandidateExperience;
using TesteCSharp.Dominio.Repositories;

namespace TesteCSharp.Dominio.Handlers.ExperienceCandidatesHandle
{
    public class DeleteExperienceCandidateHandler : Notifiable<Notification>, IHandler<DeleteExperienceCommand>
    {

        private ICandidateExperienceRepository _candidateExperience;

        public DeleteExperienceCandidateHandler(ICandidateExperienceRepository candidateRepository)
        {
            _candidateExperience = candidateRepository;
        }
        public ICommandResult Handler(DeleteExperienceCommand command)
        {
            command.Validar();

            if (!command.IsValid)
            {
                return new GenericCommandResult
                (
                    false,
                    "Dados Incorretos! Tente Novamente!",
                    command.Notifications
                );
            }

            var experienceFinded = _candidateExperience.FindWithId(command.IdExperience);

            if(experienceFinded == null)
            {
                return new GenericCommandResult
                (
                    false,
                    "Experiência do usuário não encontrado!",
                    command.Notifications
                );
            }

            _candidateExperience.Delete(experienceFinded);

            return new GenericCommandResult(true, "Experiência deletada com sucesso!", null);
        }
    }
}

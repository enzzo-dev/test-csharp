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
    class UpdateExperienceCandidateHandler : Notifiable<Notification>, IHandler<UpdateExperienceCommand>
    {
        private ICandidateExperienceRepository _candidateExperience;

        public UpdateExperienceCandidateHandler(ICandidateExperienceRepository candidadeExperience)
        {
            _candidateExperience = candidadeExperience;
        }

        public ICommandResult Handler(UpdateExperienceCommand command)
        {
            command.Validar();

            if (!command.IsValid)
            {
                return new GenericCommandResult(false, "Dados Incorretos!", null);
            }

            var experienceBuscado = _candidateExperience.FindWithId(command.IdCandidateExperience);

            if(experienceBuscado == null)
            {
                return new GenericCommandResult(false, "Experiência do candidato não encontrado!", null);
            }

            experienceBuscado.A
        }
    }
}

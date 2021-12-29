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
    public class UpdateExperienceCandidateHandler : Notifiable<Notification>, IHandler<UpdateExperienceCommand>
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
                return new GenericCommandResult(false, "Dados Incorretos!", command.Notifications);
            }

            var experienceBuscado = _candidateExperience.FindWithId(command.Id);

            if(experienceBuscado == null)
            {
                return new GenericCommandResult(false, "Experiência do candidato não encontrada!", command.Notifications);
            }

            experienceBuscado.UpdateExperience
            (
                command.Company,
                command.Job,
                command.Description,
                command.Salary,
                command.BeginDate,
                command.EndDate,
                command.Id
            );

            if (!experienceBuscado.IsValid)
            {
                return new GenericCommandResult
                (
                    false,
                    "Dados incorretos! Tente novamente",
                    experienceBuscado.Notifications
                );
            }

            _candidateExperience.UpdateExperience(experienceBuscado);

            return new GenericCommandResult(true, "Experiência atualizada com sucesso!", null);

        }
    }
}

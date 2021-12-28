using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteCSharp.Comum.Commands;
using TesteCSharp.Comum.Handlers.Contracts;
using TesteCSharp.Domains.Entidades;
using TesteCSharp.Dominio.Commands.CandidateExperience;
using TesteCSharp.Dominio.Repositories;

namespace TesteCSharp.Dominio.Handlers.ExperienceCandidatesHandle
{
    public class RegisterExperienceCandidateHandler : Notifiable<Notification>, IHandler<RegisterExperienceCommand>
    {

        private ICandidateExperienceRepository _candidateExperience;

        public RegisterExperienceCandidateHandler(ICandidateExperienceRepository candidateRepository )
        {
            _candidateExperience = candidateRepository;
        }

        public ICommandResult Handler(RegisterExperienceCommand command)
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

            var experienceRegistered = _candidateExperience.FindWithNameCompany(command.Company);

            if(experienceRegistered != null)
            {
                return new GenericCommandResult
                (
                    false,
                    "Empresa já cadastrada nas experiências!",
                    command.Notifications
                );
            }

            CandidateExperience e1 = new CandidateExperience
            (

               command.Company,
               command.Job,
               command.Description,
               command.Salary,
               command.BeginDate,
               command.EndDate,
               command.IdCandidate

            );

            _candidateExperience.RegisterExperience(e1);

            return new GenericCommandResult(true, "Experiência do candidato cadastrada!", null);
        }
    }
}

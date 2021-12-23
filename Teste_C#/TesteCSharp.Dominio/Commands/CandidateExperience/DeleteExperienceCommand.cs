using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteCSharp.Comum.Commands;

namespace TesteCSharp.Dominio.Commands.CandidateExperience
{
    public class DeleteExperienceCommand : Notifiable<Notification>, ICommand
    {
        public DeleteExperienceCommand()
        {

        }

        public DeleteExperienceCommand(Guid idExperience)
        {
            IdExperience = idExperience;
        }

        public Guid IdExperience { get; set; }

        public void Validar()
        {
            AddNotifications(
             new Contract<Notification>()
             .Requires()
             .IsNotNull(IdExperience, "IdExperience", "Experience of candidate can't be null value!")
         );
        }
    }
}

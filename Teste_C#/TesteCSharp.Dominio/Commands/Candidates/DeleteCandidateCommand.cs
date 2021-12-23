using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteCSharp.Comum.Commands;

namespace TesteCSharp.Dominio.Commands.Candidates
{
    public class DeleteCandidateCommand : Notifiable<Notification>, ICommand
    {

        public DeleteCandidateCommand()
        {

        }

        public DeleteCandidateCommand(Guid idCandidate)
        {
            IdCandidate = idCandidate;
        }

        public Guid IdCandidate { get; set; }

        public void Validar()
        {
            AddNotifications(
                new Contract<Notification>()
                .Requires()
                .IsNotNull(IdCandidate, "IdCandidate", "Candidate cannot be empty!")
            );
        }
    }
}

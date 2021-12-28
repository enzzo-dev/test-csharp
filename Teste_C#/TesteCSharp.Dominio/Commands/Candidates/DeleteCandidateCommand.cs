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
            Id = idCandidate;
        }

        public Guid Id { get; set; }

        public void Validar()
        {
            AddNotifications(
                new Contract<Notification>()
                .Requires()
                .IsNotNull(Id, "IdCandidate", "Candidate cannot be empty!")
            );
        }
    }
}

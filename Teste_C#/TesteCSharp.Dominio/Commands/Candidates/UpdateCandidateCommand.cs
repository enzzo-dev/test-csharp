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
    public class UpdateCandidateCommand : Notifiable<Notification>, ICommand
    {

        public UpdateCandidateCommand()
        {

        }

        public UpdateCandidateCommand(Guid idCandidate, string name, string surname, DateTime birthdate, string email)
        {
            IdCandidate = idCandidate;
            Name = name;
            Surname = surname;
            Email = email;
            Birthdate = birthdate;
            ModifyDate = DateTime.Now;
        }

        public Guid IdCandidate { get; set; }

        public string Name { get; private set; }
        public string Surname { get; private set; }
        public DateTime Birthdate { get; private set; }
        public string Email { get; private set; }
        public DateTime ModifyDate { get; set; }

        public void Validar()
        {
            AddNotifications(
                   new Contract<Notification>()
                   .Requires()
                   .IsNotEmpty(Name, "Name", "Name could't be empty!")
                   .IsNotEmpty(Surname, "Surname", "Last name cannot be empty!")
                   .IsEmail(Email, "Email", "The email format is incorrect!")
                   .IsNotNull(Birthdate, "Birthdate", "The date of birth cannot be empty!")

               );
        }
    }
}

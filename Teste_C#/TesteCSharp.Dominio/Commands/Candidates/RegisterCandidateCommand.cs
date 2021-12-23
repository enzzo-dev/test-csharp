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
    public class RegisterCandidateCommand : Notifiable<Notification>, ICommand
    {

        public RegisterCandidateCommand()
        {

        }

        public RegisterCandidateCommand(string name, string surname, DateTime birthdate, string email)
        {
            Name = name;
            Surname = surname;
            Birthdate = birthdate;
            Email = email;
        }

        public string Name { get;  set; }
        public string Surname { get; set; }
        public DateTime Birthdate { get; set; }
        public string Email { get; set; }


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

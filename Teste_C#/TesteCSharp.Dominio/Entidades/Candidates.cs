using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteCSharp.Comum;
using TesteCSharp.Domains;

namespace TesteCSharp.Dominio.Entidades
{
   public class Candidates : Base
    {
        public Candidates(string name, string surname, DateTime birthdate, string email)
        {
            AddNotifications(
                new Contract<Notification>()
                .Requires()
                .IsNotEmpty(name, "Name", "Name could't be empty!")
                .IsNotEmpty(surname, "Surname", "Last name cannot be empty!")
                .IsEmail(email, "Email", "The email format is incorrect!")
                .IsNotNull(birthdate, "Birthdate", "The date of birth cannot be empty!")

            );

            Name = name;
            Surname = surname;
            Birthdate = birthdate;
            Email = email;
        }

        public string Name { get; private set; }
        public string Surname { get; private set; }
        public DateTime Birthdate { get; private set; }
        public string Email { get; private set; }
    }
}

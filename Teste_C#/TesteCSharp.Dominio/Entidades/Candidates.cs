using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteCSharp.Comum;
using TesteCSharp.Domains;
using TesteCSharp.Domains.Entidades;

namespace TesteCSharp.Dominio.Entidades
{
   public class Candidates : Base
    {
        public Candidates(string name, string surname, string email, DateTime birthdate)
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
            Email = email;
            Birthdate = birthdate;
            
        }

        public string Name { get; private set; }
        public string Surname { get; private set; }
        public DateTime Birthdate { get; private set; }
        public string Email { get; private set; }

        public DateTime ModifyDate { get; set; }

        //Compositions
        public IReadOnlyCollection<CandidateExperience> Experiences { get { return _experiences; } }

        //Para alterar as experiências dos candidatos, precisamos de uma lista de apoio

        private List<CandidateExperience> _experiences { get; set; }

        public void UpdateCandidate(string name, string surname, DateTime birthDate)
        {
            AddNotifications(
              new Contract<Notification>()
              .Requires()
              .IsNotEmpty(name, "Name", "Name could't be empty!")
              .IsNotEmpty(surname, "Surname", "Last name cannot be empty!")
              .IsNotNull(birthDate, "Birthdate", "The date of birth cannot be empty!")

          );

          
            if (IsValid)
            {
                Name = name;
                Surname = surname;
                Birthdate = birthDate;
            }
        }

        public void RegisterExperience(CandidateExperience experience)
        {
            if (IsValid)
            {
                _experiences.Add(experience);
            }      
      
        }
    }
}

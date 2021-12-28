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

        public Candidates(string name, string surname,DateTime birthdate, string email)
        {
            AddNotifications(
                new Contract<Notification>()
                .Requires()
                .IsNotEmpty(name, "Name", "Name could't be empty!")
                .IsNotEmpty(surname, "Surname", "Last name cannot be empty!")
                .IsNotNull(birthdate, "Birthdate", "The birth date could't be a null value")
                .IsEmail(email, "Email", "The email format is incorrect!")
                

            );

            Name = name;
            Surname = surname;
            Birthdate = birthdate;
            Email = email;
           
            
        }

        public string Name { get; private set; }
        public string Surname { get; private set; }
        public DateTime Birthdate { get; set; }
        public string Email { get; private set; }
        public DateTime ModifyDate { get; set; }

        //Compositions
        public IReadOnlyCollection<CandidateExperience> Experiences { get;  set; }

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
                ModifyDate = DateTime.Now;
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

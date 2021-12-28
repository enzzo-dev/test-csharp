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
    public class RegisterExperienceCommand : Notifiable<Notification>, ICommand
    {

        public RegisterExperienceCommand()
        {

        }

        public RegisterExperienceCommand(string company, string job, string description, decimal salary, DateTime beginDate, DateTime endDate, Guid idCandidate)
        {
            Company = company;
            Job = job;
            Description = description;
            Salary = salary;
            BeginDate = beginDate;
            EndDate = endDate;
            IdCandidate = idCandidate;
        }

        public string Company { get;  set; }
        public string Job { get;  set; }
        public string Description { get;  set; }
        public decimal Salary { get;  set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime ModifyDate { get; set; }
        public Guid IdCandidate { get; set; }


        public void Validar()
        {
            AddNotifications(
                new Contract<Notification>()
                .Requires()
                .IsNotEmpty(Company, "Company", "The company of candidate could't be empty!")
                .IsNotEmpty(Job, "Job", "The job of candidate could't be empty!")
                .IsNotEmpty(Description, "Description", "The description of job could't be empty!")
                .IsNotNull(Salary, "Salary", "The salary of candidate could't be a null value!")
                .IsNotNull(BeginDate, "BeginDate", "Begin Date could't be a null value!")
                .IsNotNull(EndDate, "EndDate", "End Date could't be a null value!")
                .IsNotNull(IdCandidate, "IdCandidate", "Candidate have to be specified!")
            );
        }
    }
}

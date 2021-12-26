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
    public class UpdateExperienceCommand : Notifiable<Notification>, ICommand
    {

        public UpdateExperienceCommand()
        {

        }

        public UpdateExperienceCommand(string company, string job, string description, decimal salary, DateTime beginDate, DateTime modifyDate)
        {
            Company = company;
            Job = job;
            Description = description;
            Salary = salary;
            BeginDate = beginDate;
            ModifyDate = DateTime.Now;
        }

        public string Company { get; private set; }
        public string Job { get; private set; }
        public string Description { get; private set; }
        public decimal  Salary { get; private set; }
        public DateTime BeginDate { get; private set; }
        public DateTime EndDate { get; set; }
        public DateTime ModifyDate { get; private set; }

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
            );
        }
    }
}

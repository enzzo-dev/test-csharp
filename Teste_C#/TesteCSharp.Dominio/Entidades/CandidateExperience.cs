using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using TesteCSharp.Comum;
using TesteCSharp.Dominio.Entidades;

namespace TesteCSharp.Domains.Entidades
{
    public class CandidateExperience : Base
    {

        public CandidateExperience(string company, string job, string description, decimal salary, DateTime beginDate, DateTime endDate, Guid idCandidate)
        {
            AddNotifications(
                new Contract<Notification>()
                .Requires()
                .IsNotEmpty(company, "Company", "The company of candidate could't be empty!")
                .IsNotEmpty(job, "Job", "The job of candidate could't be empty!")
                .IsNotEmpty(description, "Description", "The description of job could't be empty!")
                .IsNotNull(salary, "Salary", "The salary of candidate could't be a null value!")
                .IsNotNull(beginDate, "BeginDate", "Begin Date could't be a null value!")

                .IsNotNull(idCandidate, "IdCandidate", "Candidate have to be specified!")
            );

            Company = company;
            Job = job;
            Description = description;
            Salary = salary;
            BeginDate = beginDate;
            EndDate = endDate;
            IdCandidate = idCandidate;
        }

        public string Company { get; private set; }
        public string Job { get; private set; }
        public string Description { get; private set; }
        public decimal Salary { get; private set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime ModifyDate { get; set; }

        //Compositions
        [ForeignKey("Candidates")]
        public Guid IdCandidate { get; set; }
        public Candidates Candidates { get; set; }

        public void UpdateExperience(string company, string job, string description, decimal salary, DateTime beginDate, DateTime endDate, Guid IdExperience)
        {
            AddNotifications(
              new Contract<Notification>()
              .Requires()
              .IsNotEmpty(company, "Company", "Company could't be empty!")
              .IsNotEmpty(job, "Job", "Job cannot be empty!")
              .IsNotEmpty(description, "Description", "Description cannot be empty!")
              .IsNotNull(salary, "Salary", "Salary could't be null")
              .IsNotNull(beginDate, "BeginDate", "Begin date cannot be null")
              .IsNotNull(endDate, "EndDate", "End Date Can't be null")
              .IsNotNull(IdExperience, "EndDate", "End Date Can't be null")

          );


            if (IsValid)
            {
                Company = company;
                Job = job;
                Description = description;
                Salary = salary;
                BeginDate = beginDate;
                EndDate = endDate;
                Id = IdExperience;
                ModifyDate = DateTime.Now;
            }
        }
    }
}

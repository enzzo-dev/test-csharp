using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteCSharp.Domains.Entidades;
using TesteCSharp.Dominio.Entidades;

namespace TesteCSharp.InfraData.Contexts
{
    public class CSharpContext : DbContext
    {
        public CSharpContext(DbContextOptions<CSharpContext> options) : base(options)
        {

        }

        public DbSet<Candidates> Candidates { get; set; }
        public DbSet<CandidateExperience> CandidateExperience { get; set; }

        //Modelagem das tabelas

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Ignoramos que alib notificações do flunt seja gerada no banco
            modelBuilder.Ignore<Notification>();

            #region Mapeamento da tabela de candidatos

            modelBuilder.Entity<Candidates>().Property(x => x.Id);

            //Name
            modelBuilder.Entity<Candidates>().Property(x => x.Name).HasMaxLength(50);
            modelBuilder.Entity<Candidates>().Property(x => x.Name).HasColumnType("varchar(50)");
            modelBuilder.Entity<Candidates>().Property(x => x.Name).IsRequired();

            //Surname
            modelBuilder.Entity<Candidates>().Property(x => x.Surname).HasMaxLength(150);
            modelBuilder.Entity<Candidates>().Property(x => x.Surname).HasColumnType("varchar(150)");
            modelBuilder.Entity<Candidates>().Property(x => x.Surname).IsRequired();


            //BirthDate
            modelBuilder.Entity<Candidates>().Property(x => x.Birthdate).HasColumnType("DateTime");
            modelBuilder.Entity<Candidates>().Property(x => x.Birthdate).IsRequired();

            //Email
            modelBuilder.Entity<Candidates>().Property(x => x.Email).HasMaxLength(250);
            modelBuilder.Entity<Candidates>().Property(x => x.Email).HasColumnType("varchar(250)");
            modelBuilder.Entity<Candidates>().Property(x => x.Email).IsRequired();
            modelBuilder.Entity<Candidates>().HasIndex(u => u.Email).IsUnique();


            //ModifyDate
            modelBuilder.Entity<Candidates>().Property(x => x.ModifyDate).HasColumnType("DateTime");

            //InsertDate
            modelBuilder.Entity<Candidates>().Property(x => x.Data).HasColumnType("DateTime");
            #endregion

            #region Mapeamento da tabela de experiências dos candidatos

            //Id para recebimento
            modelBuilder.Entity<CandidateExperience>().Property(x => x.Id);

            //Company
            modelBuilder.Entity<CandidateExperience>().Property(x => x.Company).HasMaxLength(100);
            modelBuilder.Entity<CandidateExperience>().Property(x => x.Company).HasColumnType("varchar(100)");
            modelBuilder.Entity<CandidateExperience>().Property(x => x.Company).IsRequired();

            //Job
            modelBuilder.Entity<CandidateExperience>().Property(x => x.Job).HasMaxLength(100);
            modelBuilder.Entity<CandidateExperience>().Property(x => x.Job).HasColumnType("varchar(100)");
            modelBuilder.Entity<CandidateExperience>().Property(x => x.Job).IsRequired();

            //Description
            modelBuilder.Entity<CandidateExperience>().Property(x => x.Description).HasMaxLength(4000);
            modelBuilder.Entity<CandidateExperience>().Property(x => x.Description).HasColumnType("varchar(4000)");
            modelBuilder.Entity<CandidateExperience>().Property(x => x.Description).IsRequired();

            //Salary
            modelBuilder.Entity<CandidateExperience>().Property(x => x.Salary).HasColumnType("numeric(8, 2)");
            modelBuilder.Entity<CandidateExperience>().Property(x => x.Salary).IsRequired();

            //BeginDate
            modelBuilder.Entity<CandidateExperience>().Property(x => x.BeginDate).HasColumnType("DateTime");
            modelBuilder.Entity<CandidateExperience>().Property(x => x.BeginDate).IsRequired();

            //EndDate
            modelBuilder.Entity<CandidateExperience>().Property(x => x.EndDate).HasColumnType("DateTime");
            modelBuilder.Entity<CandidateExperience>().Property(x => x.EndDate).IsRequired();

            //ModifyDate
            modelBuilder.Entity<CandidateExperience>().Property(x => x.ModifyDate).HasColumnType("DateTime");

            //InsertDate
            modelBuilder.Entity<CandidateExperience>().Property(x => x.Data).HasColumnType("DateTime");

            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}

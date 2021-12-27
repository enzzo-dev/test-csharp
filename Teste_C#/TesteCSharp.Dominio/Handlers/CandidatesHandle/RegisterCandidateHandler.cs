using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteCSharp.Comum.Commands;
using TesteCSharp.Comum.Handlers.Contracts;
using TesteCSharp.Dominio.Commands.Candidates;
using TesteCSharp.Dominio.Entidades;
using TesteCSharp.Dominio.Repositories;

namespace TesteCSharp.Dominio.Handlers.CandidatesHandle
{
    public class RegisterCandidateHandler : Notifiable<Notification>, IHandler<RegisterCandidateCommand>
    {

        //Dependency Injection
        private ICandidateRepository _candidateRepository;

        public RegisterCandidateHandler(ICandidateRepository candidateRepository)
        {
            _candidateRepository = candidateRepository;
        }

        public ICommandResult Handler(RegisterCandidateCommand command)
        {

            //Validar o comando
            command.Validar();

            if (!command.IsValid)
            {
                return new GenericCommandResult
                    (
                    false,
                    "Enter the data correctly!",
                    command.Notifications
                    );
            }

            //verifica se o candidato com as mesmas infomações já foi inserido no sistema]
            var usuarioExiste = _candidateRepository.FindWithEmail(command.Email);

            if (usuarioExiste != null)
            {
                return new GenericCommandResult(false, "E-mail already registered", command.Notifications);

            }

          

            //Salvar no banco -> repository.RegisterCandidate();
            Candidates c1 = new Candidates
            (
                command.Name,
                command.Surname,
                command.Birthdate,
                command.Email
                
            );

            if (!c1.IsValid)
            {
                return new GenericCommandResult
                  (
                      false,
                      "Invalid Candidate Data!",
                      c1.Notifications
                  );
            }

            _candidateRepository.Register(c1);

            return new GenericCommandResult(true, "Candidate registered with success!", "Token");
        } 
    }
}

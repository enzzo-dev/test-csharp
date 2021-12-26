using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteCSharp.Dominio.Entidades;

namespace TesteCSharp.Dominio.Repositories
{
    public interface ICandidateRepository
    {

        /// <summary>
        /// Register a new Candidate in the system
        /// </summary>
        /// <param name="candidate"></param>
        void Register(Candidates candidate);

        /// <summary>
        /// Update a Candidate in the system
        /// </summary>
        void Update( Candidates candidateUpdated);

     
        /// Delete a Candidate
        /// </summary>
        void Delete(Candidates candidates);

        /// <summary>
        /// Find a candidate in the system with id
        /// </summary>
        Candidates FindWithId(Guid idCandidate);

        /// <summary>
        /// Find a candidate in the system with email
        /// </summary>
        Candidates FindWithEmail(string Email);

        /// <summary>
        /// List all candidates in the system
        /// </summary>
        public List<Candidates> BuscarTodos();


    }
}

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

        /// <summary>
        /// List all candidates in the system
        /// </summary>
        public ICollection<Candidates> ListAll();

        /// <summary>
        /// Delete a Candidate
        /// </summary>
        void Delete(Guid idCandidate);

        /// <summary>
        /// Find a candidate in the system with id
        /// </summary>
        Candidates FindWithId(Guid idCandidate);

        /// <summary>
        /// Find a candidate in the system with email
        /// </summary>
        Candidates FindWithEmail(string Email);


    }
}

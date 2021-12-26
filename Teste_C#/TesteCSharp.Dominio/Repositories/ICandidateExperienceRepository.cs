using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteCSharp.Domains.Entidades;

namespace TesteCSharp.Dominio.Repositories
{
   public interface ICandidateExperienceRepository
    {

        public List<CandidateExperience> BuscarTodos();

        void RegisterExperience(CandidateExperience newExperience);

        void UpdateExperience(CandidateExperience updateExperience);

        void Delete(CandidateExperience candidate);

        public CandidateExperience FindWithId(Guid IdCandidate);

        public CandidateExperience FindWithNameCandidate(string NameCandidate);

        public CandidateExperience FindWithNameCompany(string NameCompany);
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteCSharp.Domains.Entidades;
using TesteCSharp.Dominio.Repositories;
using TesteCSharp.InfraData.Contexts;

namespace TesteCSharp.InfraData.Repositories
{
    public class CandidateExperienceRepository : ICandidateExperienceRepository
    {

        private readonly CSharpContext _context;

        public CandidateExperienceRepository(CSharpContext context)
        {
            _context = context;
        }

        public List<CandidateExperience> BuscarTodos()
        {
            return _context.CandidateExperience.ToList();
        }

        public void Delete(CandidateExperience candidate)
        {
            _context.CandidateExperience.Remove(FindWithId(candidate.Id));
            _context.SaveChanges();
        }

        public CandidateExperience FindWithId(Guid IdCandidate)
        {
            return _context.CandidateExperience.FirstOrDefault(e => e.Id == IdCandidate);
        }

        public CandidateExperience FindWithNameCandidate(string NameCandidate)
        {
            return _context.CandidateExperience.FirstOrDefault(e => e.Candidates.Name == NameCandidate);
        }

        public CandidateExperience FindWithNameCompany(string NameCompany)
        {
            return _context.CandidateExperience.FirstOrDefault(e => e.Company == NameCompany);
        }

        public void RegisterExperience(CandidateExperience newExperience)
        {
            _context.CandidateExperience.Add(newExperience);
            _context.SaveChanges();
        }

        public void UpdateExperience(CandidateExperience updateExperience)
        {
            _context.Entry(updateExperience).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}

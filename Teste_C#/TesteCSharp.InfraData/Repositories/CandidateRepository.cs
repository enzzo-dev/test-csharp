using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteCSharp.Dominio.Entidades;
using TesteCSharp.Dominio.Repositories;
using TesteCSharp.InfraData.Contexts;

namespace TesteCSharp.InfraData.Repositories
{
   public class CandidateRepository : ICandidateRepository
    {

        //Dependency Injection
        private readonly CSharpContext _context;

        public CandidateRepository(CSharpContext ctx)
        {
            _context = ctx;
        }

        public List<Candidates> BuscarTodos()
        {
            return _context.Candidates.ToList();
        }

        public void Delete(Candidates candidates)
        {
            var userFinded = FindWithId(candidates.Id);

            _context.Candidates.Remove(userFinded);
            _context.SaveChanges();
        }

        public Candidates FindWithEmail(string email)
        {
            return _context.Candidates.FirstOrDefault(e => e.Email == email);
        }

        public Candidates FindWithId(Guid? idCandidate)
        {
            return _context.Candidates.FirstOrDefault(e => e.Id == idCandidate);
        }

        public void Register(Candidates candidate)
        {
            _context.Candidates.Add(candidate);
            _context.SaveChanges();
        }

        public void Update(Candidates candidateUpdated)
        {
            _context.Entry(candidateUpdated).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}

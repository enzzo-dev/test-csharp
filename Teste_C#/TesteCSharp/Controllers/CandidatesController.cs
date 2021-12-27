using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteCSharp.Comum.Commands;
using TesteCSharp.Dominio.Commands.CandidateExperience;
using TesteCSharp.Dominio.Commands.Candidates;
using TesteCSharp.Dominio.Entidades;
using TesteCSharp.Dominio.Handlers.CandidatesHandle;
using TesteCSharp.Dominio.Handlers.ExperienceCandidatesHandle;
using TesteCSharp.Dominio.Repositories;
using TesteCSharp.InfraData.Contexts;

namespace TesteCSharp.Controllers
{
    public class CandidatesController : Controller
    {
        private ICandidateRepository _candidateRepository;
        private readonly CSharpContext _context;

        public CandidatesController(CSharpContext context, ICandidateRepository candidateRepository)
        {
            _context = context;
            _candidateRepository = candidateRepository;
        }

        public async Task<IActionResult> Index()
        {
            return View( await ListCandidates());
        }

        public IActionResult RegisterCandidate()
        {
            return View();
        }

        public IActionResult Delete()
        {
            return View();
        }

        public async Task<IActionResult> DetailsCandidate(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidates = await _context.Candidates
                .FirstOrDefaultAsync(m => m.Id == id);
            if (candidates == null)
            {
                return NotFound();
            }

            ListExperiences(candidates.Id);

            return View(candidates);
        }




        //----------------------------------------------------------------------------------------------------------------------

        public void ListExperiences(Guid? idCandidate)
        {
            var experience =
                _context.CandidateExperience.ToList().Where(x => x.IdCandidate == idCandidate);

            if (experience != null)
            {
                ViewBag.Experiences = experience;
            }
        }

        public  async Task<List<Candidates>> ListCandidates()
        {
            return await _context.Candidates.ToListAsync();
        }

        [HttpPost]
        public GenericCommandResult CreateCandidate(RegisterCandidateCommand command, [FromServices] RegisterCandidateHandler handler)
        {
            return (GenericCommandResult)handler.Handler(command);
        }

        [HttpPatch]
        public GenericCommandResult UpdateCandidate(UpdateCandidateCommand command, [FromServices] UpdateCandidateHandler handler)
        {
            return (GenericCommandResult)handler.Handler(command);
        }

        [HttpDelete]
        public GenericCommandResult DeleteCandidate(DeleteCandidateCommand command, [FromServices] DeleteCandidateHandler handler)
        {
            return (GenericCommandResult)handler.Handler(command);
        }


        //Métodos do experience do candidato

        [HttpPost]
        public GenericCommandResult CreateExperience(RegisterExperienceCommand command, [FromServices] RegisterExperienceCandidateHandler handler)
        {
            return (GenericCommandResult)handler.Handler(command);

        }

        [HttpPatch]
        public GenericCommandResult UpdateExperience(UpdateExperienceCommand command, [FromServices] UpdateExperienceCandidateHandler handler)
        {
            return (GenericCommandResult)handler.Handler(command);
        }

        [HttpDelete]
        public GenericCommandResult DeleteExperience(DeleteExperienceCommand command, [FromServices] DeleteExperienceCandidateHandler handler)
        {
            return (GenericCommandResult)handler.Handler(command);
        }


        //Após os métodos criados, front-end deve ser tratado para fazer as requisições para os lugares certos
    }
}

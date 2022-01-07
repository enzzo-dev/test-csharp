using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteCSharp.Comum.Commands;
using TesteCSharp.Domains.Entidades;
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
        private ICandidateExperienceRepository _experienceRep;
        private readonly CSharpContext _context;

        public CandidatesController(CSharpContext context, ICandidateRepository candidateRepository, ICandidateExperienceRepository experienceRepository)
        {
            _context = context;
            _candidateRepository = candidateRepository;
            _experienceRep = experienceRepository;
        }

        public async Task<IActionResult> Index()
        {
            return View( await ListCandidates());
        }

        public IActionResult RegisterCandidate()
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


            List<CandidateExperience> experience =  _experienceRep.ListById(candidates.Id);

            if(experience != null)
            {
                ViewBag.Experiences = experience;
            }

            return View(candidates);
        }

        public IActionResult DeleteCandidate(Guid? Id)
        {
            var userFinded = _candidateRepository.FindWithId(Id);

            if(userFinded != null)
            {
                _candidateRepository.Delete(userFinded);
            }

            return LocalRedirect("~/Candidates/Index/");
        }



        //----------------------------------------------------------------------------------------------------------------------



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


        //Métodos do experience do candidato

        //----------------------------------------------------------------------------------------------------------------------

        public async Task<IActionResult> DetailsExperience(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var experiences = await _context.CandidateExperience
                .FirstOrDefaultAsync(m => m.Id == id);
            if (experiences == null)
            {
                return NotFound();
            }

            return View(experiences);
        }

        public async Task<IEnumerable<Candidates>> FindCandidates(string name)
        {
           
            var experiences = await _context.Candidates
                .Where(x => EF.Functions.Like(x.Name, name)).ToListAsync();

            return experiences;
        }

        public IActionResult DeleteExperience(Guid? Id)
        {
            var experienceFinded = _experienceRep.FindWithId(Id);

            if(experienceFinded != null)
            {
                _experienceRep.Delete(experienceFinded);
            }

            return LocalRedirect("~/Candidates/DetailsCandidate/" + experienceFinded.IdCandidate);
        }
            
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


        //Após os métodos criados, front-end deve ser tratado para fazer as requisições para os lugares certos
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteCSharp.Domains.Entidades;

namespace TesteCSharp.Models
{
    public class CandidatesViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthdate { get; set; }
        public string Email { get; set; }
        public DateTime ModifyDate { get; set; }
        public DateTime Data { get; set; }

        private IReadOnlyCollection<CandidateExperience> Experiences { get { return _experiences; } }

        //Para alterar as experiências dos candidatos, precisamos de uma lista de apoio

        public List<CandidateExperience> _experiences { get; set; }
    }
}

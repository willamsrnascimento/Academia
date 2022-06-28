using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public class ProfessorRepository : GenericRepository<Professor>, IProfessorRepository
    {
        private readonly AcademiaContext _academiaContext;

        public ProfessorRepository(AcademiaContext academiaContext) : base(academiaContext)
        {
            _academiaContext = academiaContext;
        }

        public async Task<bool> ProfessorExiste(string nome)
        {
            return await _academiaContext.Professores.AnyAsync(p => p.Nome == nome);
        }

        public async Task<bool> ProfessorExiste(string nome, int id)
        {
            return await _academiaContext.Professores.AnyAsync(p => p.Nome == nome && p.Id != id);
        }
    }
}

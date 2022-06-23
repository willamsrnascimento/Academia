using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public class ExercicioRepository : GenericRepository<Exercicio>, IExercicioRepository
    {
        private readonly AcademiaContext _context;

        public ExercicioRepository(AcademiaContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> ExercicioExiste(string nome)
        {
            return await _context.Exercicios.AnyAsync(e => e.Nome == nome);
        }

        public async Task<bool> ExercicioExiste(string nome, int exercicioId)
        {
            return await _context.Exercicios.AnyAsync(e => e.Nome == nome && e.Id == exercicioId);
        }

        public new async Task<IEnumerable<Exercicio>> PegarTodos()
        {
            return await _context.Exercicios.Include(e => e.CategoriaExercicio).ToListAsync();
        }
    }
}

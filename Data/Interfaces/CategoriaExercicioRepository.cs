using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public class CategoriaExercicioRepository : GenericRepository<CategoriaExercicio>, ICategoriaExercicioRepository
    {
        private readonly AcademiaContext _context;
        public CategoriaExercicioRepository(AcademiaContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> CategoriaExiste(string categoria)
        {
            return await _context.CategoriaExercicios.AnyAsync(ce => ce.Nome == categoria);
        }

        public async Task<bool> CategoriaExiste(string categoria, int categoriaExercicioId)
        {
            return await _context.CategoriaExercicios.AnyAsync(ce => ce.Nome == categoria && ce.Id != categoriaExercicioId);
        }
    }
}

using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public class ListaExercicioRepository : GenericRepository<ListaExercicio>, IListaExercicioRepository
    {
        private readonly AcademiaContext _academiaContext;

        public ListaExercicioRepository(AcademiaContext academiaContext) : base(academiaContext)
        {
            _academiaContext = academiaContext;
        }

        public async Task<bool> ExercicioExisteNaFicha(int id, int fichaId)
        {
            return await _academiaContext.ListaExercicios.AnyAsync(l => l.ExercicioId == id && l.FichaId == fichaId);
        }
    }
}

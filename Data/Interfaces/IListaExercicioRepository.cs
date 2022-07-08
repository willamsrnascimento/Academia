using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IListaExercicioRepository : IGenericRepository<ListaExercicio>
    {
        Task<bool> ExercicioExisteNaFicha(int id, int fichaId);
    }
}

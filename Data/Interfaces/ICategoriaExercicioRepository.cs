using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface ICategoriaExercicioRepository : IGenericRepository<CategoriaExercicio>
    {
        Task<bool> CategoriaExiste(string categoria);
        Task<bool> CategoriaExiste(string categoria, int categoriaExercicioId);
    }
}

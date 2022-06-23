using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IExercicioRepository : IGenericRepository<Exercicio>
    {
        new Task<IEnumerable<Exercicio>> PegarTodos();
        Task<bool> ExercicioExiste(string nome);
        Task<bool> ExercicioExiste(string nome, int exercicioId);
    }
}

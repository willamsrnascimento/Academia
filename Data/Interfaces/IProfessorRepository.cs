using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IProfessorRepository : IGenericRepository<Professor>
    {
        Task<bool> ProfessorExiste(string nome);
        Task<bool> ProfessorExiste(string nome, int id);
    }
}

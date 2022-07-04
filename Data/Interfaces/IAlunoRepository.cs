using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IAlunoRepository : IGenericRepository<Aluno>
    {
        new Task<IEnumerable<Aluno>> PegarTodos();
        Task<Aluno> PegarDadosAlunoPeloId(int id);
        Task<string> PegaNomeAlunoId(int id);
        Task<bool> AlunoExiste(string nome);
        Task<bool> AlunoExiste(string nome, int id);
    }
}

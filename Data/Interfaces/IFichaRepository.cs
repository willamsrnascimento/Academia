using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IFichaRepository : IGenericRepository<Ficha>
    {
        Task<IEnumerable<Ficha>> PegarTodasFichasPeloAlunoId(int id);
        Task<Ficha> PegarFichaPeloAlunoId(int id);
        Task<bool> FichaExiste(string nome);
        Task<bool> FichaExiste(string nome, int id);
    }
}

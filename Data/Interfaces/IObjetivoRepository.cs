using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IObjetivoRepository : IGenericRepository<Objetivo>
    {
        Task<bool> ObjetivoExiste(string nome);
        Task<bool> ObjetivoExiste(string nome, int id);
    }
}

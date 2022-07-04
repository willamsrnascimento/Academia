using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public class ObjetivoRepository : GenericRepository<Objetivo>, IObjetivoRepository
    {
        private readonly AcademiaContext _academiaContext;

        public ObjetivoRepository(AcademiaContext academiaContext) : base(academiaContext)
        {
            _academiaContext = academiaContext;
        }

        public async Task<bool> ObjetivoExiste(string nome)
        {
            return await _academiaContext.Objetivos.AnyAsync(o => o.Nome == nome);
        }

        public async Task<bool> ObjetivoExiste(string nome, int id)
        {
            return await _academiaContext.Objetivos.AnyAsync(o => o.Nome == nome && o.Id != id);
        }
    }
}

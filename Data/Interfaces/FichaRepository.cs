using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public class FichaRepository : GenericRepository<Ficha>, IFichaRepository
    {
        private readonly AcademiaContext _academiaContext;

        public FichaRepository(AcademiaContext academiaContext) : base(academiaContext)
        {
            _academiaContext = academiaContext;
        }

        public async Task<bool> FichaExiste(string nome)
        {
            return await _academiaContext.Fichas.AnyAsync(f => f.Nome == nome);
        }

        public async Task<bool> FichaExiste(string nome, int id)
        {
            return await _academiaContext.Fichas.AnyAsync(f => f.Nome == nome && f.Id != id);
        }

        public async Task<Ficha> PegarFichaAlunoPeloId(int id)
        {
            return await _academiaContext.Fichas.Include(f => f.Aluno).FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<IEnumerable<Ficha>> PegarTodasFichasPeloAlunoId(int id)
        {
            return await _academiaContext.Fichas.Include(f => f.Aluno).ThenInclude(f => f.Objetivo).Where(f => f.AlunoId == id).ToListAsync();
        }
    }
}

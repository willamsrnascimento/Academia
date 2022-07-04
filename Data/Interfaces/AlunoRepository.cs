using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public class AlunoRepository : GenericRepository<Aluno>, IAlunoRepository
    {
        private readonly AcademiaContext _academiaContext;
        public AlunoRepository(AcademiaContext academiaContext) : base(academiaContext)
        {
            _academiaContext = academiaContext;
        }

        public async Task<bool> AlunoExiste(string nome)
        {
            return await _academiaContext.Alunos.AnyAsync(a => a.NomeCompleto == nome);
        }

        public async Task<bool> AlunoExiste(string nome, int id)
        {
            return await _academiaContext.Alunos.AnyAsync(a => a.NomeCompleto == nome && a.Id != id);
        }

        public async Task<Aluno> PegarDadosAlunoPeloId(int id)
        {
            return await _academiaContext.Alunos.Include(a => a.Objetivo).Include(a => a.Professor).Where(a => a.Id == id).FirstAsync();
        }

        public async Task<string> PegaNomeAlunoId(int id)
        {
            return await _academiaContext.Alunos.Where(a => a.Id == id).Select(a => a.NomeCompleto).FirstAsync();
        }

        public new async Task<IEnumerable<Aluno>> PegarTodos()
        {
            return await _academiaContext.Alunos.Include(a => a.Objetivo).Include(a => a.Professor).ToListAsync();
        }
    }
}

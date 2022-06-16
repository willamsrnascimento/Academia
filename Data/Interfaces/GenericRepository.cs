using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly AcademiaContext _context;

        public GenericRepository(AcademiaContext context)
        {
            _context = context;
        }

        public async Task Atualizar(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Exclir(int id)
        {
            var entity = await this.PegarPorIdAsync(id);
            _context.Set<TEntity>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Inserir(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<TEntity> PegarPorIdAsync(int id)
        {
           return await _context.Set<TEntity>().FindAsync(id);
        }

        public IQueryable<TEntity> PegarTodos()
        {
            return _context.Set<TEntity>();
        }
    }
}

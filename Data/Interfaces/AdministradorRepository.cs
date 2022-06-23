using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Interfaces
{
    public class AdministradorRepository : GenericRepository<Administrador>, IAdministradorRepository
    {
        private readonly AcademiaContext _context;

        public AdministradorRepository(AcademiaContext context) : base(context)
        {
            _context = context;
        }

        public bool AdministradorExiste(string email, string senha)
        {
            return _context.Administradores.Any(a => a.Email == email && a.Senha == senha);
        }
    }
}

using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Interfaces
{
    public interface IAdministradorRepository : IGenericRepository<Administrador>
    {
        bool AdministradorExiste(string email, string senha);
    }
}

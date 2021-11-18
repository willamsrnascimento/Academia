using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class AcademiaContext : DbContext
    {
        public AcademiaContext(DbContextOptions<AcademiaContext> options) : base(options)
        {

        }
    }
}

using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mappings
{
    public class AdministradorMapping : IEntityTypeConfiguration<Administrador>
    {
        public void Configure(EntityTypeBuilder<Administrador> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Nome).IsRequired();
            builder.Property(a => a.Email).IsRequired();
            builder.Property(a => a.Senha).IsRequired();

            builder.ToTable("Administradores");
        }
    }
}

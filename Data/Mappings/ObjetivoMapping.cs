using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mappings
{
    public class ObjetivoMapping : IEntityTypeConfiguration<Objetivo>
    {
        public void Configure(EntityTypeBuilder<Objetivo> builder)
        {
            builder.HasKey(o => o.Id);

            builder.Property(o => o.Nome).HasMaxLength(50).IsRequired();
            builder.Property(o => o.Descricao).HasMaxLength(300).IsRequired();

            builder.HasMany(o => o.Alunos).WithOne(a => a.Objetivo);

            builder.ToTable("Objetivos");
        }
    }
}

using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Mappings
{
    public class ProfessorMapping : IEntityTypeConfiguration<Professor>
    {
        public void Configure(EntityTypeBuilder<Professor> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome).HasMaxLength(50).IsRequired();
            builder.Property(p => p.Turno).HasMaxLength(15).IsRequired();
            builder.Property(p => p.Foto).IsRequired();
            builder.Property(p => p.Telefone).IsRequired();

            builder.HasMany(p => p.Alunos).WithOne(a => a.Professor);

            builder.ToTable("Professores");
        }
    }
}

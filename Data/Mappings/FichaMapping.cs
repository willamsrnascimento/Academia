using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Mappings
{
    public class FichaMapping : IEntityTypeConfiguration<Ficha>
    {
        public void Configure(EntityTypeBuilder<Ficha> builder)
        {
            builder.HasKey(f => f.Id);

            builder.Property(f => f.Nome).HasMaxLength(50).IsRequired();
            builder.Property(f => f.DataCadastro).IsRequired();
            builder.Property(f => f.DataValidade).IsRequired();

            builder.HasOne(f => f.Aluno).WithMany(a => a.Fichas).HasForeignKey(f => f.AlunoId);
            builder.HasMany(f => f.ListaExercicios).WithOne(le => le.Ficha).OnDelete(DeleteBehavior.Cascade);

            builder.ToTable("Fichas");
        }
    }
}

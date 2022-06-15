using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mappings
{
    public class AlunoMapping : IEntityTypeConfiguration<Aluno>
    {
        public void Configure(EntityTypeBuilder<Aluno> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.NomeCompleto).HasMaxLength(250).IsRequired();
            builder.Property(a => a.Idade).IsRequired();
            builder.Property(a => a.Peso).IsRequired();
            builder.Property(a => a.FrequenciaSemanal).IsRequired();

            builder.HasOne(a => a.Objetivo).WithMany(o => o.Alunos).HasForeignKey(a => a.ObjetivoId);
            builder.HasOne(a => a.Professor).WithMany(p => p.Alunos).HasForeignKey(a => a.ProfessorId);

            builder.HasMany(a => a.Fichas).WithOne(f => f.Aluno).OnDelete(DeleteBehavior.Cascade);

            builder.ToTable("Alunos");
        }
    }
}

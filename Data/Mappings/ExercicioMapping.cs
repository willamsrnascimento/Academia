using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mappings
{
    public class ExercicioMapping : IEntityTypeConfiguration<Exercicio>
    {
        public void Configure(EntityTypeBuilder<Exercicio> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Nome).HasMaxLength(50).IsRequired();

            builder.HasOne(e => e.CategoriaExercicio).WithMany(ce => ce.Exercicios).HasForeignKey(e => e.CategoriaExercicioId);
            builder.HasMany(e => e.ListaExercicios).WithOne(e => e.Exercicio);

            builder.ToTable("Exercicios");

        }
    }
}

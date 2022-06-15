using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mappings
{
    public class CategoriaExercicioMapping : IEntityTypeConfiguration<CategoriaExercicio>
    {
        public void Configure(EntityTypeBuilder<CategoriaExercicio> builder)
        {
            builder.HasKey(ce => ce.Id);

            builder.Property(ce => ce.Nome).HasMaxLength(50).IsRequired();

            builder.HasMany(ce => ce.Exercicios).WithOne(e => e.CategoriaExercicio).OnDelete(DeleteBehavior.Cascade);

            builder.ToTable("CategoriasExercicios");
        }
    }
}

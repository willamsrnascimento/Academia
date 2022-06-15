using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mappings
{
    public class ListaExercicioMapping : IEntityTypeConfiguration<ListaExercicio>
    {
        public void Configure(EntityTypeBuilder<ListaExercicio> builder)
        {
            builder.HasKey(le => le.Id);

            builder.Property(le => le.Frequencia).IsRequired();
            builder.Property(le => le.Repeticoes).IsRequired();
            builder.Property(le => le.Carga).IsRequired();

            builder.HasOne(le => le.Exercicio).WithMany(e => e.ListaExercicios).HasForeignKey(le => le.ExercicioId);
            builder.HasOne(le => le.Ficha).WithMany(f => f.ListaExercicios).HasForeignKey(le => le.FichaId);

            builder.ToTable("ListasExercicios");
        }

    }
}

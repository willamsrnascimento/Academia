using Data.Mappings;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class AcademiaContext : DbContext
    {
        public DbSet<Administrador> Administradores { get; set; }
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<CategoriaExercicio> CategoriaExercicios { get; set; }
        public DbSet<Exercicio> Exercicios { get; set; }
        public DbSet<Ficha> Fichas { get; set; }
        public DbSet<ListaExercicio> ListaExercicios { get; set; }
        public DbSet<Objetivo> Objetivos { get; set; }
        public DbSet<Professor> Professores { get; set; }

        public AcademiaContext(DbContextOptions<AcademiaContext> options) : base(options)
        {
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AdministradorMapping());
            modelBuilder.ApplyConfiguration(new AlunoMapping());
            modelBuilder.ApplyConfiguration(new CategoriaExercicioMapping());
            modelBuilder.ApplyConfiguration(new ExercicioMapping());
            modelBuilder.ApplyConfiguration(new FichaMapping());
            modelBuilder.ApplyConfiguration(new ListaExercicioMapping());
            modelBuilder.ApplyConfiguration(new ObjetivoMapping());
            modelBuilder.ApplyConfiguration(new ProfessorMapping());
        }
    }
}

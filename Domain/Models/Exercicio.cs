using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Exercicio
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [StringLength(50, ErrorMessage = "Use menos caracteres")]
        [Remote("ExercicioExiste", "Exercicios", AdditionalFields = "Id")]
        public string Nome { get; set; }

        public int CategoriaExercicioId { get; set; }

        public CategoriaExercicio CategoriaExercicio { get; set; }

        public ICollection<ListaExercicio> ListaExercicios { get; set; }
    }
}
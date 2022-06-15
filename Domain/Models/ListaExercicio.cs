using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class ListaExercicio
    {
        public int Id { get; set; }
        
        public int  ExercicioId { get; set; }

        public Exercicio Exercicio { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [Range(1, 7, ErrorMessage = "Frequência inválida.")]
        public int Frequencia { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [Range(1, 100, ErrorMessage = "Número inválido.")]
        public int Repeticoes { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [Range(1, 200, ErrorMessage = "Número inválido.")]
        public int Carga { get; set; }

        public int FichaId { get; set; }

        public Ficha Ficha { get; set; }

    }
}
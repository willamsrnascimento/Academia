using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Aluno
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [StringLength(100, ErrorMessage = "Use menos caracteres.")]

        public string NomeCompleto { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [Range(10, 150, ErrorMessage = "Idade inválida.")]
        public int Idade { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [Range(10, 150, ErrorMessage = "Peso inválida.")]
        public double Peso { get; set; }

        public int ProfessorId { get; set; }

        public Professor Professor { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [Range(1, 7, ErrorMessage = "Frequência inválida.")]
        public int FrequenciaSemanal { get; set; }

        public ICollection<Ficha> Fichas { get; set; }

        public int ObjetivoId { get; set; }

        public Objetivo Objetivo { get; set; }
    }
}
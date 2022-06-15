using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Ficha
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [StringLength(50, ErrorMessage = "Use menos caracteres.")]
        public string Nome { get; set; }

        public DateTime DataCadastro { get; set; }

        public DateTime DataValidade { get; set; }

        public int AlunoId { get; set; }

        public Aluno Aluno { get; set; }

        public ICollection<ListaExercicio> ListaExercicios { get; set; }
    }
}
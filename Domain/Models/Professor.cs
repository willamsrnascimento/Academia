using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Models
{
    public class Professor
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [StringLength(50, ErrorMessage = "Use menos caracteres.")]
        [Remote("ProfessorExiste", "Professores", AdditionalFields = "Id")]
        public string Nome { get; set; }

        public string Foto { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [StringLength(10, ErrorMessage = "Use menos caracteres.")]
        public string Turno { get; set; }

        public ICollection<Aluno> Alunos { get; set; }
    }
}

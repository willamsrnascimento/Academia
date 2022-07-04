using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Models
{
    public class Objetivo
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [StringLength(50, ErrorMessage = "Use menos caracteres.")]
        [Remote("ObjetivoExiste", "Objetivos", AdditionalFields = "Id")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [StringLength(500, ErrorMessage = "Use menos caracteres.")]
        [DataType(DataType.MultilineText)]
        public string Descricao { get; set; }

        public ICollection<Aluno> Alunos { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace Academia.ViewModels
{
    public class AdministradorViewModel
    {
        [Required(ErrorMessage = "Campo Obrigatório.")]
        [EmailAddress(ErrorMessage = "E-mail inválido.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório.")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
    }
}

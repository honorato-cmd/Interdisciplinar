using System.ComponentModel.DataAnnotations;

namespace Pato.Models
{
    public class UsuarioViewModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Login { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MinLength(4)]
        public string Senha { get; set; }

        public bool logado;
    }
}

using SisMed.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace SisMed.WebUI.ViewModel
{
    public class UsuarioViewModel
    {
        [Key]
        public string Id { get; set; }

        [Required(ErrorMessage = "Preencha o campo email")]
        [MaxLength(150, ErrorMessage = "Máximo de {0} caracteres")]
        [EmailAddress(ErrorMessage = "Preencha um email válido")]
        public string Email { get; set; }

        [MaxLength(150, ErrorMessage = "Máximo de {0} caracteres")]
        [MinLength(6, ErrorMessage = "Minimo de {0} caracteres")]
        [DataType(DataType.Password)]
        public string PasswordHash { get; set; }
    }
}

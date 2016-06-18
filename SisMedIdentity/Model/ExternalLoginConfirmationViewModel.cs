using System.ComponentModel.DataAnnotations;

namespace SisMedIdentity.Model
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
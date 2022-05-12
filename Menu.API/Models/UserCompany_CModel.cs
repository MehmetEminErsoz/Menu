using System.ComponentModel.DataAnnotations;

namespace Menu.API.Models
{
    public class UserCompany_CModel
    {
        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public int idCompany { get; set; }

        public int idRole { get; set; }

    }
}

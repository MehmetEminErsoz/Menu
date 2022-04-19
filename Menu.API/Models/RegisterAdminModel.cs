using JWTAuthentication.NET6._0.Auth;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Menu.API.Models
{
    public class RegisterAdminModel : RegisterModel
    {
        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }


        public string? Name { get; set; }

        public string? Surname { get; set; }



        [Column(TypeName = "date")]
        public DateTime? Birthday { get; set; }
        public string PhoneNumber { get; set; }

        public string? PasswordQuestion { get; set; }
        public string? PasswordAnswer { get; set; }

        [EmailAddress]
        public string? SecondEmail { get; set; }

    }
}

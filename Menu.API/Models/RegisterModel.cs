using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JWTAuthentication.NET6._0.Auth
{
    public class RegisterModel
    {
        //[Required(ErrorMessage = "User Name is required")]
        //public string? Username { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }

        
        public string? Name { get; set; }

        public string? Surname { get; set; }

        

        [Column(TypeName ="date")]
        public DateTime? Birthday { get; set; }
        public string PhoneNumber { get; set; }
    }
}
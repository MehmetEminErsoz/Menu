using System.ComponentModel.DataAnnotations;

namespace Menu.API.Models
{
    public class mailModel
    {
        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string? Email { get; set; }
    }
}

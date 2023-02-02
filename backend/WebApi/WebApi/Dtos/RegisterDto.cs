using System.ComponentModel.DataAnnotations;

namespace WebApi.ViewModels
{
    public class RegisterDto
    {
        [Required(ErrorMessage = "Email not indicated")]
        [EmailAddress(ErrorMessage = "Invalid format")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Password not indicated")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords not match")]
        public string? ConfirmPassword { get; set; }

        public string? Name { get; set; }

        public string? LastName { get; set; }

        [Phone(ErrorMessage = "Invalid format")]
        public string? PhoneNumber { get; set; }
    }
}

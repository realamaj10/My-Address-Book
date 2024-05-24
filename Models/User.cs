using System.ComponentModel.DataAnnotations;

namespace address_bk.Models
{
    public class User
    {
        [Required]
        [DataType(DataType.Text)]
        public string? Name { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string? EmailAddr { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Password and Confirm Password are not matching")]
        public string? ConfirmPassword { get; set; }

        [Required]
        public bool IsAdmin { get; set; }
    }
}

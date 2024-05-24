using System.ComponentModel.DataAnnotations;

namespace address_bk.Models
{
    public class Auth
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string? UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

    }
}

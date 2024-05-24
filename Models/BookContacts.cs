using System.ComponentModel.DataAnnotations;

namespace address_bk.Models
{
    public class BookContacts
    {
        [Key]
        public int? Id { get; set; }

        [Required]
        public string? FirstName { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string? LastName { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string? FatherName { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string? MotherName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string? EmailAddr { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string? AddrLine1 { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string? AddrLine2 { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public string? MobileNumber { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string? CityName { get; set; }
    }
}

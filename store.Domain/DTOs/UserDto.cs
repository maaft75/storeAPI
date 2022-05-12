using System.ComponentModel.DataAnnotations;

namespace store.Domain.DTOs
{
    public class UserDto
    {
        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "Please enter a valid email address.")]
        public string Email_Address { get; set;}
        [Required]
        public string Password { get; set;}
    }
}
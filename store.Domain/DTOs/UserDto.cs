using System.ComponentModel.DataAnnotations;

namespace store.Domain.DTOs
{
    public class UserDto
    {
        [Required]
        public string Email_Address { get; set;}
        [Required]
        public string Password { get; set;}
    }
}
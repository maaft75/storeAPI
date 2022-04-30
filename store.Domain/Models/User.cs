using System.ComponentModel.DataAnnotations;

namespace store.Domain.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Email_Address { get; set;}
        [Required]
        public string Password { get; set;}
    }
}
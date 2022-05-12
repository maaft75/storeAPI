using System.ComponentModel.DataAnnotations;

namespace store.Domain.Models.v1
{
    public class Store
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string StoreName { get; set;}
        [Required]
        public User StoreOwner { get; set;}
    }
}
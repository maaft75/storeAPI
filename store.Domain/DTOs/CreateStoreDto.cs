using System.ComponentModel.DataAnnotations;

namespace store.Domain.DTOs{
    public class CreateStoreDto
    {
        [Required]
        public string StoreName { get; set;}
        [Required]
        public int StoreOwnerId { get; set;}
    }
}
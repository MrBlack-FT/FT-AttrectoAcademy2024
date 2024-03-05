using System.ComponentModel.DataAnnotations;

namespace Academy_2024.Models
{
    public class User
    {
        [Key]
        public int? Id { get; set; }
        [StringLength(10)]
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        [Required]
        public string? Email { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace Academy_2024.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string? Name {  get; set; }

        public string? Role {  get; set; }

        [Required]
        public string? Email { get; set; }

        //DateOfBirth added here.
        public int? DateOfBirth {  get; set; }

        public ICollection<Course> Courses { get; set; } = [];
    }
}

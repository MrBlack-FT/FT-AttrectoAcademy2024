using System.ComponentModel.DataAnnotations;

namespace Academy_2024.Dtos
{
    public class UserDto
    {
        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Role { get; set; }

        [Required]
        public string? Email { get; set; }

        [Required]
        public string? Password { get; set; }

        //DateOfBirth added here.
        public int? DateOfBirth { get; set; }
    }
}

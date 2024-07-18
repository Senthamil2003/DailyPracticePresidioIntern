using System.ComponentModel.DataAnnotations;

namespace ProductApp.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [MaxLength(1)]
        public char Gender { get; set; }

        [Required]
        public DateTime EnrollmentDate { get; set; }
    }

}

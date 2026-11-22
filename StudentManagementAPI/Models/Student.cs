using System.ComponentModel.DataAnnotations;

namespace StudentManagementAPI.Models;

public class Student
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Student Name is required.")]
    [StringLength(80, MinimumLength = 2)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required]
    [StringLength(50)]
    public string Department { get; set; } = string.Empty;

    [Range(1, 8)]
    public int Semester { get; set; }

    [Range(0.0, 10.0)]
    public double Cgpa { get; set; }

    public DateTime EnrollmentDate { get; set; } = DateTime.Now;
}

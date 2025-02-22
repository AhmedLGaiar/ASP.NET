using System.ComponentModel.DataAnnotations;

namespace Day2_Institute
{
    public class Department
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public string Manager { get; set; }
        public ICollection<Instructor> Instructors { get; set; } = new HashSet<Instructor>();
        public ICollection<Course> Courses { get; set; } = new HashSet<Course>();
        public ICollection<Trainee> Trainees { get; set; } = new HashSet<Trainee>();
    }
}

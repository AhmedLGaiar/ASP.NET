using System.ComponentModel.DataAnnotations;

namespace Institute
{
    public class Department
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public string Manager { get; set; }
        public ICollection<Instructor> Instructor { get; set; } = new HashSet<Instructor>();
        public ICollection<Course> Courses { get; set; } = new HashSet<Course>();
        public ICollection<Trainee> Trainee { get; set; } = new HashSet<Trainee>();
    }
}

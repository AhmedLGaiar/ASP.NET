using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Institute
{
    public class Instructor
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public string? Image { get; set; }
        public decimal Salary { get; set; }
        public string? Address { get; set; }

        [ForeignKey("Department")]
        public int DepartmentID { get; set; }
        public Department Department { get; set; }

        [ForeignKey("Course")]
        public int CourseID { get; set; }
        public Course Course { get; set; }

    }
}

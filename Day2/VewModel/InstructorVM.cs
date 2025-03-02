using Institute;
using System.ComponentModel.DataAnnotations;

namespace Day2.VewModel
{
    public class InstructorVM
    {
        public string Name { get; set; }
        public string? Image { get; set; }
        public decimal Salary { get; set; }
        public string? Address { get; set; }

        [Display(Name = "Department Name")]
        public int DepartmentID { get; set; }
        public List<Department> Department { get; set; }

        [Display(Name = "Course Name")]
        public int CourseID { get; set; }
        public List<Course> courses { get; set; }
    }
}

using Institute;

namespace Day2.VewModel
{
    public class InstructorVM
    {
        public string Name { get; set; }
        public string? Image { get; set; }
        public decimal Salary { get; set; }
        public string? Address { get; set; }
        public List<Department> Department { get; set; }
        public List<Course> courses { get; set; }
    }
}

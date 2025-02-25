using Day2_Institute;
using System.ComponentModel.DataAnnotations.Schema;

namespace Day2.VewModel
{
    public class CourseVM
    {
        public string Name { get; set; }
        public byte Degree { get; set; }
        public byte MinDegree { get; set; }
        public byte Hours { get; set; }
        public int DepartmentID { get; set; }
        public List<Department> DepartmentsList { get; set; } = new();
    }
}

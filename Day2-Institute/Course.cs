using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Day2_Institute
{
    public class Course
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public byte Degree { get; set; }
        public byte MinDegree { get; set; }
        public byte Hours { get; set; }

        [ForeignKey("Department")]
        public int DepartmentID { get; set; }
        public Department Department { get; set; }
        public ICollection<Instructor> Instructors { get; set; } = new HashSet<Instructor>();
        public ICollection<crsResult> crsResults { get; set; } = new HashSet<crsResult>();
    }
}

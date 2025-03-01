using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Institute
{
    public class Trainee
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public string? Image { get; set; }
        public string? Address { get; set; }
        public byte Grade { get; set; }

        [ForeignKey("Department")]
        public int DepartmentID { get; set; }
        public Department Department { get; set; }
        public ICollection<crsResult> CrsResult { get; set; } = new HashSet<crsResult>();
    }
}

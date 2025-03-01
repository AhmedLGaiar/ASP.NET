using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Institute
{
    public class crsResult
    {
        [Key]
        public int ID { get; set; }
        public byte Degree { get; set; }

        [ForeignKey("Trainee")]
        public int TraineeID { get; set; }
        public Trainee Trainee { get; set; }

        [ForeignKey("Course")]
        public int CourseID { get; set; }
        public Course Course { get; set; }
    }
}

using Day2_Institute;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Day2.VewModel
{
    public class CourseVM
    {

        [Required( ErrorMessage = "Name Must is Required")]
        public string Name { get; set; }


        [Range(60,100, ErrorMessage = "Degree must in between 60:100")]
        public byte Degree { get; set; }


        [Remote("CheckMinDegree","Course"
            , ErrorMessage = "Min Degree not Valid", AdditionalFields = "Degree")]
        public byte MinDegree { get; set; }


        [Remote("Modules_by_3", "Course"
            , ErrorMessage = "Hours is not Valid Should by modules 3")]
        public byte Hours { get; set; }


        [Display(Name = "Department Name")]
        [Remote("ISValidDepartmentID", "Course"
            , ErrorMessage = "Choose Valid Department")]
        public int DepartmentID { get; set; }
        public List<Department> DepartmentsList { get; set; } = new();
    }
}

using Institute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IDepartmentRepository : IRepository<Department>
    {
        public IEnumerable<Course> GetCoursesInDepartment(int departmentID);
    }
}

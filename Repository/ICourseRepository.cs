using Institute;
using System.Collections.Generic;

namespace Repository
{
    public interface ICourseRepository : IRepository<Course>
    {
        public IEnumerable<crsResult> GetAllTraineeWithCourses();
    }
}

using Institute;

namespace Repository
{
    public interface ITraineeRepository : IRepository<Trainee>
    {
        public crsResult GetTraineeByIDandCourseID(int Traineeid, int Courseid);

    }

}

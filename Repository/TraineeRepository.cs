using Institute;
using System.Data.Entity;

namespace Repository
{
    public class TraineeRepository : ITraineeRepository
    {
        private readonly InstituteContext _context;
        public TraineeRepository(InstituteContext context)
        {
            _context = context;
        }
        public void Add(Trainee entity) => _context.Trainee.Add(entity);

        public IEnumerable<Trainee> GetAll() => _context.Trainee.Include(e => e.Department).ToList();

        public Trainee GetByID(int id) => _context.Trainee.Include(e => e.Department).FirstOrDefault(e => e.ID == id);

        public void Save() => _context.SaveChanges();

        public void Update(Trainee entity) => _context.Trainee.Update(entity);
        public void Delete(int id)
        {
            var entity = _context.Trainee.Find(id);
            if (entity != null)
                _context.Trainee.Remove(entity);
        }

        public crsResult GetTraineeByIDandCourseID(int Traineeid, int Courseid)
        {
            return _context.CrsResults.Include(e => e.Trainee)
                             .Include(e => e.Course).FirstOrDefault(e => e.TraineeID == Traineeid && e.CourseID == Courseid);
        }
    }

}

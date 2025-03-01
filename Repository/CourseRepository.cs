using Institute;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class CourseRepository : ICourseRepository
    {
        private readonly InstituteContext _context;
        public CourseRepository(InstituteContext context)
        {
            _context = context;
        }
        public void Save() => _context.SaveChanges();
        public void Add(Course entity) => _context.Course.Add(entity);
        public void Update(Course entity) => _context.Course.Update(entity);
        public Course GetByID(int id) => _context.Course.Include(e => e.Department).FirstOrDefault(e => e.ID == id);
        public IEnumerable<Course> GetAll() => _context.Course.Include(e => e.Department).ToList();
        public IEnumerable<crsResult> AllTrainee() => _context.CrsResults.Include(e => e.Trainee).Include(e => e.Course).ToList();
        public void Delete(int id)
        {
            var entity = _context.Course.Find(id);
            if (entity != null)
                _context.Course.Remove(entity);
        }
    }
}

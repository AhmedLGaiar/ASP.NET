using Institute;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class InstructorRepository : IInstructorRepository
    {
        private readonly InstituteContext _context;
        public InstructorRepository(InstituteContext context)
        {
            _context = context;
        }
        public void Save() => _context.SaveChanges();

        public void Add(Instructor entity) => _context.Instructor.Add(entity);

        public void Update(Instructor entity) => _context.Instructor.Update(entity);

        public Instructor GetByID(int id)
        => _context.Instructor.Include(e => e.Course).Include(e => e.Department).FirstOrDefault(e => e.ID == id);
        public IEnumerable<Instructor> GetAll()
        => _context.Instructor.Include(e => e.Course).Include(e => e.Department).ToList();
        public void Delete(int id)
        {
            var entity = _context.Instructor.Find(id);
            if (entity != null)
                _context.Instructor.Remove(entity);
        }
    }
}

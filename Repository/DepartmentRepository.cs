using Institute;

namespace Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly InstituteContext _context;
        public DepartmentRepository(InstituteContext context)
        {
            _context = context;
        }
        public void Add(Department entity) => _context.Department.Add(entity);

        public IEnumerable<Department> GetAll() => _context.Department.ToList();

        public Department GetByID(int id) => _context.Department.Find(id);

        public void Save() => _context.SaveChanges();

        public void Update(Department entity) => _context.Department.Update(entity);
        public void Delete(int id)
        {
            var entity = _context.Department.Find(id);
            if (entity != null)
                _context.Department.Remove(entity);
        }

        public IEnumerable<Course> GetCoursesInDepartment(int departmentID)
                       => _context.Course.Where(c => c.DepartmentID == departmentID).ToList(); 
    }
}

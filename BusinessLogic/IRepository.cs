namespace Repository
{
    public interface IRepository<T> where T : class
    {
        public void Save();
        public void Add(T entity);
        public void Update(T entity);
        public void Delete(int id);
        public T GetByID(int id);
        public IEnumerable<T> GetAll();
    } 
}

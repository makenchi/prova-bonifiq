using Microsoft.EntityFrameworkCore;

namespace ProvaPub.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly TestDbContext _ctx;
        private readonly DbSet<T> _dbSet;
        public BaseRepository(TestDbContext ctx)
        {
            _ctx = ctx;
            _dbSet = _ctx.Set<T>();
        }
        public List<T> GetAll()
        {
            return _dbSet.ToList();
        }
    }
}

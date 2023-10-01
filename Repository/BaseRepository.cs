using Microsoft.EntityFrameworkCore;
using ProvaPub.Models;

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

        public PaginatedList<T> GetPaginated(int page, int itensPerPage)
        {
            var query = _ctx.Set<T>().AsQueryable();

            int totalItems = query.Count();

            int totalPages = (int)Math.Ceiling(totalItems / (double)itensPerPage);
            
            page = Math.Min(Math.Max(page, 1), totalPages);
            
            int startIndex = (page - 1) * itensPerPage;

            // Realiza a consulta paginada
            var pagedItems = query
                .Skip(startIndex)
                .Take(itensPerPage)
                .ToList();
            
            return new PaginatedList<T>() {
                                            ItemList = pagedItems, 
                                            TotalItens = totalItems,
                                            Page = page,
                                            ItensPerPage = itensPerPage
            };
        }
    }    
}

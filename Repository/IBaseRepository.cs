using ProvaPub.Models;

namespace ProvaPub.Repository
{
    public interface IBaseRepository<T> where T : class
    {
        List<T> GetAll();
        PaginatedList<T> GetPaginated(int page, int itensPerPage);
    }
}

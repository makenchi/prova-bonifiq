namespace ProvaPub.Repository
{
    public interface IBaseRepository<T>
    {
        List<T> GetAll();
    }
}

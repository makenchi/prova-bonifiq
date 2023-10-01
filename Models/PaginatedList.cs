namespace ProvaPub.Models
{
    public class PaginatedList<T> : List<T> where T : class
    {
        public List<T> ItemList { get; set; }
        public int TotalItens { get; set; }
        public int Page {  get; set; }
        public int ItensPerPage { get; set; }

    }
}

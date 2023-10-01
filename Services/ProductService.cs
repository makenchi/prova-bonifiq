using ProvaPub.Models;
using ProvaPub.Repository;

namespace ProvaPub.Services
{
	public class ProductService
	{
		private readonly TestDbContext _ctx;
		private readonly BaseRepository<Product> _repository;

		public ProductService(TestDbContext ctx)
		{
			_ctx = ctx;
			_repository = new BaseRepository<Product>(_ctx);
		}

		public ProductList  ListProducts(int page)
		{
			int limit = 10;

			var products = _repository.GetPaginated(page, limit);
			var totalPages = products.TotalItens / products.ItensPerPage;
			bool hasNext = false;
			if (page < totalPages) { 
				hasNext = true;
			}
			return new ProductList() {  HasNext=hasNext, TotalCount =products.TotalItens, Products = products.ItemList };
		}

	}
}

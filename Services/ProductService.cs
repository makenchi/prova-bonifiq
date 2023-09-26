using ProvaPub.Models;
using ProvaPub.Repository;

namespace ProvaPub.Services
{
	public class ProductService
	{
		private readonly TestDbContext _ctx;

		public ProductService(TestDbContext ctx)
		{
			_ctx = ctx;
		}

		public ProductList  ListProducts(int page)
		{
			int limit = page * 10;
			int init = limit - 10;
			return new ProductList() {  HasNext=false, TotalCount =10, Products = _ctx.Products.OrderBy(x => x.Id).Where(x => x.Id >= init && x.Id < limit).ToList() };
		}

	}
}

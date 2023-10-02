using ProvaPub.Models;
using ProvaPub.Services.Interfaces;

namespace ProvaPub.Services
{
    public class ProductService : IProductService
	{
        private readonly IPaginationService _pagination;

        public ProductService(IPaginationService pagination)
        {       
            _pagination = pagination;
        }

        public ListInfo<Product> ListProducts(int page)
        {
            return _pagination.ListEntities<Product>(page);
        }
    }
}

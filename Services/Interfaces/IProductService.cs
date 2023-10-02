using ProvaPub.Models;

namespace ProvaPub.Services.Interfaces
{
    public interface IProductService
    {
        ListInfo<Product> ListProducts(int page);
    }
}

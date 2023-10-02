using ProvaPub.Models;

namespace ProvaPub.Services.Interfaces
{
    public interface IPaginationService
    {
        ListInfo<T> ListEntities<T>(int page) where T : class;
    }
}

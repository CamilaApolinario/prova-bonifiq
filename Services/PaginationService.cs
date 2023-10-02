using ProvaPub.Models;
using ProvaPub.Repositories.Interfaces;
using ProvaPub.Services.Interfaces;

namespace ProvaPub.Services
{
    public class PaginationService : IPaginationService
    {
        private readonly IBaseRepository _repository;

        public PaginationService(IBaseRepository repository)
        {
            _repository = repository;
        }

        public ListInfo<T> ListEntities<T>(int page) where T : class
        {
            int pageSize = 10;
            int startIndex = (page - 1) * pageSize;

            List<T> allEntities = _repository.GetAll<T>();

            List<T> entitiesOnPage = allEntities.Skip(startIndex).Take(pageSize).ToList();

            bool hasNext = (startIndex + pageSize) < allEntities.Count;

            ListInfo<T> entityListInfo = new ListInfo<T>()
            {
                HasNext = hasNext,
                TotalCount = allEntities.Count,
                Items = entitiesOnPage
            };

            return entityListInfo;
        }

    }
}

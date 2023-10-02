namespace ProvaPub.Repositories.Interfaces
{
    public interface IBaseRepository
    {
        List<T> GetAll<T>() where T : class;
    }
}
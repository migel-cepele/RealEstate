namespace RealEstate.API.Application.Common
{
    public interface IBaseInterface<T>
    {
        List<T> GetAll();
        T? GetById(long id);
        void Add(T entity);
        void Update(T entity);
        void Delete(long id);
    }
}

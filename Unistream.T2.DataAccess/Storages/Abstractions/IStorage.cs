namespace Unistream.T2.DataAccess.Storages.Abstractions
{
    public interface IStorage<T>
    {
        T? GetById(Guid id);
        void CreateOrUpdate(T entity);
    }
}
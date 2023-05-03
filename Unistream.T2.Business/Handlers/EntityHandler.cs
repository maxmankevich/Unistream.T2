using Unistream.T2.Business.Exceptions;
using Unistream.T2.DataAccess.Storages.Abstractions;
using Unistream.T2.Domain.Entities;

namespace Unistream.T2.Business.Handlers
{
    public interface IEntityHandler
    {
        Entity? GetById(Guid id);
        void CreateOrUpdate(Entity entity);
    }

    public class EntityHandler : IEntityHandler
    {
        private readonly IStorage<Entity> _storage;

        public EntityHandler(IStorage<Entity> storage)
        {
            _storage = storage;
        }

        public Entity? GetById(Guid id)
        {
            try
            {
                return _storage.GetById(id);
            }
            catch (Exception ex)
            {
                throw new StorageException("Take data error", ex);
            }
        }

        public void CreateOrUpdate(Entity entity)
        {
            try
            {
                _storage.CreateOrUpdate(entity);
            }
            catch (Exception ex)
            {
                throw new StorageException("Put data error", ex);
            }
        }
    }
}

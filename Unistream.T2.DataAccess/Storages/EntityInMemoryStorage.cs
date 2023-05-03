using System.Collections.Concurrent;
using Unistream.T2.DataAccess.Storages.Abstractions;
using Unistream.T2.Domain.Entities;

namespace Unistream.T2.DataAccess.Storages
{
    public class EntityInMemoryStorage : IStorage<Entity>
    {
        private readonly ConcurrentDictionary<Guid, Entity> _entities = new ();

        public Entity? GetById(Guid id)
        {
            _entities.TryGetValue(id, out var entity);

            return entity;
        }

        public void CreateOrUpdate(Entity entity)
        {
            // что делать, если Id == default?
            // что делать, если элемент с указанным id уже существует?
            // что хотим возвращать в качестве результата?
            _entities.AddOrUpdate(entity.Id, entity, (key, value) => entity);
        }
    }
}

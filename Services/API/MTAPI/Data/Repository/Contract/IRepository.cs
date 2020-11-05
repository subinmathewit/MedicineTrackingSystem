using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MTAPI.Repository.Contract
{
    public interface IRepository<Entity> where Entity:class
    {
        public void AddAsync(Entity entity);
        public void Remove(Entity entity);
        public  IEnumerable<Entity> GetAll();
        public Task<IEnumerable<Entity>> GetAllAsync(Expression<Func<Entity, bool>> predicate);
        public Entity Get(Expression<Func<Entity, bool>> predicate);
        public Task<Entity> GetByKeyAsync<Key>(Key id);

    }
}

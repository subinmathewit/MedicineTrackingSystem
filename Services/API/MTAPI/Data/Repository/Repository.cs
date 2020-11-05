using Microsoft.EntityFrameworkCore;
using MTAPI.Data;
using MTAPI.Repository.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MTAPI.Repository
{
    public class Repository<Entity> : IRepository<Entity> where Entity : class
    {
        private readonly MedicineTrackingContext _context;
        public Repository(MedicineTrackingContext context)
        {
            this._context = context;
        }
        
        public void AddAsync(Entity entity)
        {
            this._context.Set<Entity>().AddAsync(entity);
        }

        public Entity Get(Expression<Func<Entity, bool>> predicate)
        {
            return this._context.Set<Entity>().Where(predicate).AsQueryable().SingleOrDefault();
        }

        public  IEnumerable<Entity> GetAll()
        {
            return  this._context.Set<Entity>().ToList();
        }

        public async Task<IEnumerable<Entity>> GetAllAsync(Expression<Func<Entity, bool>> predicate)
        {
            return await this._context.Set<Entity>().Where(predicate).AsQueryable().ToListAsync();
        }

        public async Task<Entity> GetByKeyAsync<Key>(Key id)
        {
            return await this._context.Set<Entity>().FindAsync(id);
        }

        public void Remove(Entity entity)
        {
            this._context.Set<Entity>().Remove(entity);
        }
    }
}

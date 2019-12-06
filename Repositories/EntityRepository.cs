using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using LCSR.Domain.SeedWorks;
using Microsoft.EntityFrameworkCore;

namespace LCSR.Infrastructure.Repositories
{
    public class EntityRepository<TEntity>: IEntityRepository<TEntity> where TEntity: Entity, IAggregateRoot
    {
        public IUnitOfWork UnitOfWork => _context;
        
        public LCSRContext _context { get; }

        public EntityRepository(LCSRContext context)
        {
            _context = context;
        }
        
        
        public async Task<TEntity> InsertAsync(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public Task InsertRangeAsync(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().AddRange(entities);
            return _context.SaveChangesAsync();
        }

        public Task RemoveAsync(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            return _context.SaveChangesAsync();
        }

        public Task RemoveRangeAsync(TEntity entities)
        {
            _context.Set<TEntity>().RemoveRange(entities);
            return _context.SaveChangesAsync();
        }

        public Task UpdateAsync(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            return _context.SaveChangesAsync();
        }

        public Task UpdateRangeAsync(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().UpdateRange(entities);
            return _context.SaveChangesAsync();
        }

        public async Task<TEntity> FirstOrDefaultAsync(long id)
        {
            return await _context.Set<TEntity>().FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _context.Set<TEntity>().FirstOrDefaultAsync(predicate);
        }

        public async Task<IEnumerable<TEntity>> WhereAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _context.Set<TEntity>().Where(predicate).ToListAsync();
        }

        public IQueryable<TEntity> QueryAsync()
        {
            return _context.Set<TEntity>();
        }
    }
}
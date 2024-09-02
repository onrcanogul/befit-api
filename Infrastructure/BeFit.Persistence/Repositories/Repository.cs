using BeFit.Application.Repositories;
using BeFit.Domain.Entities.Base;
using BeFit.Persistence.Contexts;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace BeFit.Persistence.Repositories
{
    public class Repository<T>(BeFitDbContext context) : IRepository<T> where T : BaseEntity
    {
        public DbSet<T> _context => context.Set<T>();
        public async Task<T> CreateAsync(T entity)
        {
            await _context.AddAsync(entity);
            return entity;
        }
        public async Task CreateRangeAsync(List<T> entities)
        {
            await _context.AddRangeAsync(entities);
        }
        public void Delete(T entity)
        {
            _context.Remove(entity);
        }
        public void DeleteRange(List<T> entities)
        {
            _context.RemoveRange(entities);
        }
        public IQueryable<T> GetByIdQueryable(Guid id)
        {
            return _context.Where(e => e.Id == id);
        }
        public IQueryable<T> GetListQueryable(Expression<Func<T, bool>>? predicate = null)
        {
            var query = _context.AsQueryable();
            return predicate == null ? query : query.Where(predicate);     
        }
        public void Update(T entity)
        {
            _context.Update(entity);
        }
        public void UpdateRangeAsync(List<T> entities)
        {
            _context.UpdateRange(entities);
        }
    }
}

using BeFit.Application.Repositories;
using BeFit.Domain.Entities.Base;
using BeFit.Persistence.Contexts;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace BeFit.Persistence.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly BeFitDbContext context;

        
        public Repository(BeFitDbContext context)
        {
            this.context = context;
        }
        public DbSet<T> _context => context.Set<T>();
        public IQueryable<T> GetQueryable(Expression<Func<T, bool>>? predicate = null)
        {
            var query = _context.AsQueryable();
            return predicate == null ? query : query.Where(predicate);     
        }
        public IQueryable<T> GetByIdQueryable(Guid? id)
        {
            return _context.Where(e => e.Id == id);
        }
        public async Task<T> CreateAsync(T entity)
        {
            await _context.AddAsync(entity);
            return entity;
        }
        public void Update(T entity)
        {
            _context.Update(entity);
        } 
        public void Delete(T entity)
        {
            _context.Remove(entity);
        }
        public void DeleteRange(List<T> entities)
        {
            _context.RemoveRange(entities);
        }
        public async Task CreateRangeAsync(List<T> entities)
        {
            await _context.AddRangeAsync(entities);
        }
        public void UpdateRangeAsync(List<T> entities)
        {
            _context.UpdateRange(entities);
        }

        public bool Any(Expression<Func<T, bool>>? predicate = null)
        {
            return _context.Any(predicate);
        }
    }
}

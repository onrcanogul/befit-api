using BeFit.Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;


namespace BeFit.Application.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        public DbSet<T> _context { get; }
        IQueryable<T> GetListQueryable(Expression<Func<T, bool>>? predicate = null);
        IQueryable<T> GetByIdQueryable(Guid? id);
        Task<T> CreateAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task CreateRangeAsync(List<T> entities);
        void UpdateRangeAsync(List<T> entities);
        void DeleteRange(List<T> entities);
    }
}

using BeFit.Application.Repositories;
using BeFit.Application.Services;
using BeFit.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BeFit.Persistence.Services
{
    public class FoodService(IRepository<Food> Repository) : IFoodService
    {
        public async Task<List<Food>> GetAllAsync(int page, int size)
        {
            List<Food> list = await Repository.GetListQueryable()
                .Include(f => f.Properties)
                    .ThenInclude(p => p.Protein)
                .Include(f => f.Properties)
                    .ThenInclude(p => p.Fat)
                .Include(f => f.Properties)
                    .ThenInclude(p => p.Carbohydrate)
                .Include(f => f.Properties)
                    .ThenInclude(p => p.Minerals)
                .Include(f => f.Properties)
                    .ThenInclude(p => p.Vitamins).ToListAsync();


            return list;
        }

    }
}

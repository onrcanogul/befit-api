using BeFit.Application.Repositories;
using BeFit.Application.Services;
using BeFit.Application.Services.Category;
using BeFit.Application.Services.Identity;
using BeFit.Application.Services.Image;
using BeFit.Application.Services.Nutrient.Drink;
using BeFit.Application.Services.NutrientProperty;
using BeFit.Application.Services.Post;
using BeFit.Application.Services.Token;
using BeFit.Domain.Entities.Identity;
using BeFit.Infrastructure.Services;
using BeFit.Persistence.Contexts;
using BeFit.Persistence.Repositories;
using BeFit.Persistence.Services;
using BeFit.Persistence.Services.Identity;
using BeFit.Persistence.Services.Image;
using BeFit.Persistence.Services.Nutrient;
using BeFit.Persistence.Services.NutrientProperty;
using BeFit.Persistence.Services.Post;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BeFit.Persistence
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BeFitDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("PostgreSQL")));
            services.AddIdentity<User, Role>(opt =>
            {

            }).AddEntityFrameworkStores<BeFitDbContext>();

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IUserPropertyService, UserPropertyService>();
            services.AddScoped<IFoodService, FoodService>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<IPostDislikeService, PostDislikeService>();
            services.AddScoped<IPostLikeService, PostLikeService>();
            services.AddScoped<IPostService, PostService>();
            services.AddScoped<ITokenHandler, TokenHandler>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IDrinkService, DrinkService>();
            services.AddScoped(typeof(IImageService<>), typeof(ImageService<>));
            services.AddScoped<INutrientPropertyService, NutrientPropertyService>();
            return services;
        }
    }
}

using BeFit.Domain.Entities;
using BeFit.Domain.Entities.Abstract;
using BeFit.Domain.Entities.Identity;
using BeFit.Domain.Entities.Macros;
using BeFit.Persistence.Interceptors;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace BeFit.Persistence.Contexts
{
    public class BeFitDbContext : IdentityDbContext<User, Role, string>
    {
        private readonly AuditInterceptor auditInterceptor;
        public BeFitDbContext(DbContextOptions options, AuditInterceptor auditInterceptor) : base(options)
        {
            this.auditInterceptor = auditInterceptor;
        }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Drink> Drinks { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Nutrient> Nutrients { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Protein> Protein { get; set; }
        public DbSet<Fat> Fat { get; set; }
        public DbSet<Salt> Salt { get; set; }
        public DbSet<Carbohydrate> Carbohydrate { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<PostImage> PostImages { get; set; }
        public DbSet<NutrientImage> FoodImages { get; set; }
        public DbSet<CategoryImage> CategoryImages { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<PostLike> PostLikes { get; set; }
        public DbSet<CommentLike> CommentLikes { get; set; }
        public DbSet<Dislike> Dislikes { get; set; }
        public DbSet<PostDislike> PostDislikes { get; set; }
        public DbSet<CommentDislike> CommentDislikes { get; set; }
        public DbSet<NutrientProperties> NutrientProperties { get; set; }
        public DbSet<UserProperties> UserProperties { get; set; }
        public DbSet<Minerals> Minerals { get; set; }
        public DbSet<Vitamins> Vitamins { get; set; }
        public DbSet<Friendship> Friendships { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Nutrient>()
            .HasDiscriminator<string>("Discriminator")
            .HasValue<Food>("Food")
            .HasValue<Drink>("Drink");
            builder.Entity<Nutrient>()
            .ToTable("Nutrients");

            builder.Entity<Image>()
            .HasDiscriminator<string>("Discriminator")
            .HasValue<NutrientImage>("FoodImage")
            .HasValue<CategoryImage>("CategoryImage")
            .HasValue<PostImage>("PostImage");
            builder.Entity<Image>()
                .ToTable("Images");

            builder.Entity<Like>()
            .HasDiscriminator<string>("Discriminator")
            .HasValue<PostLike>("PostLike")
            .HasValue<CommentLike>("CommentLike");
            builder.Entity<Like>()
                .ToTable("Likes");

            builder.Entity<Dislike>()
            .HasDiscriminator<string>("Discriminator")
            .HasValue<PostDislike>("PostDislike")
            .HasValue<CommentDislike>("CommentDislike");
            builder.Entity<Dislike>()
                .ToTable("Dislikes");

            builder.Entity<UserProperties>()
                .HasOne(u => u.User)
                .WithOne(u => u.Properties)
                .HasForeignKey<UserProperties>(up => up.UserId);
            
            builder.Entity<NutrientProperties>()
                .HasOne(n => n.Nutrient)
                .WithOne(n => n.Properties)
            .HasForeignKey<NutrientProperties>(n => n.NutrientId);

            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.AddInterceptors(auditInterceptor);
            base.OnConfiguring(optionsBuilder);
        }
    }
}

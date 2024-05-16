using Microsoft.EntityFrameworkCore;
using Rumassa.Domain.Entities;
using Rumassa.Domain.Entities.Auth;
namespace Rumassa.Aplication.Abstraction
{
    public interface IRumassaDbContext
    {
        public DbSet<Diplom> Diploms { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Coupon> Coupons { get; set; }
        public DbSet<Delivery> Deliveries { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}

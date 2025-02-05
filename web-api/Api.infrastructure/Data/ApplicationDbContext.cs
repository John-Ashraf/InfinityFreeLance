using Api.Data.Entities.Identity;
using Api.Data.Entities.Tables;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Api.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure Photos to be stored as JSON
            _ = modelBuilder.Entity<Product>()
                .Property(p => p.Photos)
                .HasConversion(
                    v => JsonConvert.SerializeObject(v), // Serialize to JSON using Newtonsoft.Json
                    v => JsonConvert.DeserializeObject<List<string>>(v) // Deserialize from JSON
                );
            _ = modelBuilder.Entity<Order>()
               .Property(p => p.PicsCustom)
               .HasConversion(
                   v => JsonConvert.SerializeObject(v), // Serialize to JSON using Newtonsoft.Json
                   v => JsonConvert.DeserializeObject<List<string>>(v) // Deserialize from JSON
               );
        }

    }
}

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volvo.Domain.Entities;
using Volvo.Infra.Data.EntityConfigurations;

namespace Volvo.Infra.Data.Context
{
    public class DbTruckContext : IdentityDbContext
    {
        public DbTruckContext(DbContextOptions<DbTruckContext> options)
            : base(options)
        {
        }

        public DbSet<Truck> Truck { get; set; }        

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new TruckConfiguration());            
        }
    }
}

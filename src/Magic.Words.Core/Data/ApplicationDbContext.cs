using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Magic.Words.Core.Models;
using Magic.Words.Core.DataConfiguration;
namespace Magic.Words.Core.Data {
    public class ApplicationDbContext : DbContext {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {
        }

        public DbSet<Subscription> Subscriptions { get; set; }

        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder) {

 
            modelBuilder.ApplyConfiguration(new SubscriptionConfiguration());
 
            Seeder.Seed(modelBuilder);

        }
    }
}

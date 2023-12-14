using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Magic.Words.Core.Models;
namespace Magic.Words.Infrastructure.Data {
    public class ApplicationDbContext : DbContext {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {
        }

        public DbSet<Subscription> Subscriptions { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder) {

           
            modelBuilder.Entity<Subscription>().HasData(
               new Subscription { SubscriptionId = 1, SubscriptionName = "Standart", SubscriptionPrice = 0 },
               new Subscription { SubscriptionId = 2, SubscriptionName = "Premium", SubscriptionPrice = 9.99m },
               new Subscription { SubscriptionId = 3, SubscriptionName = "Royal", SubscriptionPrice = 99.99m }
               );

        }
    }
}

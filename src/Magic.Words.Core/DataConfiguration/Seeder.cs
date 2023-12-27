using Magic.Words.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magic.Words.Core.DataConfiguration {
    public class Seeder {
        public static void Seed(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Subscription>().HasData(
                new Subscription { SubscriptionId = 1, SubscriptionName = "Standart", SubscriptionPrice = 0 },
                new Subscription { SubscriptionId = 2, SubscriptionName = "Premium", SubscriptionPrice = 9.99m },
                new Subscription { SubscriptionId = 3, SubscriptionName = "Royal", SubscriptionPrice = 99.99m }
                );
        }
    }
}

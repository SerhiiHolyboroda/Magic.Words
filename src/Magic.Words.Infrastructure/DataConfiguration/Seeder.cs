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
                new Subscription { SubscriptionId = 1, Name = "Standart", Price = 0, ItemDescription = "Test1"  },
                new Subscription { SubscriptionId = 2, Name = "Premium", Price = 9.99m, ItemDescription = "Test2"  },
                new Subscription { SubscriptionId = 3, Name = "Royal", Price = 99.99m, ItemDescription = "Test3" }
                );


            modelBuilder.Entity<ShopItem>().HasData(
     new ShopItem { ShopItemId = 1, Name = "Item1", ShopItemDiscount = 0.1, Price = 10.99m, ShopItemCount = 5, ItemDescription = "Description1", ShopItemTitle = "Title1" },
     new ShopItem { ShopItemId = 2, Name = "Item2", ShopItemDiscount = 0.2, Price = 19.99m, ShopItemCount = 3, ItemDescription = "Description2", ShopItemTitle = "Title2" },
     new ShopItem { ShopItemId = 3, Name = "Item3", ShopItemDiscount = 0.15, Price = 15.49m, ShopItemCount = 8, ItemDescription = "Description3", ShopItemTitle = "Title3" },
     new ShopItem { ShopItemId = 4, Name = "Item4", ShopItemDiscount = 0.25, Price = 25.99m, ShopItemCount = 2, ItemDescription = "Description4", ShopItemTitle = "Title4" },
     new ShopItem { ShopItemId = 5, Name = "Item5", ShopItemDiscount = 0.05, Price = 5.99m, ShopItemCount = 10, ItemDescription = "Description5", ShopItemTitle = "Title5" },
     new ShopItem { ShopItemId = 6, Name = "Item6", ShopItemDiscount = 0.3, Price = 30.99m, ShopItemCount = 4, ItemDescription = "Description6", ShopItemTitle = "Title6" },
     new ShopItem { ShopItemId = 7, Name = "Item7", ShopItemDiscount = 0.12, Price = 12.99m, ShopItemCount = 6, ItemDescription = "Description7", ShopItemTitle = "Title7" },
     new ShopItem { ShopItemId = 8, Name = "Item8", ShopItemDiscount = 0.18, Price = 18.99m, ShopItemCount = 7, ItemDescription = "Description8", ShopItemTitle = "Title8" }
 );


            modelBuilder.Entity<Topic>().HasData(
       new Topic { TopicId = 1, Title = "Topic 1", Content = "Content for Topic 1", CreatedAt = DateTime.Now, ApplicationUserId = "user1", isActive = true },
       new Topic { TopicId = 2, Title = "Topic 2", Content = "Content for Topic 2", CreatedAt = DateTime.Now, ApplicationUserId = "user2", isActive = true  },
       new Topic { TopicId = 3, Title = "Topic 3", Content = "Content for Topic 3", CreatedAt = DateTime.Now, ApplicationUserId = "user1", isActive = true }
   ); ;

           // Seed initial data for Comment
           modelBuilder.Entity<Comment>().HasData(
               new Comment { CommentId = 1, Content = "Comment 1 for Topic 1", CreatedAt = DateTime.Now, ApplicationUserId = "user2", TopicId = 1, isActive = true },
               new Comment { CommentId = 2, Content = "Comment 2 for Topic 1", CreatedAt = DateTime.Now, ApplicationUserId = "user1", TopicId = 1, isActive = true },
               new Comment { CommentId = 3, Content = "Comment 1 for Topic 2", CreatedAt = DateTime.Now, ApplicationUserId = "user2", TopicId = 2, isActive = true }
           );

           // Seed initial data for ApplicationUser
           modelBuilder.Entity<ApplicationUser>().HasData(
               new ApplicationUser { Id = "user1", UserName = "user1@example.com", Email = "user1@example.com", NormalizedUserName = "USER1@EXAMPLE.COM", NormalizedEmail = "USER1@EXAMPLE.COM", EmailConfirmed = true, PasswordHash = "DFADAS!@#@#@!" },
               new ApplicationUser { Id = "user2", UserName = "user2@example.com", Email = "user2@example.com", NormalizedUserName = "USER2@EXAMPLE.COM", NormalizedEmail = "USER2@EXAMPLE.COM", EmailConfirmed = true, PasswordHash = "ADsaD@!dsadsa" }
           );
         
        }
    }
}

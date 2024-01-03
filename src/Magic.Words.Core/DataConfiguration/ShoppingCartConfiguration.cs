using Magic.Words.Core.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magic.Words.Core.DataConfiguration {
    public class ShoppingCartConfiguration
      //  : IEntityTypeConfiguration<ShoppingCart> 
        {
        /*
       public void Configure(EntityTypeBuilder<ShoppingCart> builder) {
           // Primary Key
           builder.HasKey(sc => sc.Id);

           // ProductId
           builder.Property(sc => sc.ProductId)
               .IsRequired();

           // Count
           builder.Property(sc => sc.Count)
               .IsRequired()
               .HasDefaultValue(1); // Default value for Count is 1

           // ApplicationUserId
           builder.Property(sc => sc.ApplicationUserId)
               .IsRequired();


           builder.HasOne(sc => sc.Product)
               .WithMany()  
               .HasForeignKey(sc => sc.ProductId)
               .OnDelete(DeleteBehavior.Cascade); 


           builder.HasOne(sc => sc.ApplicationUser)
                .WithMany()  
               .HasForeignKey(sc => sc.ApplicationUserId)
               .OnDelete(DeleteBehavior.Cascade);  
           */
    }
}


 
using Magic.Words.Core.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magic.Words.Core.DataConfiguration {
    public class ShopItemConfiguration : IEntityTypeConfiguration<ShopItem> {
        public void Configure(EntityTypeBuilder<ShopItem> builder) {

            builder.HasKey(s => s.ShopItemId);
            // Properties
            builder.Property(si => si.ShopItemName)
                .IsRequired();

            builder.Property(si => si.ShopItemDiscount)
                .IsRequired();

            builder.Property(si => si.ShopItemPrice)
                .IsRequired();

            builder.Property(si => si.ShopItemCount)
                .IsRequired();

            builder.Property(si => si.ShopItemDescription)
                .IsRequired();

            builder.Property(si => si.ShopItemTitle)
                .IsRequired();
        }
    }
}
 
using Magic.Words.Core.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magic.Words.Core.DataConfiguration {
    public class SubscriptionConfiguration : IEntityTypeConfiguration<Subscription> {
        public void Configure(EntityTypeBuilder<Subscription> builder) {

            builder.HasKey(s => s.SubscriptionId);
            builder.Property(s => s.SubscriptionName).IsRequired();
            builder.Property(s => s.SubscriptionPrice).IsRequired().HasColumnType("decimal(18,2)"); ;
        }
    }
}

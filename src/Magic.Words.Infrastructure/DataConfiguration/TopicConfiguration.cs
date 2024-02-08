using Magic.Words.Core.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magic.Words.Core.DataConfiguration {
    public class TopicConfiguration : IEntityTypeConfiguration<Topic> {
        public void Configure(EntityTypeBuilder<Topic> builder) {

          

            builder.Property(t => t.Title);
            builder.Property(t => t.Content);
            builder.Property(t => t.CreatedAt);

            builder.HasMany(t => t.Comments)
            .WithOne(c => c.Topic)
            .HasForeignKey(c => c.TopicId)
            // .IsRequired()  // Remove this line to make Comment not required
            .OnDelete(DeleteBehavior.NoAction);
        }
    }
}

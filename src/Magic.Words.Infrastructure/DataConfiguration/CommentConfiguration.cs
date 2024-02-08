using Magic.Words.Core.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magic.Words.Core.DataConfiguration {
    public class CommentConfiguration : IEntityTypeConfiguration<Comment> {
        public void Configure(EntityTypeBuilder<Comment> builder) {
          //  builder.HasKey(c => c.CommentId);

            builder.Property(c => c.Content).IsRequired();
            builder.Property(c => c.CreatedAt).IsRequired();

         
            builder.HasOne(c => c.ApplicationUser)
              .WithMany(u => u.Comments)
              .HasForeignKey(c => c.ApplicationUserId)
              .IsRequired()
              .OnDelete(DeleteBehavior.Restrict);  
          
            builder.HasOne(c => c.Topic)
                .WithMany(t => t.Comments)
                .HasForeignKey(c => c.TopicId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);
            // i tried :NoAction, Restrict, Cascade 
        }
    }
}

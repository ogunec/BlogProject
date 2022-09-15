using BlogPro.MODEL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPro.MAP.Configurations
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.Property(x => x.AuthorName).HasMaxLength(50);
            builder.Property(x => x.AuthorImage).HasMaxLength(100);
            builder.Property(x => x.AuthorDetail).HasMaxLength(250);
        }
    }
}

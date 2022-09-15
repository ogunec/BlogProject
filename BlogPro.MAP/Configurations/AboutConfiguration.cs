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
    public class AboutConfiguration : IEntityTypeConfiguration<About>
    {
        public void Configure(EntityTypeBuilder<About> builder)
        {
            builder.Property(x => x.AboutContent1).HasMaxLength(500);
            builder.Property(x => x.AboutContent2).HasMaxLength(500);
            builder.Property(x => x.AboutImage1).HasMaxLength(100);
            builder.Property(x => x.AboutImage2).HasMaxLength(100);
        }
    }
}

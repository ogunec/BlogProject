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
	public class BlogConfiguration : IEntityTypeConfiguration<Blog>
	{
		public void Configure(EntityTypeBuilder<Blog> builder)
		{
			
			builder.Property(x => x.BlogTitle).IsRequired().HasMaxLength(100);
			builder.Property(x => x.BlogImage).IsRequired().HasMaxLength(100);
			builder.Property(x => x.BlogDate).IsRequired();
			builder.Property(x => x.BlogContent).IsRequired();
		}
	}
}

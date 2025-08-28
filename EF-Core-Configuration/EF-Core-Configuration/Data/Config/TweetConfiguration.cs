using EF_Core_Configuration.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EF_Core_Configuration.Data.Config
{
    public class TweetConfiguration : IEntityTypeConfiguration<Tweet>
    {
        public void Configure(EntityTypeBuilder<Tweet> builder)
        {
            builder.ToTable("tblTweets");

        }
    }
}

using BlazorMultiApp.Identity.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlazorMultiApp.Identity.Infrastructure.SchemaConfigurations
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(user => user.FirstName)
                .IsRequired()
                .HasMaxLength(25);

            builder.Property(user => user.LastName)
                .IsRequired()
                .HasMaxLength(25);
        }
    }
}

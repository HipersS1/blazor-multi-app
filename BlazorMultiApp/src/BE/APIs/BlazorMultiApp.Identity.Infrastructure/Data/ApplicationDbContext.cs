using BlazorMultiApp.Identity.Domain.Models;
using BlazorMultiApp.Identity.Infrastructure.SchemaConfigurations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlazorMultiApp.Identity.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            ConfigureEntities(builder);
            SeedAdminAcount(builder);
            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.EnableDetailedErrors();
        }

        private void ConfigureEntities(ModelBuilder builder)
        {
            new UserConfiguration().Configure(builder.Entity<User>());
        }

        private void SeedAdminAcount(ModelBuilder builder)
        {
            var email = "admin@adm.com";
            var passwordHasher = new PasswordHasher<User>();
            string password = "_String123";


            var admin = new User
            {
                Id = new Guid("8E721037-C9FC-4CA0-80DA-B414F5B72D36"),
                UserName = email,
                NormalizedUserName = email.ToUpper(),
                NormalizedEmail = email.ToUpper(),
                FirstName = "Jim",
                LastName = "Cool",
                Email = email,
                EmailConfirmed = true
            };

            admin.PasswordHash = passwordHasher.HashPassword(admin, password);
            admin.SecurityStamp = Guid.NewGuid().ToString();
            builder.Entity<User>().HasData(admin);
        }
    }
}

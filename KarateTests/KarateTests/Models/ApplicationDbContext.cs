using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace KarateTests.Models
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=KarateTests.db", options =>
            {
                options.MigrationsAssembly(this.GetType().Assembly.FullName);
            });
            base.OnConfiguring(optionsBuilder);
        }
    }

    public static class ApplicationDbInitializer
    {
        public static async Task SeedUsers(UserManager<IdentityUser> userManager)
        {
            var user = await userManager.FindByEmailAsync("daniel@plawgo.pl");

            if (user == null)
            {
                user = new IdentityUser
                {
                    UserName = "daniel@plawgo.pl",
                    Email = "daniel@plawgo.pl"
                };

                await userManager.CreateAsync(user, "Password9.");
            }
        }
    }
}

using Api.Data.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Api.Infrastructure.Seeder
{
    public class UserSeeder
    {

        public static async Task SeedAsync(UserManager<AppUser> _userManager)
        {
            var usersCount = await _userManager.Users.CountAsync();
            if (usersCount <= 2)
            {
                var defaultuser = new AppUser()
                {
                    UserName = "admin",
                    Email = "admin@project.com",
                    FullName = "JohnAshraf",
                    PhoneNumber = "2121212",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                };
                _ = await _userManager.CreateAsync(defaultuser, "M123_m");
                _ = await _userManager.AddToRoleAsync(defaultuser, "Admin");
            }
        }
    }
}

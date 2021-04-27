using System.Threading.Tasks;
using backend.Configs;
using Microsoft.AspNetCore.Identity;

namespace backend.DbContexts.Seeds
{
    public static class DefaultRoles
    {
        public static async Task SeedAsync(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            await roleManager.CreateAsync(new IdentityRole(Roles.Customer.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.Admin.ToString()));
        }
    }
}
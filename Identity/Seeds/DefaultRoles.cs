using Application.Enums;
using Identity.Models;
using Microsoft.AspNetCore.Identity;

namespace Identity.Seeds
{
    public static class DefaultRoles
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            // Llenado de roles
            var roleAdministrator = await roleManager.FindByNameAsync(Roles.Administrator.ToString());
            if (roleAdministrator == null)
                await roleManager.CreateAsync(new IdentityRole(Roles.Administrator.ToString()));

            var roleBasic = await roleManager.FindByNameAsync(Roles.Basic.ToString());
            if (roleBasic == null)
                await roleManager.CreateAsync(new IdentityRole(Roles.Basic.ToString()));
        }
    }
}

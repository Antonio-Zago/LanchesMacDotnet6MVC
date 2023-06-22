using Microsoft.AspNetCore.Identity;

namespace LanchesMacDotnet6MVC.Services
{
    public class SeedRoleUserInitial : ISeedUserRoleInitial
    {
        private readonly UserManager<IdentityUser> userManager;

        private readonly RoleManager<IdentityRole> roleManager;

        public SeedRoleUserInitial(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public void SeedRoles()
        {
            if (!roleManager.RoleExistsAsync("Member").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Member";
                role.NormalizedName = "MEMBER";

                IdentityResult identityResult = roleManager.CreateAsync(role).Result;
            }

            if (!roleManager.RoleExistsAsync("Admin").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Admin";
                role.NormalizedName = "ADMIN";

                IdentityResult identityResult = roleManager.CreateAsync(role).Result;
            }
        }

        public void SeedUsers()
        {
            if (userManager.FindByEmailAsync("usuario@localhost").Result == null)
            {
                IdentityUser identityUser = new IdentityUser();
                identityUser.UserName = "usuario@localhost";
                identityUser.Email = "usuario@localhost";
                identityUser.NormalizedUserName = "USUARIO@LOCALHOST";
                identityUser.NormalizedEmail = "USUARIO@LOCALHOST";
                identityUser.EmailConfirmed = true;
                identityUser.LockoutEnabled = false;
                identityUser.SecurityStamp = Guid.NewGuid().ToString();

                IdentityResult identityResult = userManager.CreateAsync(identityUser, "Zago@%2021").Result;

                if (identityResult.Succeeded)
                {
                    userManager.AddToRoleAsync(identityUser, "Member").Wait();
                }
            }

            if (userManager.FindByEmailAsync("admin@localhost").Result == null)
            {
                IdentityUser identityUser = new IdentityUser();
                identityUser.UserName = "admin@localhost";
                identityUser.Email = "admin@localhost";
                identityUser.NormalizedUserName = "ADMIN@LOCALHOST";
                identityUser.NormalizedEmail = "ADMIN@LOCALHOST";
                identityUser.EmailConfirmed = true;
                identityUser.LockoutEnabled = false;
                identityUser.SecurityStamp = Guid.NewGuid().ToString();

                IdentityResult identityResult = userManager.CreateAsync(identityUser, "Zago@%2021").Result;

                if (identityResult.Succeeded)
                {
                    userManager.AddToRoleAsync(identityUser, "Admin").Wait();
                }
            }
        }
    }
}

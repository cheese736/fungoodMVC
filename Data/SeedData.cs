using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fungoodMVC.Authorization;
using Microsoft.AspNetCore.Identity;

namespace fungoodMVC.Data
{
    public class SeedData
    {
        public static async Task Initialize(IServiceProvider serviceProvider, string userName = "staff@example.com", string password = "1234")
        {
            using (var context = new IdentityDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<IdentityDbContext>>()
            ))
            {
                var managerUid = await EnsureUser(serviceProvider, userName, password);
                await EnsureRole(serviceProvider, managerUid, Constants.StaffRole);
            }
        }
        private static async Task<string> EnsureUser(
            IServiceProvider serviceProvider, string userName, string initPw)
        {
            var userManager = serviceProvider.GetService<UserManager<ApplicationUser>>();
            var user = await userManager.FindByNameAsync(userName);
            if (user == null)
            {
                user = new ApplicationUser
                {
                    UserName = userName,
                    Email = userName,
                    EmailConfirmed = true
                };
                var result = await userManager.CreateAsync(user, initPw);
            }
            if (user == null)
                throw new Exception("User did not get created. check if its password policy problem");
            return user.Id;
        }

        private static async Task<IdentityResult> EnsureRole(
            IServiceProvider serviceProvider, string uid, string role)
        {
            var roleManager = serviceProvider.GetService<RoleManager<IdentityRole>>();

            IdentityResult ir;

            if (await roleManager.RoleExistsAsync(role) == false)
            {
                ir = await roleManager.CreateAsync(new IdentityRole(role));
            }

            var userManager = serviceProvider.GetService<UserManager<ApplicationUser>>();

            var user = await userManager.FindByIdAsync(uid) ?? throw new Exception("User not exist");

            ir = await userManager.AddToRoleAsync(user, role);

            return ir;
        }
    }
}
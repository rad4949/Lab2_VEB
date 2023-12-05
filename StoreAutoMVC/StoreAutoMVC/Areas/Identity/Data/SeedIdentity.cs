using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StoreAutoMVC.Entity;

namespace StoreAutoMVC.Areas.Identity.Data
{
    public class SeedIdentity
    {
        public static void SeedData(IServiceProvider services)
        {
            using (var scope = services.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                //var context = scope.ServiceProvider.GetRequiredService<IdentityDbContext>(); 

                string ADMIN_ID = "02174cf0–9412–4cfe-afbf-59f706d72cf6";
                string USER_ID = "72174cf0–9412–4cfe-afbf-59f706d72cf7";
                string ROLE_ID = "341743f0-asd2–42de-afbf-59kmkkmk72cf";

                if (!roleManager.RoleExistsAsync("admin").Result)
                {
                    var adminRole = new IdentityRole { Id = ROLE_ID, Name = "admin", NormalizedName = "ADMIN", ConcurrencyStamp = ROLE_ID };
                    var userRole = new IdentityRole { Id = USER_ID, Name = "user", NormalizedName = "USER", ConcurrencyStamp = USER_ID };
                    roleManager.CreateAsync(adminRole).Wait();
                    roleManager.CreateAsync(userRole).Wait();
                }

                var user = userManager.FindByEmailAsync("igor16radchuk@gmail.com").Result;

                if (user == null)
                {
                    user = new User
                    {
                        Id = ADMIN_ID,
                        Email = "igor16radchuk@gmail.com",
                        EmailConfirmed = true,
                        UserName = "igor16radchuk@gmail.com",
                        NormalizedUserName = "IGOR16RADCHUK@GMAIL.COM"
                    };
                    user.PasswordHash = new PasswordHasher<User>().HashPassword(user, "Qwerty-0");

                    var result = userManager.CreateAsync(user, "Qwerty-0").Result;

                    if (result.Succeeded)
                    {
                        if (!userManager.GetRolesAsync(user).Result.Contains("admin"))
                        {
                            userManager.AddToRoleAsync(user, "admin").Wait();
                        }
                    }

                   /* context.UserRoles.Add(new IdentityUserRole<string>
                    {
                        RoleId = ROLE_ID,
                        UserId = ADMIN_ID
                    });
                    context.SaveChanges();*/
                }
            }
        }

    }
}

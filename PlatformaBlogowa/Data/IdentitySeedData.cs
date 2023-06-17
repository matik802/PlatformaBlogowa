using System;
using Microsoft.AspNetCore.Identity;
using PlatformaBlogowa.Data;
using PlatformaBlogowa.Utilities;

namespace SeedIdentity.Data
{
	public class IdentitySeedData
	{
		public static async Task Initialize(ApplicationDbContext context,
		UserManager<IdentityUser> userManager,
		RoleManager<IdentityRole> roleManager)
		{

			context.Database.EnsureCreated();

			string password = "Qwerty#123";

			if (await roleManager.FindByNameAsync(Role.Admin) == null)
			{
				await roleManager.CreateAsync(new IdentityRole(Role.Admin));
			}

			if (await roleManager.FindByNameAsync(Role.User) == null)
			{
				await roleManager.CreateAsync(new IdentityRole(Role.User));
			}

			if (await userManager.FindByNameAsync("admin@admin.com") == null)
			{
				var user = new IdentityUser
				{
					UserName = "admin@admin.com",
					Email = "admin@admin.com",
					PhoneNumber = "6902341234"
				};

				var result = await userManager.CreateAsync(user);
				if (result.Succeeded)
				{
					await userManager.AddPasswordAsync(user, password);
					await userManager.AddToRoleAsync(user, Role.Admin);
				}
			}
		}
	}
}
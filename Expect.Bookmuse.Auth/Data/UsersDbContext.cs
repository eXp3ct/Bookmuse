using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Expect.Bookmuse.Auth.Data
{
	public class UsersDbContext : IdentityDbContext
	{
		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.Entity<IdentityUser>().HasData(new IdentityUser
			{
				UserName = "admin",
				PasswordHash = "admin_secret",
				Id = Guid.NewGuid().ToString()
			});
			base.OnModelCreating(builder);
		}
	}
}

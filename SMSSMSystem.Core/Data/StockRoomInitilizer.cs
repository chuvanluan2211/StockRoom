using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SMSSMSystem.Core.Constant;
using SMSSMSystem.Core.Models;

namespace SMSSMSystem.Core.Data
{
    public class StockRoomInitilizer
    {
        private void SeedingData(ModelBuilder modelBuilder)
        {
            List<IdentityRole<Guid>> Roles = new List<IdentityRole<Guid>>
            {
                new IdentityRole<Guid>()
                {
                    Id = Guid.NewGuid(),
                    Name = ListRole.Admin,
                    ConcurrencyStamp = DateTime.Now.ToString(),
                    NormalizedName = ListRole.Admin.ToUpper()
                },
                new IdentityRole<Guid>()
                {
                    Id = Guid.NewGuid(),
                    Name = ListRole.User,
                    ConcurrencyStamp = DateTime.Now.ToString(),
                    NormalizedName = ListRole.User.ToUpper()
                },
            };
            var passwordHasher = new PasswordHasher<Account>();
            List<Account> accounts = new List<Account>
            {
                new Account()
                {
                    Id = Guid.NewGuid(),
                    UserName = "user1@email.com",
                    Email = "user1@email.com",
                    NormalizedEmail = "USER1@EMAIL.COM",
                    NormalizedUserName = "USER1@EMAIL.COM",
                    EmailConfirmed = false,
                    LockoutEnabled = false,
                    SecurityStamp = "",
                    PasswordHash = passwordHasher.HashPassword(null, "123456"),
                },
                new Account()
                {
                    Id = Guid.NewGuid(),
                    UserName = "carowner1@gmail.com",
                    Email = "carowner1@gmail.com",
                    NormalizedEmail = "CAROWNER1@GMAIL.COM",
                    NormalizedUserName = "CAROWNER1@GMAIL.COM",
                    SecurityStamp = "",
                    EmailConfirmed = false,
                    LockoutEnabled = false,
                    PasswordHash = passwordHasher.HashPassword(null, "123456"),
                },
                new Account()
                {
                    Id = Guid.NewGuid(),
                    UserName = "admin1@gmail.com",
                    Email = "admin1@gmail.com",
                    NormalizedEmail = "ADMIN1@GMAIL.COM",
                    NormalizedUserName = "ADMIN1@GMAIL.COM",
                    SecurityStamp = "",
                    EmailConfirmed = false,
                    LockoutEnabled = false,
                    PasswordHash = passwordHasher.HashPassword(null, "123456"),
                },
            };
        }
    }
}

using API.DataContext;
using API.Entities;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace API.Data
{
    public class Seed
    {
        public static async Task SeedUses(DatingDbContext dbContext)
        {
            if (await dbContext.Users.AnyAsync()) return;

            var userData = await File.ReadAllTextAsync("Data/UserSeedData.json");

            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            var users = JsonSerializer.Deserialize<List<AppUser>>(userData, options);

            if(users == null) return;

            foreach (var user in users) {
                using var hmac = new HMACSHA512();
                user.UserName = user.UserName.ToLower();
                user.Password = hmac.ComputeHash(Encoding.UTF8.GetBytes("Pa$$w0rd"));
                user.PasswordSalt = hmac.Key;

                dbContext.Users.Add(user);
            }
            await dbContext.SaveChangesAsync();
        }
    }
}

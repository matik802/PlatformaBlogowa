using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using PlatformaBlogowa.Data;

namespace PlatformaBlogowa.Services.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public UserRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public void Delete(string UserId)
        {
            var user = _applicationDbContext.Users.FirstOrDefault(u => u.Id == UserId);
            _applicationDbContext.Users.Remove(user);
            _applicationDbContext.SaveChanges();
        }

        public List<IdentityUser> GetAllUsers()
        {
            return _applicationDbContext.Users.ToList();
        }
    }
}

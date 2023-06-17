using Microsoft.AspNetCore.Identity;

namespace PlatformaBlogowa.Services
{
    public interface IUserService
    {
        public void Delete(string UserId);
        public List<IdentityUser> GetAllUsers();
        public IdentityUser GetUserByUserName(string UserName);
        public IdentityUser GetUserById(string Id);
        public void UpdateUser(IdentityUser user);

	}
}

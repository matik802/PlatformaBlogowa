using Microsoft.AspNetCore.Identity;
using PlatformaBlogowa.Services.Repositories;

namespace PlatformaBlogowa.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public void Delete(string UserId)
        {
            _userRepository.Delete(UserId);
        }

        public List<IdentityUser> GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }

        public IdentityUser GetUserByUserName(string UserName)
        {
            return _userRepository.GetUserByUserName(UserName);
        }

        public IdentityUser GetUserById(string Id)
        {
            return _userRepository.GetUserById(Id);
        }

		public void UpdateUser(IdentityUser user)
		{
			_userRepository.UpdateUser(user);
		}
	}
}

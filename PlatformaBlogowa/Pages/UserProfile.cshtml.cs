using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PlatformaBlogowa.Services;

namespace PlatformaBlogowa.Pages
{
    [BindProperties]
	[Authorize]
	public class UserProfileModel : PageModel
    {
        private readonly IUserService _userService;
        public UserProfileModel(IUserService userService)
        {
            _userService= userService;
        }
        public IdentityUser AppUser { get; set; }
        public void OnGet()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            AppUser = _userService.GetUserById(userId);
        }
        public void OnPost(string userId)
        {
			var user = _userService.GetUserById(userId);
            user.UserName= AppUser.UserName;
			_userService.UpdateUser(user);
        }
    }
}

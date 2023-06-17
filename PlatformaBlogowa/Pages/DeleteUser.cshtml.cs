using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PlatformaBlogowa.Services;

namespace PlatformaBlogowa.Pages
{
    public class DeleteUserModel : PageModel
    {
        private readonly IUserService _userService;
        public DeleteUserModel(IUserService userService)
        {
            _userService= userService;
        }
        public IdentityUser AppUser { get; set; }
        public void OnGet(string UserId)
        {
			AppUser = _userService.GetUserById(UserId);
        }
        public IActionResult OnPost(string UserId)
        {
			_userService.Delete(UserId);
            return RedirectToPage("./ManageUsers");
		}
		public IActionResult OnPostReturn()
		{
			return RedirectToPage("./ManageUsers");
		}
	}
}

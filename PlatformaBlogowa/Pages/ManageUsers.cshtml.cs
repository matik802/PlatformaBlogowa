using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PlatformaBlogowa.Services;
using PlatformaBlogowa.Services.Repositories;
using PlatformaBlogowa.Utilities;

namespace PlatformaBlogowa.Pages
{
    [Authorize(Roles = Role.Admin)]
    public class ManageUsersModel : PageModel
    {
        private readonly IUserService _userService;
        public ManageUsersModel(IUserService userService)
        {
            _userService = userService;
        }
        public List<IdentityUser> UsersList { get; set; }
        public void OnGet()
        {
            UsersList = _userService.GetAllUsers();
        }
		public IActionResult OnPostHome()
		{
			return RedirectToPage("./Index");
		}
	}
}

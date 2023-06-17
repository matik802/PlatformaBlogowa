using ContosoUniversity;
using System.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PlatformaBlogowa.Data;
using PlatformaBlogowa.Services;
using PlatformaBlogowa.Models;
using PlatformaBlogowa.ViewModels;
using System.Security.Claims;

namespace PlatformaBlogowa.Pages
{
	[BindProperties]
    public class UserBlogModel : PageModel
    {
        public readonly IUserService _userService;
        public readonly IConfiguration _configuration;
		public readonly IPaginatedListService _paginatedListService;

		public UserBlogModel(IUserService userService, IConfiguration configuration , IPaginatedListService paginatedListService)
		{
			_userService = userService;
            _configuration = configuration;
            _paginatedListService = paginatedListService;
		}
		public string UserName { get; set; }
        public ListPostWithExtrasVM PaginatedPostsVM { get; set; } = default!;
		public PaginatedList<Post> PaginatedPosts { get; set; } = default!;
		public int pageIndex { get; set; }
        public async Task<IActionResult> OnGetAsync(int? pageIndex)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            TempData["userId"] = userId;
            UserName = (string)RouteData.Values["UserName"];
			var user = _userService.GetUserByUserName(UserName);
			PaginatedPosts = await _paginatedListService.DoPaging(pageIndex, UserName);
			PaginatedPostsVM = await _paginatedListService.DoPagingVM(pageIndex, UserName);

			return Page();
        }
        public IActionResult OnPost(int? pageIndex, string? userN = null)
        {
            return RedirectToPage("./UserBlog/" + userN, new { pageIndex = pageIndex });
        }
    }
}

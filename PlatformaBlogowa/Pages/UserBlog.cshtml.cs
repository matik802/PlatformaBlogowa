using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PlatformaBlogowa.Services;

namespace PlatformaBlogowa.Pages
{
    public class UserBlogModel : PageModel
    {
		public readonly IPostService _postService;
		public UserBlogModel(IPostService postService)
		{
			_postService = postService;
		}
		public string UserName { get; set; }
		public void OnGet(string UserName)
        {
			UserName = UserName;
        }
    }
}

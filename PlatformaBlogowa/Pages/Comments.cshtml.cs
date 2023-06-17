using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PlatformaBlogowa.Services;
using PlatformaBlogowa.ViewModels;

namespace PlatformaBlogowa.Pages
{
    [BindProperties]
    public class CommentsModel : PageModel
    {
        public readonly IPostService _postService;
        public CommentsModel(IPostService postService)
        {
            _postService = postService;
        }
        public PostWithExtrasVM PostVM { get; set; }
        public void OnGet(int PostId)
        {
            TempData["UserId"] = User.FindFirstValue(ClaimTypes.NameIdentifier);
			PostVM = _postService.GetPost(PostId);
        }
        public IActionResult OnPostAddComment()
        {
            return RedirectToPage("./AddComment", new { PostId = PostVM.Post.Id });
        }
		public IActionResult OnPostHome()
		{
			return RedirectToPage("./Index");
		}
	}
}

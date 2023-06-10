using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PlatformaBlogowa.Models;
using PlatformaBlogowa.Services;
using PlatformaBlogowa.ViewModels;

namespace PlatformaBlogowa.Pages
{
	[BindProperties]
    public class EditPostModel : PageModel
    {
		public readonly IPostService _postService;
		public EditPostModel(IPostService postService)
		{
			_postService = postService;
		}
		public PostWithExtrasVM PostVM { get; set; }
		public void OnGet(int PostId)
        {
			PostVM = _postService.GetPost(PostId);

        }
		public IActionResult OnPostEditPost()
		{
			_postService.UpdatePost(PostVM.Post);
			return RedirectToPage("./EditPost", new { PostId = PostVM.Post.Id });
		}
		public IActionResult OnPostAddTags()
		{
			return RedirectToPage("./AddTag", new { PostId = PostVM.Post.Id });
		}
		public IActionResult OnPostHome()
		{
			return RedirectToPage("./Index");
		}
    }
}

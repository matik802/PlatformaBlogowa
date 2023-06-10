using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PlatformaBlogowa.Services;
using PlatformaBlogowa.ViewModels;

namespace PlatformaBlogowa.Pages
{
	[BindProperties]
    public class DeletePostModel : PageModel
    {
		public readonly IPostService _postService;
		public DeletePostModel(IPostService postService)
		{
			_postService = postService;
		}
		public PostWithExtrasVM PostVM { get; set; }
		public void OnGet(int PostId)
		{
			PostVM = _postService.GetPost(PostId);

		}
        public IActionResult OnPostDeletePost()
        {
            _postService.DeletePost(PostVM.Post);
            return RedirectToPage("./Index");
        }
        public IActionResult OnPostHome()
		{
			return RedirectToPage("./Index");
		}
	}
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PlatformaBlogowa.Services;
using PlatformaBlogowa.ViewModels;

namespace PlatformaBlogowa.Pages
{
	[BindProperties]
	[Authorize]
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
			foreach(var comment in PostVM.Comments)
			{
				_postService.DeleteComment(comment);
			}
			foreach(var tag in PostVM.Tags)
			{
				_postService.DeleteTag(tag);
			}
			foreach (var picture in PostVM.Pictures)
			{
				_postService.DeletePicture(picture);
			}
			_postService.DeletePost(PostVM.Post);
            return RedirectToPage("./Index");
        }
        public IActionResult OnPostHome()
		{
			return RedirectToPage("./Index");
		}
	}
}

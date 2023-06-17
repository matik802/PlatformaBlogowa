using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PlatformaBlogowa.Models;
using PlatformaBlogowa.Services;
using PlatformaBlogowa.ViewModels;

namespace PlatformaBlogowa.Pages
{
    [BindProperties]
	[Authorize]
	public class EditTagModel : PageModel
    {
		public readonly IPostService _postService;
		public EditTagModel(IPostService postService)
		{
			_postService = postService;
		}
		public Tag Tag { get; set; }
		public void OnGet(int PostId, int TagId)
        {
			Tag = _postService.GetPost(PostId).Tags.FirstOrDefault(u => u.Id == TagId);
        }
		public IActionResult OnPostEditTag()
		{
			_postService.UpdateTag(Tag);
			return RedirectToPage("./EditPost", new { PostId = Tag.PostId });
		}
		public IActionResult OnPostReturn()
		{
			return RedirectToPage("./AddTag", new { PostId = Tag.PostId });
		}
	}
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PlatformaBlogowa.Models;
using PlatformaBlogowa.Services;

namespace PlatformaBlogowa.Pages
{
	[BindProperties]
    public class DeleteTagModel : PageModel
    {
		public readonly IPostService _postService;
		public DeleteTagModel(IPostService postService)
		{
			_postService = postService;
		}
		public Tag Tag { get; set; }
		public void OnGet(int PostId, int TagId)
		{
			Tag = _postService.GetPost(PostId).Tags.FirstOrDefault(u => u.Id == TagId);
		}
		public IActionResult OnPostDeleteTag()
		{
			_postService.DeleteTag(Tag);
			return RedirectToPage("./AddTag", new { PostId = Tag.PostId });
		}
		public IActionResult OnPostReturn()
		{
			return RedirectToPage("./AddTag", new { PostId = Tag.PostId });
		}
	}
}

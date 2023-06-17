using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PlatformaBlogowa.Models;
using PlatformaBlogowa.Services;

namespace PlatformaBlogowa.Pages
{
	[BindProperties]
	[Authorize]
	public class DeletePictureModel : PageModel
    {
		public readonly IPostService _postService;
		public DeletePictureModel(IPostService postService)
		{
			_postService = postService;
		}
		public Picture Picture { get; set; }
		public void OnGet(int PostId, int PictureId)
		{
			Picture = _postService.GetPost(PostId).Pictures.FirstOrDefault(u => u.Id == PictureId);
		}
		public IActionResult OnPostDeletePicture()
		{
			_postService.DeletePicture(Picture);
			return RedirectToPage("./AddPicture", new { PostId = Picture.PostId });
		}
		public IActionResult OnPostReturn()
		{
			return RedirectToPage("./AddPicture", new { PostId = Picture.PostId });
		}
	}
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PlatformaBlogowa.Models;
using PlatformaBlogowa.Services;
using PlatformaBlogowa.ViewModels;

namespace PlatformaBlogowa.Pages
{
	[BindProperties]
    public class AddPictureModel : PageModel
    {
		public readonly IPostService _postService;
		public AddPictureModel(IPostService postService)
		{
			_postService = postService;
		}
		public Picture Picture { get; set; }
		public PostWithExtrasVM PostVM { get; set; }
		public void OnGet(int PostId)
        {
			TempData["PostId"] = PostId;
			PostVM = _postService.GetPost(PostId);
        }
		public IActionResult OnPost()
		{
			byte[] data = null;

			if (Picture.ImageFile != null)
			{
				using (Stream fs = Picture.ImageFile.OpenReadStream())
				{
					using (BinaryReader br = new BinaryReader(fs))
					{
						data = br.ReadBytes((Int32)fs.Length);
					}
					Picture.ImageData = Convert.ToBase64String(data,0, data.Length);
				}
                Picture.PostId = (int)TempData["PostId"];
                _postService.AddPicture(Picture);
			}
            return RedirectToPage("./AddPicture", new { PostId = Picture.PostId });
		}
		public IActionResult OnPostHome()
		{
            return RedirectToPage("./Index");
        }
        public IActionResult OnPostReturn()
        {
            return RedirectToPage("./AddTag", new { PostId = Picture.PostId });
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PlatformaBlogowa.Models;
using PlatformaBlogowa.Services;

namespace PlatformaBlogowa.Pages
{
    [BindProperties]
    public class EditPictureModel : PageModel
    {
        public readonly IPostService _postService;
        public EditPictureModel(IPostService postService)
        {
            _postService = postService;
        }
        public Picture Picture { get; set; }
        public void OnGet(int PostId, int PictureId)
        {
            Picture = _postService.GetPost(PostId).Pictures.FirstOrDefault(u => u.Id == PictureId);
        }
        public IActionResult OnPostEditPicture()
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
                    Picture.ImageData = Convert.ToBase64String(data, 0, data.Length);
                }
                _postService.UpdatePicture(Picture);
            }
            return RedirectToPage("./AddPicture", new { PostId = Picture.PostId });
        }
		public IActionResult OnPostReturn()
		{
			return RedirectToPage("./AddPicture", new { PostId = Picture.PostId });
		}
	}
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PlatformaBlogowa.Models;
using PlatformaBlogowa.Services;

namespace PlatformaBlogowa.Pages
{
	[BindProperties]
	[Authorize]
	public class AddTagModel : PageModel
    {
		public readonly IPostService _postService;
		public AddTagModel(IPostService postService)
		{
			_postService = postService;
		}
		public Post Post { get; set; }
		public Tag Tag { get; set; }
		public List<Tag> Tags { get; set; }
		public void OnGet(int PostId)
        {
			var PostVM =  _postService.GetPost(PostId);
			Post = PostVM.Post;
			Tags = PostVM.Tags;
        }
		public IActionResult OnPostAddTag()
		{
            Tag.PostId = Post.Id;
            if (ModelState.ErrorCount == 1)
			{  
                _postService.AddTag(Tag);
            }
            return RedirectToPage("./AddTag",new { PostId = Post.Id });
		}
		public IActionResult OnPostAddPicture()
		{
			return RedirectToPage("./AddPicture", new { PostId = Post.Id });
		}
		public IActionResult OnPostReturn()
		{
			return RedirectToPage("./EditPost", new { PostId = Post.Id});
		}
	}
}

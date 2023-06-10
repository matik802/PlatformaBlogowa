using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PlatformaBlogowa.Models;
using PlatformaBlogowa.Services;

namespace PlatformaBlogowa.Pages
{
	[BindProperties]
    public class AddCommentModel : PageModel
    {
		public readonly IPostService _postService;
		public AddCommentModel(IPostService postService)
		{
			_postService = postService;
		}
		public Comment Comment { get; set; }
		public void OnGet(int PostId)
        {
			Comment = new Comment();
			Comment.PostId = PostId;
        }
		public IActionResult OnPostAddComment()
		{
            Comment.Created = DateTime.Now;
            _postService.AddComment(Comment);
			return RedirectToPage("./Comments", new { PostId = Comment.PostId });
		}
    }
}

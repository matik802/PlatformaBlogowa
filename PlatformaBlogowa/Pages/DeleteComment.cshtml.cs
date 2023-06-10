using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PlatformaBlogowa.Models;
using PlatformaBlogowa.Services;

namespace PlatformaBlogowa.Pages
{
	[BindProperties]
	public class DeleteCommentModel : PageModel
    {
		public readonly IPostService _postService;
		public DeleteCommentModel(IPostService postService)
		{
			_postService = postService;
		}
		public Comment Comment { get; set; }
		public void OnGet(int PostId, int CommentId)
        {
			Comment = _postService.GetPost(PostId).Comments.FirstOrDefault(u => u.Id == CommentId);
        }
		public IActionResult OnPostDeleteComment()
		{
			_postService.DeleteComment(Comment);
			return RedirectToPage("./Comments", new { PostId = Comment.PostId });
		}
		public IActionResult OnPostReturn()
		{
			return RedirectToPage("./Comments", new { PostId = Comment.PostId });
		}
	}
}

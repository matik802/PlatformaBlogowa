using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PlatformaBlogowa.Models;
using PlatformaBlogowa.Services;
using PlatformaBlogowa.Utilities;

namespace PlatformaBlogowa.Pages
{
	[BindProperties]
	[Authorize]
	public class DeleteCommentModel : PageModel
    {
		public readonly IPostService _postService;
		public readonly IUserService _userService;
		public DeleteCommentModel(IPostService postService, IUserService userService)
		{
			_postService = postService;
			_userService = userService;
		}
		public Comment Comment { get; set; }
		public IActionResult OnGet(int PostId, int CommentId)
        {
			string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
			var user = _userService.GetUserById(userId);
			var post = _postService.GetPost(PostId).Post;
			Comment = _postService.GetPost(PostId).Comments.FirstOrDefault(u => u.Id == CommentId);
			if (user != null)
			{
                if (!(user.Id == post.UserId || user.Id == Comment.UserId || User.IsInRole(Role.Admin)))
                {
                    return RedirectToPage("./Comments", new { PostId = Comment.PostId });
                }
            }
			return Page();
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

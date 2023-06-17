using System.Net;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PlatformaBlogowa.Models;
using PlatformaBlogowa.Services;
using PlatformaBlogowa.Utilities;

namespace PlatformaBlogowa.Pages
{
	[BindProperties]
	[Authorize]
    public class AddCommentModel : PageModel
    {
		public readonly IPostService _postService;
		private readonly IHttpContextAccessor _httpContextAccessor;
		public AddCommentModel(IPostService postService, IHttpContextAccessor httpContextAccessor)
		{
			_postService = postService;
			_httpContextAccessor = httpContextAccessor;
		}
		public Comment Comment { get; set; }
		public void OnGet(int PostId)
        {
			Comment = new Comment();
			Comment.PostId = PostId;
			//Comment.Ip = HttpContext?.Connection.RemoteIpAddress?.ToString();
		}
		public IActionResult OnPostAddComment()
		{
			Comment.Ip = ClientIp.GetClientIp();
			Comment.Created = DateTime.Now;
			Comment.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
			_postService.AddComment(Comment);
			return RedirectToPage("./Comments", new { PostId = Comment.PostId });
		}
		public IActionResult OnPostReturn()
		{
			return RedirectToPage("./Comments", new { PostId = Comment.PostId });
        }
    }
}

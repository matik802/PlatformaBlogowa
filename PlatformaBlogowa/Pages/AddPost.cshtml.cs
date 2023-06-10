using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PlatformaBlogowa.Models;
using PlatformaBlogowa.Services;

namespace PlatformaBlogowa.Pages
{
    [BindProperties]
    public class AddPostModel : PageModel
    {
        public readonly IPostService _postService;
        public AddPostModel(IPostService postService)
        {
            _postService= postService;
        }
        public Post Post { get; set; }
        public void OnGet()
        {

        }
        public IActionResult OnPostAddPost()
        {
            Post.Created = DateTime.Now;
            Post.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (ModelState.ErrorCount == 1)
            {
                _postService.AddPost(Post);
                return RedirectToPage("./AddTag", new { PostId = Post.Id });
            }
            return Page();
        }
    }
}

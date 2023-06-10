using System.Security.Claims;
using ContosoUniversity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PlatformaBlogowa.Models;
using PlatformaBlogowa.Services;
using PlatformaBlogowa.ViewModels;

namespace PlatformaBlogowa.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public readonly IPostService _postService;

        public IndexModel(ILogger<IndexModel> logger, IPostService postService)
        {
            _logger = logger;
            _postService = postService;
        }
        public ListPostWithExtrasVM PostsVM { get; set; }
        public PostWithExtrasVM[] PostVM { get; set; }

        public async void OnGet(int? pageIndex)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            TempData["userId"] = userId;
            PostsVM = _postService.GetAllPosts();

            PostVM = new PostWithExtrasVM[10];
            int Count = 0;
            foreach (var post in PostsVM.PostsList)
            {
                PostVM[Count] = post;
                Count++;
                if (Count == 10) break;
            }
        }
    }
}
using System.Diagnostics;
using ContosoUniversity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using PlatformaBlogowa.Data;
using PlatformaBlogowa.Models;
using PlatformaBlogowa.Pages;

namespace PlatformaBlogowa.Services.Repositories
{
	public class PaginatedListRepository : IPaginatedListRepository
	{
		private readonly ApplicationDbContext _applicationDbContext;
		private readonly IConfiguration _configuration;
		public readonly IUserService _userService;
		public PaginatedListRepository(ApplicationDbContext applicationDbContext, IConfiguration configuration, IUserService userService)
		{
			_applicationDbContext = applicationDbContext;
			_configuration = configuration;
			_userService = userService;
		}
		public async Task<PaginatedList<Post>> DoPaging(int? pageIndex = 1, string? UserName = null)
		{
			if (!string.IsNullOrEmpty(UserName))
			{
				var user = _userService.GetUserByUserName(UserName);
				var posts = _applicationDbContext.Posts.Where(u => u.UserId == user.Id);
			
				IQueryable<Post> FormIQ = from s in posts
										  select s;
				FormIQ = FormIQ.OrderByDescending(s => s.Created);
				var pageSize = _configuration.GetValue("PageSize", 4);
				return await PaginatedList<Post>.CreateAsync(
					FormIQ, pageIndex ?? 1, pageSize);
            }
            else
            {
                var user = _userService.GetUserByUserName(UserName);
                var posts = _applicationDbContext.Posts;

                IQueryable<Post> FormIQ = from s in posts
                                          select s;
                FormIQ = FormIQ.OrderByDescending(s => s.Created);
                var pageSize = _configuration.GetValue("PageSize", 4);
                return await PaginatedList<Post>.CreateAsync(
                    FormIQ, pageIndex ?? 1, pageSize);
            }
        }
	}
}
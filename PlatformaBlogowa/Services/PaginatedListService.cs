using ContosoUniversity;
using Microsoft.Extensions.Hosting;
using PlatformaBlogowa.Models;
using PlatformaBlogowa.Services.Repositories;
using PlatformaBlogowa.ViewModels;

namespace PlatformaBlogowa.Services
{
	public class PaginatedListService : IPaginatedListService
	{
		private readonly IPaginatedListRepository _paginatedListRepository;
		private readonly IPostRepository _postRepository;
		public PaginatedListService(IPaginatedListRepository paginatedListRepository, IPostRepository postRepository)
		{
			_paginatedListRepository = paginatedListRepository;
			_postRepository = postRepository;
		}

		public async Task<PaginatedList<Post>> DoPaging(int? pageIndex = 1, string? UserName = null)
		{
			return await _paginatedListRepository.DoPaging(pageIndex, UserName);
		}

		public async Task<ListPostWithExtrasVM> DoPagingVM(int? pageIndex = 1, string? UserName = null)
		{
			var pagiantedList = await _paginatedListRepository.DoPaging(pageIndex, UserName);
			ListPostWithExtrasVM PostsVMList = new ListPostWithExtrasVM();
			PostsVMList.PostsList = new List<PostWithExtrasVM>();
			foreach (var var in pagiantedList)
			{
				var post = new PostWithExtrasVM();
				post.Post = _postRepository.GetPost(var.Id);
				post.Tags = _postRepository.GetAllTags(var.Id);
				post.Comments = _postRepository.GetAllComments(var.Id);
				post.Pictures = _postRepository.GetAllPictures(var.Id);
				PostsVMList.PostsList.Add(post);
			}
			return PostsVMList;
		}
	}
}

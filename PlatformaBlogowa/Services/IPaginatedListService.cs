﻿using ContosoUniversity;
using PlatformaBlogowa.Models;
using PlatformaBlogowa.ViewModels;

namespace PlatformaBlogowa.Services
{
	public interface IPaginatedListService
	{
		public Task<ListPostWithExtrasVM> DoPagingVM(int? pageIndex = 1, string? UserName = null);
		public Task<PaginatedList<Post>> DoPaging(int? pageIndex = 1, string? UserName = null);
	}
}

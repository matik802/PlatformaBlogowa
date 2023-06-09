﻿using ContosoUniversity;
using PlatformaBlogowa.Models;

namespace PlatformaBlogowa.Services.Repositories
{
	public interface IPaginatedListRepository
	{
		public Task<PaginatedList<Post>> DoPaging(int? pageIndex = 1, string? UserName = null);
	}
}

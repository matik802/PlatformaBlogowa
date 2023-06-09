﻿using Microsoft.AspNetCore.Identity;

namespace PlatformaBlogowa.Services.Repositories
{
    public interface IUserRepository
    {
        public void Delete(string UserId);
        public List<IdentityUser> GetAllUsers();
        public IdentityUser GetUserByUserName(string UserName);
        public IdentityUser GetUserById(string Id);
        public void UpdateUser(IdentityUser user);
    }
}

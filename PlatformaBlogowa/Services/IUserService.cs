﻿using Microsoft.AspNetCore.Identity;

namespace PlatformaBlogowa.Services
{
    public interface IUserService
    {
        public void Delete(string UserId);
        public List<IdentityUser> GetAllUsers();
    }
}

using Microsoft.AspNetCore.Cors.Infrastructure;
using PlatformaBlogowa.Services;
using PlatformaBlogowa.Services.Repositories;

namespace PlatformaBlogowa.Utilities
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddProjectService(this
        IServiceCollection services)
        {
            services.AddTransient<IPostService, PostService>();
            services.AddTransient<IPostRepository, PostRepository>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IUserRepository, UserRepository>();
            return services;
        }
    }
}

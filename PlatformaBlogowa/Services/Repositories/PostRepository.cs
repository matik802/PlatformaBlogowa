using System.Configuration;
using System.Linq.Expressions;
using ContosoUniversity;
using PlatformaBlogowa.Data;
using PlatformaBlogowa.Models;

namespace PlatformaBlogowa.Services.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IConfiguration _configuration;
        public PostRepository(ApplicationDbContext applicationDbContext, IConfiguration configuration)
        {
            _applicationDbContext = applicationDbContext;
            _configuration = configuration;
        }
        public void Add(Post? Post = null, Tag? Tag = null, Comment? Comment = null, Picture? Picture = null)
        {
            if (Post != null) 
            {
                _applicationDbContext.Posts.Add(Post);
                _applicationDbContext.SaveChanges();
            }
            if (Tag != null) 
            {
                _applicationDbContext.Tags.Add(Tag);
                _applicationDbContext.SaveChanges();
            }
            if (Comment != null)
            {
                _applicationDbContext.Comments.Add(Comment);
                _applicationDbContext.SaveChanges();
            }
            if (Picture != null)
            {
                _applicationDbContext.Pictures.Add(Picture);
                _applicationDbContext.SaveChanges();
            }

        }

        public void Delete(Post? Post = null, Tag? Tag = null, Comment? Comment = null, Picture? Picture = null)
        {
            if (Post != null)
            {
                _applicationDbContext.Posts.Remove(Post);
                _applicationDbContext.SaveChanges();
            }
            if (Tag != null)
            {
                _applicationDbContext.Tags.Remove(Tag);
                _applicationDbContext.SaveChanges();
            }
            if (Comment != null)
            {
                _applicationDbContext.Comments.Remove(Comment);
                _applicationDbContext.SaveChanges();
            }
            if (Picture != null)
            {
                _applicationDbContext.Pictures.Remove(Picture);
                _applicationDbContext.SaveChanges();
            }
        }

        public void Update(Post? Post = null, Tag? Tag = null, Comment? Comment = null, Picture? Picture = null)
        {
            if (Post != null)
            {
                _applicationDbContext.Posts.Update(Post);
                _applicationDbContext.SaveChanges();
            }
            if (Tag != null)
            {
                _applicationDbContext.Tags.Update(Tag);
                _applicationDbContext.SaveChanges();
            }
            if (Comment != null)
            {
                _applicationDbContext.Comments.Update(Comment);
                _applicationDbContext.SaveChanges();
            }
            if (Picture != null)
            {
                _applicationDbContext.Pictures.Update(Picture);
                _applicationDbContext.SaveChanges();
            }
        }

        public Post GetPost(int PostId)
        {
            if (PostId != null)
                return _applicationDbContext.Posts.FirstOrDefault(u => u.Id == PostId);
            return null;
        }

        public List<Post> GetAllPosts(string? UserId)
        {
            if (UserId != null)
                return _applicationDbContext.Posts.Where(u => u.UserId == UserId).ToList();
            return _applicationDbContext.Posts.ToList();
        }
        public List<Comment> GetAllComments(int? PostId)
        {
            if (PostId != null)
                return _applicationDbContext.Comments.Where(u => u.PostId == PostId).ToList();
            return _applicationDbContext.Comments.ToList();
        }
        public List<Tag> GetAllTags(int? PostId)
        {
            if (PostId != null)
                return _applicationDbContext.Tags.Where(u => u.PostId == PostId).ToList();
            return _applicationDbContext.Tags.ToList();
        }
        public List<Picture> GetAllPictures(int? PostId)
        {
            if (PostId != null)
                return _applicationDbContext.Pictures.Where(u => u.PostId == PostId).ToList();
            return _applicationDbContext.Pictures.ToList();
        }

        public async void DoPaging(int? pageIndex)
        {
            IQueryable<Post> FormIQ = from s in _applicationDbContext.Posts
                                      select s;
            FormIQ = FormIQ.OrderByDescending(s => s.Created);
            var pageSize = _configuration.GetValue("PageSize", 4);
            var Post = await PaginatedList<Post>.CreateAsync(
                FormIQ, pageIndex ?? 1, pageSize);
        }
    }
}

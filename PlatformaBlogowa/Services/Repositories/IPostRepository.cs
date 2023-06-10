using ContosoUniversity;
using PlatformaBlogowa.Models;

namespace PlatformaBlogowa.Services.Repositories
{
    public interface IPostRepository
    {
        public void Add(Post? Post = null, Tag? Tag = null, Comment? Comment = null, Picture? Picture = null);
        public void Update(Post? Post = null, Tag? Tag = null, Comment? Comment = null, Picture? Picture = null);
        public void Delete(Post? Post = null, Tag? Tag = null, Comment? Comment = null, Picture? Picture = null);
        public Post GetPost(int PostId);
        public List<Post> GetAllPosts(string? UserId);
        public List<Comment> GetAllComments(int? PostId);
        public List<Tag> GetAllTags(int? PostId);
        public List<Picture> GetAllPictures(int? PostId);
    }
}

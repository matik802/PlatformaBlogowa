using ContosoUniversity;
using PlatformaBlogowa.Models;
using PlatformaBlogowa.ViewModels;

namespace PlatformaBlogowa.Services
{
    public interface IPostService
    {
        public void AddPost(Post post);
        public void UpdatePost(Post Post);
        public void DeletePost(Post Post);
        public void AddTag(Tag Tag);
        public void UpdateTag(Tag Tag);
        public void DeleteTag(Tag Tag);
        public void AddComment(Comment Comment);
        public void UpdateComment(Comment Comment);
        public void DeleteComment(Comment Comment);
        public void AddPicture(Picture Picture);
        public void UpdatePicture(Picture Picture);
        public void DeletePicture(Picture Picture);
        public PostWithExtrasVM GetPost(int PostId);
        public ListPostWithExtrasVM GetAllPosts(string? UserId = null);
        /*
        public List<Comment> GetAllComments(int? PostId);
        public List<Tag> GetAllTags(int? PostId);
        public List<Picture> GetPictures(int? PostId);
        */
    }
}

using ContosoUniversity;
using PlatformaBlogowa.Models;
using PlatformaBlogowa.Services.Repositories;
using PlatformaBlogowa.ViewModels;

namespace PlatformaBlogowa.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        public PostService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }
        public void AddPost(Post Post)
        {
            _postRepository.Add(Post);
        }

        public void DeletePost(Post Post)
        {
            _postRepository.Delete(Post);
        }
        public void UpdatePost(Post Post)
        {
            _postRepository.Update(Post);
        }
        public PostWithExtrasVM GetPost(int PostId)
        {
            var post = new PostWithExtrasVM();
            post.Post = _postRepository.GetPost(PostId);
            post.Tags = _postRepository.GetAllTags(PostId);
            post.Comments = _postRepository.GetAllComments(PostId);
            post.Pictures = _postRepository.GetAllPictures(PostId);
            return post;
        }

        public ListPostWithExtrasVM GetAllPosts(string? UserId = null)
        {
			ListPostWithExtrasVM PostsVMList = new ListPostWithExtrasVM();
			PostsVMList.PostsList = new List<PostWithExtrasVM>();
            var  posts = _postRepository.GetAllPosts(UserId);
            foreach (var var in posts) 
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

        public void AddTag(Tag Tag)
        {
            _postRepository.Add(Tag:Tag);
        }

        public void UpdateTag(Tag Tag)
        {
            _postRepository.Update(Tag:Tag);
        }

        public void DeleteTag(Tag Tag)
        {
            _postRepository.Delete(Tag:Tag);
        }

        public void AddComment(Comment Comment)
        {
            _postRepository.Add(Comment:Comment);
        }

        public void UpdateComment(Comment Comment)
        {
            _postRepository.Update(Comment: Comment);
        }

        public void DeleteComment(Comment Comment)
        {
            _postRepository.Delete(Comment: Comment);
        }

        public void AddPicture(Picture Picture)
        {
            _postRepository.Add(Picture:Picture);
        }

        public void UpdatePicture(Picture Picture)
        {
            _postRepository.Update(Picture: Picture);
        }

        public void DeletePicture(Picture Picture)
        {
            _postRepository.Delete(Picture: Picture);
        }
    }
}

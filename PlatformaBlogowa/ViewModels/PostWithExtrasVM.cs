using PlatformaBlogowa.Models;

namespace PlatformaBlogowa.ViewModels
{
    public class PostWithExtrasVM
    {
        public Post Post { get; set; }
        public List<Tag> Tags { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Picture> Pictures { get; set; }
    }
}

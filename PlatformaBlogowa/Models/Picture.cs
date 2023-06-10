using System.ComponentModel.DataAnnotations.Schema;
using MessagePack;

namespace PlatformaBlogowa.Models
{
    public class Picture
    {
        [Key("Id")]
        public int Id { get; set; }
        public string ImageData { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
        [ForeignKey("PostId")]
        public int PostId { get; set; }
    }
}

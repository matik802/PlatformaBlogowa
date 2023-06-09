using System.ComponentModel.DataAnnotations.Schema;
using MessagePack;

namespace PlatformaBlogowa.Models
{
    public class Picture
    {
        [Key("Id")]
        public int Id { get; set; }
        //...
        [ForeignKey("PostId")]
        public int PostId { get; set; }
    }
}

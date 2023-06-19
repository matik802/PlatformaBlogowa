using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlatformaBlogowa.Models
{
    public class Tag
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name="Tag")]
        public string Name { get; set; }
        [ForeignKey("postId")]
        public int PostId { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlatformaBlogowa.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Description { get; set; }
        [Required]
        public DateTime Created { get; set; }
        [Required]
        public string Ip { get; set; }
        [ForeignKey("PostId")]
        public int PostId { get; set; }
		[ForeignKey("UserId")]
		public string UserId { get; set; }
	}
}

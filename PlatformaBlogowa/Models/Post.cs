using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlatformaBlogowa.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [StringLength(256, ErrorMessage = "Dlugosc {0} nie moze przekroczyc 256 znakow.")]
        public string Description { get; set; }
        [Required]
        public DateTime Created { get; set; }
        [ForeignKey("userId")]
        public string UserId { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace PersonalBloggingPlatformAPI.Domain.Entities
{
    public class Article
    {
        public Guid ArticleId { get; set; }
        [Required, MinLength(3), MaxLength(30)]
        public string Title { get; set; } = null!;
        [Required, MinLength(30), MaxLength(1000)]
        public string BodyText { get; set; } = null!;
        public DateTime PublishingDate { get; set; }
    }
}

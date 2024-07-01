using System.ComponentModel.DataAnnotations;

namespace PersonalBloggingPlatformAPI.Domain.Entities
{
    public class Article
    {
        public Guid ArticleId { get; set; }
        public string Title { get; set; } = null!;
        public string BodyText { get; set; } = null!;
        public DateTime PublishingDate { get; set; }
    }
}

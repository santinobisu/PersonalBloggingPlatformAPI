using System.ComponentModel.DataAnnotations;

namespace PersonalBloggingPlatformAPI.Domain.Entities
{
    public class Article
    {
        public Guid ArticleId { get; set; }
        public string Title { get; set; } = null!;
        public string BodyText { get; set; } = null!;
        public DateTime PublishingDate { get; set; }
        public List<Tag> Tags { get; set; } = null!;

        public Article() { }

        public Article(Guid articleId, string title, string bodyText, DateTime publishingDate, List<Tag> tags)
        {
            ArticleId = articleId;
            Title = title;
            BodyText = bodyText;
            PublishingDate = publishingDate;
            Tags = tags;
        }
    }
}

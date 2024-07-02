using PersonalBloggingPlatformAPI.Domain.Entities;

namespace PersonalBloggingPlatformAPI.Presentation.Contracts.Article.Request
{
    public record UpdateArticleRequest(
        string Title,
        string BodyText,
        List<int?> Tags);
}

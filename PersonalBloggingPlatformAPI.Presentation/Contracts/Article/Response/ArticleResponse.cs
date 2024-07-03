using PersonalBloggingPlatformAPI.Application.DTOs;
using PersonalBloggingPlatformAPI.Domain.Entities;

namespace PersonalBloggingPlatformAPI.Presentation.Contracts.Article.Response
{
    public record ArticleResponse(
        Guid ArticleId,
        string Title,
        string BodyText,
        DateTime PublishingDate,
        List<TagDto> Tags);
}

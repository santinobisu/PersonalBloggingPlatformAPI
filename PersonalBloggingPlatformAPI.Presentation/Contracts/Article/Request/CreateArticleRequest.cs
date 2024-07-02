using PersonalBloggingPlatformAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBloggingPlatformAPI.Presentation.Contracts.Article.Request
{
    public record CreateArticleRequest(
        string Title,
        string BodyText,
        List<int?> Tags);
}

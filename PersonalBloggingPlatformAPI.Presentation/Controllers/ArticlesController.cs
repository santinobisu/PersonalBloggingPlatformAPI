using Microsoft.AspNetCore.Mvc;
using PersonalBloggingPlatformAPI.Application.Interfaces.Articles;
using PersonalBloggingPlatformAPI.Domain.Entities;
using PersonalBloggingPlatformAPI.Presentation.Contracts.Article.Request;
using PersonalBloggingPlatformAPI.Presentation.Contracts.Article.Response;

namespace PersonalBloggingPlatformAPI.Presentation.Controllers
{
    [Route("[controller]")]
    public class ArticlesController : ControllerBase
    {
        private readonly IArticleService _articleService;
        public ArticlesController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        [HttpPost]
        public async Task<ActionResult<ArticleResponse>> CreateArticle([FromBody] CreateArticleRequest request)
        {
            var newArticle = new Article
            {
                ArticleId = new Guid(),
                Title = request.Title,
                BodyText = request.BodyText,
                PublishingDate = DateTime.UtcNow
            };

            await _articleService.CreateArticle(newArticle);

            return CreatedAtGetArticle(newArticle);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ArticleResponse>> GetArticle(Guid id)
        {  
            var getArticleResult = await _articleService.GetArticle(id);

            return getArticleResult is null ? 
                Problem(statusCode: StatusCodes.Status404NotFound, detail: $"Article not found (articleId {id})")
                : Ok(getArticleResult);

        }

        private static ArticleResponse MapArticleResponse(Article article)
        {
            return new ArticleResponse(
                article.ArticleId,
                article.Title,
                article.BodyText,
                article.PublishingDate);
        }

        private ActionResult CreatedAtGetArticle(Article article)
        {
            return CreatedAtAction(
                actionName: nameof(GetArticle),
                routeValues: new {id = article.ArticleId },
                value: MapArticleResponse(article));
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using PersonalBloggingPlatformAPI.Application.DTOs;
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

            Article newArticle = null;

            try
            {
                newArticle = await _articleService.CreateArticle(request.Title, request.BodyText, request.Tags);
            }
            catch (ArgumentException ex)
            {
                return Problem(statusCode: StatusCodes.Status400BadRequest,
                    detail: ex.Message);
            }

            return CreatedAtGetArticle(MapToArticleDto(newArticle));
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ArticleResponse>> GetArticle(Guid id)
        {  
            var getArticleResult = await _articleService.GetArticle(id);

            return getArticleResult is null ? 
                Problem(statusCode: StatusCodes.Status404NotFound, detail: $"Article not found (articleId {id})")
                : Ok(MapToArticleDto(getArticleResult));

        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<ArticleResponse>> DeleteArticle(Guid id)
        {
            var deleteArticleResult = await _articleService.DeleteArticle(id);

            return NoContent();
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<ArticleResponse>> UpdateArticle(Guid id, [FromBody] UpdateArticleRequest request)
        {

            Article result = null;
            try
            {
               result = await _articleService.UpdateArticle(id, request.Title, request.BodyText, request.Tags);
            }

            catch (ArgumentException ex)
            {
                return Problem(statusCode: StatusCodes.Status400BadRequest,
                    detail: ex.Message);
            }

            return result is null ?
                Problem(statusCode: StatusCodes.Status404NotFound, detail: $"Article not found (articleId {id})")
                : Ok(MapToArticleDto(result));
        }

        private static ArticleResponse MapArticleResponse(ArticleDto articleDto)
        {
            return new ArticleResponse(
                articleDto.ArticleId,
                articleDto.Title,
                articleDto.BodyText,
                articleDto.PublishingDate,
                articleDto.Tags);
        }

        private ActionResult CreatedAtGetArticle(ArticleDto articleDto)
        {
            return CreatedAtAction(
                actionName: nameof(GetArticle),
                routeValues: new {id = articleDto.ArticleId },
                value: MapArticleResponse(articleDto));
        }

        private ArticleDto MapToArticleDto(Article article)
        {
            return new ArticleDto
            {
                ArticleId = article.ArticleId,
                Title = article.Title,
                BodyText = article.BodyText,
                PublishingDate = article.PublishingDate,
                Tags = article.Tags.Select(t => new TagDto { TagId = t.TagId, Name = t.Name }).ToList()
            };
        }
    }
}

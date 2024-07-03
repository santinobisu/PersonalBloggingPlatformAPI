using Microsoft.AspNetCore.Mvc;
using PersonalBloggingPlatformAPI.Application.DTOs;
using PersonalBloggingPlatformAPI.Application.Interfaces.Articles;
using PersonalBloggingPlatformAPI.Application.Interfaces.Tags;
using PersonalBloggingPlatformAPI.Domain.Entities;
using PersonalBloggingPlatformAPI.Presentation.Contracts.Article.Request;
using PersonalBloggingPlatformAPI.Presentation.Contracts.Article.Response;

namespace PersonalBloggingPlatformAPI.Presentation.Controllers
{
    [Route("[controller]")]
    public class ArticlesController : ControllerBase
    {
        private readonly IArticleService _articleService;
        private readonly ITagService _tagService;
        public ArticlesController(IArticleService articleService, ITagService tagService)
        {
            _articleService = articleService;
            _tagService = tagService;
        }

        [HttpPost]
        public async Task<ActionResult<ArticleResponse>> CreateArticle([FromBody] CreateArticleRequest request)
        {
            if (request == null)
            {
                return BadRequest(new { message = "Invalid request body." });
            }

            var tags = await _tagService.HandleTags(request.Tags);

            try
            {
                var newArticle = await _articleService.CreateArticle(request.Title, request.BodyText, tags);

                return CreatedAtGetArticle(MapToArticleDto(newArticle));
            }
            catch (ArgumentException ex)
            {
                return Problem(statusCode: StatusCodes.Status400BadRequest,
                    detail: ex.Message);
            }

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
            if (request == null)
            {
                return BadRequest(new { message = "Invalid request body." });
            }

            var tags = await _tagService.HandleTags(request.Tags);

            try
            {
                var  result = await _articleService.UpdateArticle(id, request.Title, request.BodyText, tags);

                return result is null ?
                Problem(statusCode: StatusCodes.Status404NotFound, detail: $"Article not found (articleId {id})")
                : Ok(MapToArticleDto(result));
            }

            catch (ArgumentException ex)
            {
                return Problem(statusCode: StatusCodes.Status400BadRequest,
                    detail: ex.Message);
            }

        }

        [HttpGet]
        public async Task<ActionResult<List<ArticleResponse>>> GetAll()
        {
            var articles = await _articleService.GetAll();

            return Ok(MapListToArticleResponse(MapListToArticleDto(articles)));
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

        private List<ArticleDto> MapListToArticleDto(List<Article> articles)
        {
            List<ArticleDto> articleDtoList = new List<ArticleDto>();

            foreach (Article article in articles)
            {
                var articleDto = MapToArticleDto(article);
                articleDtoList.Add(articleDto);
            }

            return articleDtoList;
        }

        private List<ArticleResponse> MapListToArticleResponse(List<ArticleDto> articles)
        {
            List<ArticleResponse> articleResponseList = new List<ArticleResponse>();

            foreach (ArticleDto article in articles)
            {
                var articleResponse = MapArticleResponse(article);
                articleResponseList.Add(articleResponse);
            }

            return articleResponseList;
        }
    }
}

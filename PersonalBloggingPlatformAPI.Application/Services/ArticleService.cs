using PersonalBloggingPlatformAPI.Application.Helpers;
using PersonalBloggingPlatformAPI.Application.Interfaces.Articles;
using PersonalBloggingPlatformAPI.Application.Interfaces.Tags;
using PersonalBloggingPlatformAPI.Domain.Entities;

namespace PersonalBloggingPlatformAPI.Application.Services
{
    public class ArticleService : IArticleService
    {
        private readonly IArticleRepository _articleRepository;
        private readonly ITagRepository _tagRepository;
        public ArticleService(IArticleRepository articleRepository, ITagRepository tagRepository)
        {
            _articleRepository = articleRepository;
            _tagRepository = tagRepository;
        }
        public async Task<Article> CreateArticle(string title, string bodyText, List<int?> tagsId)
        {

            var tags = new List<Tag>();

            if (tagsId != null && tagsId.Any())
            {
                foreach (int tagId in tagsId)
                {
                    var tag = await _tagRepository.GetTagByIdAsync(tagId);
                    if (tag != null)
                    {
                        tags.Add(tag);
                    }
                }
            }

            var newArticle = new Article
            {
                ArticleId = Guid.NewGuid(),
                Title = title,
                BodyText = bodyText,
                PublishingDate = DateTime.UtcNow,
                Tags = tags
            };


            // Validation
            List<string> errors = ErrorHandler.ArticleErrorHandler(newArticle);

            if (errors.Count > 0)
            {
                throw new ArgumentException(errors[0]);
            }

            await _articleRepository.CreateArticle(newArticle);

            return newArticle;
        }

        public async Task<Article> DeleteArticle(Guid id)
        {
            var result = await _articleRepository.DeleteArticle(id);

            return result;
        }

        public async Task<Article> GetArticle(Guid id)
        {
            var result = await _articleRepository.GetArticle(id);

            return result;
        }

        public async Task<Article> UpdateArticle(Guid id, string title, string bodyText, List<int?> tagsId)
        {
            var tags = new List<Tag>();

            if (tagsId != null && tagsId.Any())
            {
                foreach (int tagId in tagsId)
                {
                    var tag = await _tagRepository.GetTagByIdAsync(tagId);
                    if (tag != null)
                    {
                        tags.Add(tag);
                    }
                }
            }

            var updatedArticle = new Article
            {
                ArticleId = id,
                Title = title,
                BodyText = bodyText,
                PublishingDate = DateTime.UtcNow,
                Tags = tags
            };

            // Validation
            List<string> errors = ErrorHandler.ArticleErrorHandler(updatedArticle);

            if (errors.Count > 0)
            {
                throw new ArgumentException(errors[0]);
            }

            var result = await _articleRepository.UpdateArticle(id, updatedArticle);

            return result;
        }
    }
}

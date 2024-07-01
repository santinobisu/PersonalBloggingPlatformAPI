using PersonalBloggingPlatformAPI.Application.Helpers;
using PersonalBloggingPlatformAPI.Application.Interfaces.Articles;
using PersonalBloggingPlatformAPI.Domain.Entities;

namespace PersonalBloggingPlatformAPI.Application.Services
{
    public class ArticleService : IArticleService
    {
        private readonly IArticleRepository _articleRepository;
        public ArticleService(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }
        public async Task<Article> CreateArticle(Article newArticle)
        {
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

        public async Task<Article> UpdateArticle(Guid id, Article article)
        {
            // Validation
            List<string> errors = ErrorHandler.ArticleErrorHandler(article);

            if (errors.Count > 0)
            {
                throw new ArgumentException(errors[0]);
            }

            var result = await _articleRepository.UpdateArticle(id, article);

            return result;
        }
    }
}

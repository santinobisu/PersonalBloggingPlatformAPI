using PersonalBloggingPlatformAPI.Application.Interfaces.Articles;
using PersonalBloggingPlatformAPI.Application.Utils.ErrorHandler;
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

        public async Task<Article> CreateArticle(string title, string bodyText, List<Tag> tags)
        {
            var newArticle = new Article(new Guid(), title, bodyText, DateTime.UtcNow, tags);

            // Validation
            ErrorHandler.ArticleErrorHandler(newArticle);

            await _articleRepository.CreateArticle(newArticle);

            return newArticle;
        }

        public async Task<Article?> DeleteArticle(Guid id)
        {
            var result = await _articleRepository.DeleteArticle(id);

            return result;
        }

        public async Task<Article?> GetArticle(Guid id)
        {
            var result = await _articleRepository.GetArticle(id);

            return result;
        }

        public async Task<Article?> UpdateArticle(Guid id, string title, string bodyText, List<Tag> tags)
        {
            var updatedArticle = new Article(id, title, bodyText, DateTime.UtcNow, tags);

            // Validation
            ErrorHandler.ArticleErrorHandler(updatedArticle);

            var result = await _articleRepository.UpdateArticle(id, updatedArticle);

            return result;
        }

        public async Task<List<Article>> GetAll()
        {
            return await _articleRepository.GetAll();
        }
    }
}

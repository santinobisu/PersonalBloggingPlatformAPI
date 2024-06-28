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
            await _articleRepository.CreateArticle(newArticle);

            return newArticle;
        }

        public async Task<Article> DeleteArticle(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<Article> GetArticle(Guid id)
        {
            var result = await _articleRepository.GetArticle(id);

            return result;
        }

        public async Task<Article> UpdateArticle(Article article)
        {
            throw new NotImplementedException();
        }
    }
}

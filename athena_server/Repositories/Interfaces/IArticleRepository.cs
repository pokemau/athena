using athena_server.Models;
using athena_server.Models.DTO;

namespace athena_server.Repositories.Interfaces
{
    public interface IArticleRepository
    {
        public Task<Article> CreateArticle(Article article);
        public List<Article> GetArticles();
        public Article? GetArticleById(int id);
        public Task<Article> UpdateArticle(Article article);
        public Task<bool> DeleteArticle(int id);
    }
}

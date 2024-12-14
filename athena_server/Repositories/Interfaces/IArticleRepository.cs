using athena_server.Models;

namespace athena_server.Repositories.Interfaces
{
    public interface IArticleRepository
    {
        public Task<Article> CreateArticle(Article article);
        public List<Article> GetArticles();
        public Article? GetArticleById(int id);
        public Task<Article> UpdateArticle(Article article);
    }
}

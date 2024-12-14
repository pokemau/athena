using athena_server.Models;
using athena_server.Repositories.Interfaces;

namespace athena_server.Repositories
{
    public class ArticleRepository(AthenaDbContext athenaDbContext) : IArticleRepository
    {
        private readonly AthenaDbContext _athenaDbContext = athenaDbContext;

        public Task<Article> CreateArticle(Article article)
        {
            throw new NotImplementedException();
        }

        public Article? GetArticleById(int id)
        {
            return _athenaDbContext.Articles.SingleOrDefault(x => x.id == id);
        }

        public List<Article> GetArticles()
        {
            return _athenaDbContext.Articles.ToList();
        }

        public Task<Article> UpdateArticle(Article article)
        {
            throw new NotImplementedException();
        }
    }
}

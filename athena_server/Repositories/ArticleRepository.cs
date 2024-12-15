using athena_server.Models;
using athena_server.Models.DTO;
using athena_server.Repositories.Interfaces;

namespace athena_server.Repositories
{
    public class ArticleRepository(AthenaDbContext athenaDbContext) : IArticleRepository
    {
        private readonly AthenaDbContext _athenaDbContext = athenaDbContext;

        public async Task<Article> CreateArticle(ArticleRequestDTO.Create newArticle)
        {
            var article = new Article
            {
                wikiID = newArticle.WikiID,
                creatorID = newArticle.CreatorID,
                articleTitle = newArticle.Title,
                articleContent = newArticle.Content,
            };

            _athenaDbContext.Articles.Add(article);
            await _athenaDbContext.SaveChangesAsync();
            return article;
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

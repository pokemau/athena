using athena_server.Models;
using athena_server.Models.DTO;
using athena_server.Repositories;

namespace athena_server.Services
{
    public class ArticleService(IArticleRepository articleRepository) : IArticleService
    {
        public readonly IArticleRepository _articleRepository = articleRepository;

        public Task<ArticleRequestDTO.Create> CreateArticle(ArticleRequestDTO.Create newArticle)
        {
            throw new NotImplementedException();
        }

        public ArticleResponseDTO? GetArticleById(int id)
        {
            throw new NotImplementedException();
        }

        public List<ArticleResponseDTO> GetArticles()
        {
            List<ArticleResponseDTO> result = new List<ArticleResponseDTO>();

            var articles = _articleRepository.GetArticles();

            foreach (Article article in articles)
            {
                result.Add(new ArticleResponseDTO()
                {
                    id = article.id,
                    creatorID = article.creatorID,
                    wikiID = article.wikiID,
                    articleTitle = article.articleTitle,
                    articleContent = article.articleContent,
                });
            }

            return result;
        }
    }
}

using athena_server.Models;
using athena_server.Models.DTO;
using athena_server.Repositories.Interfaces;
using athena_server.Services.Interfaces;

namespace athena_server.Services
{
    public class ArticleService(IArticleRepository articleRepository) : IArticleService
    {
        public readonly IArticleRepository _articleRepository = articleRepository;

        public async Task<ArticleRequestDTO.Create> CreateArticle(ArticleRequestDTO.Create newArticle)
        {
            var created = await _articleRepository.CreateArticle(newArticle);
            return new ArticleRequestDTO.Create
            {
                WikiID = created.wikiID,
                Content = created.articleContent,
                Title = created.articleTitle,
                CreatorID = created.creatorID
            };
        }

        public ArticleResponseDTO? GetArticleById(int id)
        {
            var article = _articleRepository.GetArticleById(id);

            if (article == null)
            {
                return null;
            }

            return new ArticleResponseDTO()
            {
                id = article.id,
                wikiID = article.wikiID,
                articleTitle = article.articleTitle,
                creatorID = article.creatorID,
                articleContent = article.articleContent
            };
        }

        public List<ArticleResponseDTO> GetArticles()
        {
            //List<ArticleResponseDTO> result = new List<ArticleResponseDTO>();

            //var articles = _articleRepository.GetArticles();

            //foreach (Article article in articles)
            //{
            //    result.Add(new ArticleResponseDTO()
            //    {
            //        id = article.id,
            //        creatorID = article.creatorID,
            //        wikiID = article.wikiID,
            //        articleTitle = article.articleTitle,
            //        articleContent = article.articleContent,
            //    });
            //}

            //return result;

            var articles = _articleRepository.GetArticles();
            return articles.Select(article => new ArticleResponseDTO
            {
                id = article.id,
                wikiID = article.wikiID,
                creatorID = article.creatorID,
                articleTitle = article.articleTitle,
                articleContent = article.articleContent,
            }).ToList();
        }
    }
}

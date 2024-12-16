using athena_server.Controllers;
using athena_server.Models;
using athena_server.Models.DTO;
using athena_server.Repositories.Interfaces;
using athena_server.Services.Interfaces;

namespace athena_server.Services
{
    public class ArticleService(IArticleRepository articleRepository, IWikiRepository wikiRepository) : IArticleService
    {
        public readonly IArticleRepository _articleRepository = articleRepository;
        public readonly IWikiRepository _wikiRepository = wikiRepository;

        public async Task<ArticleResponseDTO> CreateArticle(ArticleRequestDTO.Create createArticleDTO)
        {
            var newArticle = new Article()
            {
                CreatorID = createArticleDTO.creatorID,
                ArticleTitle = createArticleDTO.articleTitle,
                ArticleContent = createArticleDTO.articleContent,
                WikiID = createArticleDTO.wikiID
            };

            var createdArticle = await _articleRepository.CreateArticle(newArticle);

            var wiki = _wikiRepository.GetWikiById(createArticleDTO.wikiID);

            var articleDTO = new ArticleResponseDTO()
            {
                articleTitle = createdArticle.ArticleTitle,
                articleContent = createdArticle.ArticleContent,
                wikiName = wiki?.wikiName ?? string.Empty
            };

            return articleDTO;
        }

        public ArticleResponseDTO? GetArticleById(int id)
        {
            var article = _articleRepository.GetArticleById(id);

            if (article == null)
            {
                return null;
            }

            var wiki = _wikiRepository.GetWikiById(article.WikiID);

            return new ArticleResponseDTO()
            {
                id = article.Id,
                wikiID = article.WikiID,
                wikiName = wiki?.wikiName ?? string.Empty,
                articleTitle = article.ArticleTitle,
                creatorID = article.CreatorID,
                articleContent = article.ArticleContent
            };
        }

        public List<ArticleResponseDTO> GetArticles()
        {
            List<ArticleResponseDTO> result = new List<ArticleResponseDTO>();

            var articles = _articleRepository.GetArticles();

            foreach (Article article in articles)
            {
                var wiki = _wikiRepository.GetWikiById(article.WikiID);
                result.Add(new ArticleResponseDTO()
                {
                    id = article.Id,
                    creatorID = article.CreatorID,
                    wikiID = article.WikiID,
                    wikiName = wiki?.wikiName ?? string.Empty,
                    articleTitle = article.ArticleTitle,
                    articleContent = article.ArticleContent
                });
            }
            return result;
        }

        public async Task<ArticleResponseDTO?> UpdateArticle(int id, ArticleRequestDTO.Update articleUpdate)
        {
            var article = _articleRepository.GetArticleById(id);

            article.ArticleTitle = articleUpdate.articleTitle;
            article.ArticleContent = articleUpdate.articleContent;

            var wiki = _wikiRepository.GetWikiById(article.WikiID);

            await _articleRepository.UpdateArticle(article);
            return new ArticleResponseDTO()
            {
                articleContent = article.ArticleContent,
                wikiName = wiki?.wikiName ?? string.Empty,
                articleTitle = article.ArticleContent,
            };
        }
    }
}

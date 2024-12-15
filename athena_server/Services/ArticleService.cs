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
                creatorID = createArticleDTO.creatorID,
                articleTitle = createArticleDTO.articleTitle,
                articleContent = createArticleDTO.articleContent,
                wikiID = createArticleDTO.wikiID
            };

            var createdArticle = await _articleRepository.CreateArticle(newArticle);

            var wiki = _wikiRepository.GetWikiById(createArticleDTO.wikiID);

            var articleDTO = new ArticleResponseDTO()
            {
                articleTitle = createdArticle.articleTitle,
                articleContent = createdArticle.articleContent,
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

            var wiki = _wikiRepository.GetWikiById(article.wikiID);

            return new ArticleResponseDTO()
            {
                id = article.id,
                wikiID = article.wikiID,
                wikiName = wiki?.wikiName ?? string.Empty,
                articleTitle = article.articleTitle,
                creatorID = article.creatorID,
                articleContent = article.articleContent
            };
        }

        public List<ArticleResponseDTO> GetArticles()
        {
            List<ArticleResponseDTO> result = new List<ArticleResponseDTO>();

            var articles = _articleRepository.GetArticles();

            foreach (Article article in articles)
            {
                var wiki = _wikiRepository.GetWikiById(article.wikiID);
                result.Add(new ArticleResponseDTO()
                {
                    id = article.id,
                    creatorID = article.creatorID,
                    wikiID = article.wikiID,
                    wikiName = wiki?.wikiName ?? string.Empty,
                    articleTitle = article.articleTitle,
                    articleContent = article.articleContent
                });
            }
            return result;
        }

        public async Task<ArticleResponseDTO?> UpdateArticle(int id, ArticleRequestDTO.Update articleUpdate)
        {
            var article = _articleRepository.GetArticleById(id);

            article.articleTitle = articleUpdate.articleTitle;
            article.articleContent = articleUpdate.articleContent;

            var wiki = _wikiRepository.GetWikiById(article.wikiID);

            await _articleRepository.UpdateArticle(article);
            return new ArticleResponseDTO()
            {
                articleContent = article.articleContent,
                wikiName = wiki?.wikiName ?? string.Empty,
                articleTitle = article.articleContent,
            };
        }
    }
}

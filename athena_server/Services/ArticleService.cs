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
                CreatorID = createArticleDTO.CreatorID,
                ArticleTitle = createArticleDTO.ArticleTitle,
                ArticleContent = createArticleDTO.ArticleContent,
                WikiID = createArticleDTO.WikiID
            };

            var createdArticle = await _articleRepository.CreateArticle(newArticle);

            var wiki = _wikiRepository.GetWikiById(createArticleDTO.WikiID);

            var articleDTO = new ArticleResponseDTO()
            {
                ArticleTitle = createdArticle.ArticleTitle,
                ArticleContent = createdArticle.ArticleContent,
                WikiName = wiki?.wikiName ?? string.Empty
            };

            return articleDTO;
        }

        public async Task<bool> DeleteArticle(int id)
        {
            return await _articleRepository.DeleteArticle(id);
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
                Id = article.Id,
                WikiID = article.WikiID,
                WikiName = wiki?.wikiName ?? string.Empty,
                ArticleTitle = article.ArticleTitle,
                CreatorID = article.CreatorID,
                ArticleContent = article.ArticleContent
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
                    Id = article.Id,
                    CreatorID = article.CreatorID,
                    WikiID = article.WikiID,
                    WikiName = wiki?.wikiName ?? string.Empty,
                    ArticleTitle = article.ArticleTitle,
                    ArticleContent = article.ArticleContent
                });
            }
            return result;
        }

        public async Task<ArticleResponseDTO?> UpdateArticle(int id, ArticleRequestDTO.Update articleUpdate)
        {
            var article = _articleRepository.GetArticleById(id);

            article.ArticleTitle = articleUpdate.ArticleTitle;
            article.ArticleContent = articleUpdate.ArticleContent;

            var wiki = _wikiRepository.GetWikiById(article.WikiID);

            await _articleRepository.UpdateArticle(article);
            return new ArticleResponseDTO()
            {
                ArticleContent = article.ArticleContent,
                WikiName = wiki?.wikiName ?? string.Empty,
                ArticleTitle = article.ArticleContent,
            };
        }
    }
}

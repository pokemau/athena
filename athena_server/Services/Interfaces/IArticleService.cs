using athena_server.Models.DTO;

namespace athena_server.Services.Interfaces
{
    public interface IArticleService
    {
        public Task<ArticleRequestDTO.Create> CreateArticle(ArticleRequestDTO.Create newArticle);
        public List<ArticleResponseDTO> GetArticles();
        public ArticleResponseDTO? GetArticleById(int id);
    }
}

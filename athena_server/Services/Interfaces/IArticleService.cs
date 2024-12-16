using athena_server.Models.DTO;

namespace athena_server.Services.Interfaces
{
    public interface IArticleService
    {
        public Task<ArticleResponseDTO> CreateArticle(ArticleRequestDTO.Create newArticle);
        public List<ArticleResponseDTO> GetArticles();
        public ArticleResponseDTO? GetArticleById(int id);
        public Task<ArticleResponseDTO> UpdateArticle(int id, ArticleRequestDTO.Update articleUpdate);
        public Task<bool> DeleteArticle(int id);
    }
}

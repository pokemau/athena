using athena_server.Models;
using athena_server.Models.DTO;

namespace athena_server.Repositories.Interfaces
{
    public interface IWikiRepository
    {
        public Task<Wiki> CreateWiki(Wiki wiki);
        public List<Wiki> GetWikis();
        public Wiki? GetWikiById(int id);
        public List<Article> GetArticleByWikiID(int id);
        public Task<bool> UpdateWiki(Wiki wiki);
        public Task<bool> DeleteWikiAsync(int id);
        public Task<ApplicationUserDTO> GetUserByID(string userId);
    }
}
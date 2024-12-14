using athena_server.Models;

namespace athena_server.Repositories
{
    public interface IWikiRepository
    {
        public Task<Wiki> CreateWiki(Wiki wiki);
        public List<Wiki> GetWikis();
        public Wiki? GetWikiById(int id);
        public List<Article> GetArticleByWikiID(int id);
        public Task<Wiki> UpdateWiki(Wiki wiki);
    }
}
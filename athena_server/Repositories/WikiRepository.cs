using athena_server.Models;

namespace athena_server.Repositories
{
    public class WikiRepository: IWikiRepository
    {
        private readonly AthenaDbContext _athenaDbContext;

        public WikiRepository(AthenaDbContext athenaDbContext)
        {
            _athenaDbContext = athenaDbContext;
        }

        public async Task<Wiki> CreateWiki(Wiki wiki)
        {
            _athenaDbContext.Add(wiki);
            await _athenaDbContext.SaveChangesAsync();
            return wiki;
        }
        public List<Wiki> GetWikis()
        {
            return _athenaDbContext.Wikis.ToList();
        }
        public Wiki? GetWikiById(int id)
        {
            return _athenaDbContext.Wikis.SingleOrDefault(x => x.id == id);
        }
        public List<Article> GetArticleByWikiID(int id)
        {
            return _athenaDbContext.Articles.Where(x => x.wikiID == id).ToList();
        }
        public async Task<Wiki> UpdateWiki(Wiki wiki)
        {
            _athenaDbContext.Wikis.Update(wiki);
            await _athenaDbContext.SaveChangesAsync();
            return wiki;
        }

    }
}
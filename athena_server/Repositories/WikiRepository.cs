using athena_server.Models;
using athena_server.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

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
        public async Task<bool> UpdateWiki(Wiki wiki)
        {
            var existingWiki = await _athenaDbContext.Wikis.FirstOrDefaultAsync(w => w.id == wiki.id);

            if (existingWiki == null)
            {
                return false;
            }
            _athenaDbContext.Wikis.Update(wiki);

            try
            {
                await _athenaDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
        public async Task<bool> DeleteWikiAsync(int id)
        {
            var wiki = await _athenaDbContext.Wikis.FirstOrDefaultAsync(w => w.id == id);

            if (wiki == null)
                return false;

            _athenaDbContext.Wikis.Remove(wiki);
            await _athenaDbContext.SaveChangesAsync();
            return true;
        }
    }
}
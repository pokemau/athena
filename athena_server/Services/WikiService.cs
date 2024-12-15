using athena_server.Models;
using athena_server.Models.DTO;
using athena_server.Repositories.Interfaces;
using athena_server.Services.Interfaces;

namespace athena_server.Services
{
    public class WikiService: IWikiService
    {
        public readonly IWikiRepository _wikiRepository;

        public WikiService(IWikiRepository wikiRepository)
        {
            _wikiRepository = wikiRepository;
        }

        public async Task<WikiDTO.DisplayRequest> CreateWiki(WikiDTO.CreateRequest createWikiDTO)
        {
            var newWiki = new Wiki()
            {
                creatorID = createWikiDTO.creatorID,
                creatorName = "Default",
                wikiName = createWikiDTO.wikiName,
                description = createWikiDTO.description,
                articles = new List<Article>()
            };

            var createdWiki = await _wikiRepository.CreateWiki(newWiki);

            var wikiDTO = new WikiDTO.DisplayRequest()
            {
                id = createdWiki.id,
                wikiName = createdWiki.wikiName,
                creatorName = createdWiki.creatorName,
                description = createdWiki.description,
                articles = createdWiki.articles     // convert to articleDTOs later
            };

            return wikiDTO;
        }

        public List<WikiDTO.DisplayRequest> GetWikis()
        {
            List<WikiDTO.DisplayRequest> result = new List<WikiDTO.DisplayRequest>();

            var wikis = _wikiRepository.GetWikis();

            foreach (Wiki wiki in wikis)
            {
                result.Add(new WikiDTO.DisplayRequest()
                {
                    id = wiki.id,
                    wikiName = wiki.wikiName,
                    creatorName = wiki.creatorName,
                    description = wiki.description,
                    articles = _wikiRepository.GetArticleByWikiID(wiki.id)
                });
            }

            return result;
        }
        public WikiDTO.DisplayRequest? GetWikiById(int id)
        {
            var wiki = _wikiRepository.GetWikiById(id);

            if (wiki == null)
            {
                return null;
            }

            return new WikiDTO.DisplayRequest()
            {
                id = wiki.id,
                wikiName = wiki.wikiName,
                creatorName = wiki.creatorName,
                description = wiki.description,
                articles = _wikiRepository.GetArticleByWikiID(wiki.id)
            };
        }

        public async Task<WikiDTO.DisplayRequest> UpdateWiki(int id, WikiDTO.UpdateDetailsRequest wikiDTO)
        {
            var wiki = _wikiRepository.GetWikiById(id);

            if (wiki == null)
            {
                return null;
            }

            wiki.wikiName = wikiDTO.wikiName;
            wiki.description = wikiDTO.description;

            await _wikiRepository.UpdateWiki(wiki);

            return new WikiDTO.DisplayRequest()
            {
                id = wiki.id,
                wikiName = wiki.wikiName,
                creatorName = wiki.creatorName,
                description = wiki.description,
                articles = _wikiRepository.GetArticleByWikiID(wiki.id)
            };
        }
    }
}
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
            var user = await _wikiRepository.GetUserByID(createWikiDTO.creatorID);

            if (user == null)
            {
                return null;
            }

            var newWiki = new Wiki()
            {
                CreatorID = createWikiDTO.creatorID,
                CreatorName = user.UserName,
                WikiName = createWikiDTO.wikiName,
                Description = createWikiDTO.description,
                Articles = new List<Article>()
            };

            var createdWiki = await _wikiRepository.CreateWiki(newWiki);

            var wikiDTO = new WikiDTO.DisplayRequest()
            {
                id = createdWiki.Id,
                wikiName = createdWiki.WikiName,
                creatorName = createdWiki.CreatorName,
                description = createdWiki.Description,
                articles = createdWiki.Articles.Select(article => new ArticleRequestDTO.Display
                {
                    CreatorID = article.CreatorID,
                    ArticleTitle = article.ArticleTitle,
                    ArticleContent = article.ArticleContent
                }).ToList()
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
                    id = wiki.Id,
                    wikiName = wiki.WikiName,
                    creatorName = wiki.CreatorName,
                    description = wiki.Description,
                    articles = (_wikiRepository.GetArticleByWikiID(wiki.Id) ?? new List<Article>()).Select(article => new ArticleRequestDTO.Display
                    {
                        CreatorID = article.CreatorID,
                        ArticleTitle = article.ArticleTitle,
                        ArticleContent = article.ArticleContent
                    }).ToList()
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
                id = wiki.Id,
                wikiName = wiki.WikiName,
                creatorName = wiki.CreatorName,
                description = wiki.Description,
                articles = (_wikiRepository.GetArticleByWikiID(wiki.Id) ?? new List<Article>()).Select(article => new ArticleRequestDTO.Display
                {
                    CreatorID = article.CreatorID,
                    ArticleTitle = article.ArticleTitle,
                    ArticleContent = article.ArticleContent
                }).ToList()
            };
        }

        public async Task<bool> UpdateWiki(int id, WikiDTO.UpdateDetailsRequest wikiDTO)
        {
            var wiki = _wikiRepository.GetWikiById(id);

            if (wiki == null)
            {
                return false;
            }

            wiki.WikiName = wikiDTO.wikiName;
            wiki.Description = wikiDTO.description;

            await _wikiRepository.UpdateWiki(wiki);

            return true;
        }
        public async Task<bool> DeleteWikiAsync(int id)
        {
            return await _wikiRepository.DeleteWikiAsync(id);
        }

        public async Task<ApplicationUserDTO?> GetUserByIdAsync(string userId)
        {
            // Fetch the user using EF Core's LINQ
            var user = await _wikiRepository.GetUserByID(userId);

            if (user == null) return null;

            return user;
        }
    }
}
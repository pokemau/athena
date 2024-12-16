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
            var user = await _wikiRepository.GetUserByID(createWikiDTO.CreatorID);

            if (user == null)
            {
                return null;
            }

            var newWiki = new Wiki()
            {
                CreatorID = createWikiDTO.CreatorID,
                CreatorName = user.UserName,
                WikiName = createWikiDTO.WikiName,
                Description = createWikiDTO.Description,
                Articles = new List<Article>()
            };

            var createdWiki = await _wikiRepository.CreateWiki(newWiki);

            var wikiDTO = new WikiDTO.DisplayRequest()
            {
                Id = createdWiki.Id,
                WikiName = createdWiki.WikiName,
                CreatorID = createdWiki.CreatorID,
                CreatorName = createdWiki.CreatorName,
                Description = createdWiki.Description,
                Articles = new List<ArticleRequestDTO.WikiPreview>()
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
                    Id = wiki.Id,
                    WikiName = wiki.WikiName,
                    CreatorID = wiki.CreatorID,
                    CreatorName = wiki.CreatorName,
                    Description = wiki.Description,
                    Articles = (_wikiRepository.GetArticleByWikiID(wiki.Id) ?? new List<Article>()).Select(article => new ArticleRequestDTO.WikiPreview
                    {
                        Id = article.Id,
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
                Id = wiki.Id,
                WikiName = wiki.WikiName,
                CreatorID = wiki.CreatorID,
                CreatorName = wiki.CreatorName,
                Description = wiki.Description,
                Articles = (_wikiRepository.GetArticleByWikiID(wiki.Id) ?? new List<Article>()).Select(article => new ArticleRequestDTO.WikiPreview
                {
                    Id = article.Id,
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

            wiki.WikiName = wikiDTO.WikiName;
            wiki.Description = wikiDTO.Description;

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
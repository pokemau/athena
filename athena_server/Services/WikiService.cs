﻿using athena_server.Models;
using athena_server.Models.DTO;
using athena_server.Repositories;

namespace athena_server.Services
{
    public class WikiService: IWikiService
    {
        public readonly IWikiRepository _wikiRepository;

        public WikiService(IWikiRepository wikiRepository)
        {
            _wikiRepository = wikiRepository;
        }

        public async Task<WikiDTO> CreateWiki(CreateWikiDTO createWikiDTO)
        {
            int id = _wikiRepository.GetWikis().Max(x => x.id) + 1;

            var newWiki = new Wiki()
            {
                id = id,
                creatorID = createWikiDTO.creatorID,
                wikiName = createWikiDTO.wikiName,
                articles = new List<Article>()
            };

            // Call the repository method to save to the database
            var createdWiki = await _wikiRepository.CreateWiki(newWiki);

            var wikiDTO = new WikiDTO()
            {
                wikiName = createdWiki.wikiName,
                articles = createdWiki.articles     // convert to articleDTO's
            };

            return wikiDTO;
        }

        public List<WikiDTO> GetWikis()
        {
            List<WikiDTO> result = new List<WikiDTO>();

            var wikis = _wikiRepository.GetWikis();

            foreach (Wiki wiki in wikis)
            {
                result.Add(new WikiDTO()
                {
                    wikiName = wiki.wikiName,
                    articles = _wikiRepository.GetArticleByWikiID(wiki.id)
                });
            }

            return result;
        }
        public WikiDTO? GetWikiById(int id)
        {
            var wiki = _wikiRepository.GetWikiById(id);

            if (wiki == null)
            {
                return null;
            }

            return new WikiDTO()
            {
                wikiName = wiki.wikiName,
                articles = _wikiRepository.GetArticleByWikiID(wiki.id)
            };
        }

        public async Task<WikiDTO> UpdateWiki(int id, WikiDTO wikiDTO)
        {
            var wiki = _wikiRepository.GetWikiById(id);

            if (wiki == null)
            {
                return null;
            }

            wiki.wikiName = wikiDTO.wikiName;
            wiki.articles = wikiDTO.articles;

            await _wikiRepository.UpdateWiki(wiki);

            return new WikiDTO()
            {
                wikiName = wiki.wikiName,
                articles = wiki.articles
            };
        }
    }
}
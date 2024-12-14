using athena_server.Models;
using athena_server.Models.DTO;

namespace athena_server.Services
{
    public interface IWikiService
    {
        public Task<WikiDTO> CreateWiki(CreateWikiDTO createwikiDTO);
        public List<WikiDTO> GetWikis();
        public WikiDTO? GetWikiById(int id);
        public Task<WikiDTO> UpdateWiki(int id, WikiDTO wikiDTO);
    }
}
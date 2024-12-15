using athena_server.Models;
using athena_server.Models.DTO;

namespace athena_server.Services.Interfaces
{
    public interface IWikiService
    {
        public Task<WikiRequestDTO.Display> CreateWiki(WikiRequestDTO.Create createwikiDTO);
        public List<WikiRequestDTO.Display> GetWikis();
        public WikiRequestDTO.Display? GetWikiById(int id);
        public Task<WikiRequestDTO.Display> UpdateWiki(int id, WikiRequestDTO.UpdateDetails wikiDTO);
    }
}
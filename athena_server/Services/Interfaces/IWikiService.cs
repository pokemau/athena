using athena_server.Models;
using athena_server.Models.DTO;

namespace athena_server.Services.Interfaces
{
    public interface IWikiService
    {
        public Task<WikiDTO.DisplayRequest> CreateWiki(WikiDTO.CreateRequest createwikiDTO);
        public List<WikiDTO.DisplayRequest> GetWikis();
        public WikiDTO.DisplayRequest? GetWikiById(int id);
        public Task<bool> UpdateWiki(int id, WikiDTO.UpdateDetailsRequest wikiDTO);
        public Task<bool> DeleteWikiAsync(int id);
        public Task<ApplicationUserDTO?> GetUserByIdAsync(string userId);
    }
}
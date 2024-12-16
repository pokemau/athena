using athena_server.Models;
using athena_server.Models.DTO;
using athena_server.Services;
using athena_server.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace athena_server.Controllers
{
    public class WikisController : Controller
    {

        private readonly IWikiService _wikiService;

        public WikisController(IWikiService wikiService)
        {
            _wikiService = wikiService;
        }

        [HttpPost("api/wikis")]
        public async Task<IActionResult> CreateWiki([FromBody] WikiDTO.CreateRequest createWikiDto)
        {
            if (createWikiDto == null)
            {
                return BadRequest("Wiki data is required.");
            }

            var createdWiki = await _wikiService.CreateWiki(createWikiDto);
            if (createdWiki == null)
            {
                return BadRequest("Failed to create wiki. The user may not exist or input data is invalid.");
            }

            return CreatedAtAction(nameof(GetWikiBbyID), new { id = createdWiki.Id }, createdWiki);
        }

        [HttpGet("api/wikis")]
        [AllowAnonymous]
        public IActionResult GetAllWikis()
        {
            var wikis = _wikiService.GetWikis();
            return Ok(wikis);
        }

        [HttpGet("api/wikis/{id}")]
        public IActionResult GetWikiBbyID(int id)
        {
            var wiki = _wikiService.GetWikiById(id);
            if (wiki == null)
            {
                return NotFound();
            }

            return Ok(wiki);
        }


        [HttpPut("api/wikis/{id}")]
        public async Task<IActionResult> UpdateWiki([FromRoute] int id, [FromBody] WikiDTO.UpdateDetailsRequest wikiDTO)
        {
            var success = await _wikiService.UpdateWiki(id, wikiDTO);
            if (success)
            {
                return Ok();
            }
            return NotFound($"Wiki {id} does not exists.");


        }


        [HttpDelete("api/wikis/{id}")]
        public async Task<IActionResult> DeleteWiki([FromRoute] int id)
        {
            var success = await _wikiService.DeleteWikiAsync(id);

            if (success)
                return NoContent(); // Return 204 No Content if successful

            return NotFound($"Wiki {id} does not exists."); // Return 404 if Wiki with given ID not found
        }
    }
}

using athena_server.Models;
using athena_server.Models.DTO;
using athena_server.Services;
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

        public IActionResult Index()
        {
            //var articles = _context.WikiArticles.ToList();
            return View();
        }

        public IActionResult CreateWiki()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateWiki(CreateWikiDTO createWikiDto)
        {
            if (createWikiDto == null)
            {
                return BadRequest("Wiki data is required.");
            }

            var createdWiki = await _wikiService.CreateWiki(createWikiDto);

            return CreatedAtAction(nameof(GetWikiBbyID), new { id = createdWiki.id }, createdWiki);
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


        [HttpPut]
        [Route("api/edit/wiki/{id}")]
        public IActionResult UpdateWiki([FromRoute] int id, [FromBody] WikiDTO wikiDTO)
        {
            var updated = _wikiService.UpdateWiki(id, wikiDTO);
            if (updated == null)
            {
                return NotFound($"Wiki {id} does not exists.");
            }

            return Ok(updated);
        }

    }
}

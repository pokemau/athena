using athena_server.Models;
using athena_server.Models.DTO;
using athena_server.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace athena_server.Controllers
{
    [ApiController]
    [Route("api/articles")]
    public class ArticlesController(IArticleService articleService): ControllerBase
    {
        private readonly IArticleService _articleService = articleService;

        [HttpGet]
        public IActionResult GetArticles()
        {
            var articles = _articleService.GetArticles();
            return Ok(articles);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetArticleByID(int id)
        {
            var result = _articleService.GetArticleById(id);
            if (result == null)
            {
                return NotFound($"Article {id} not found.");
            }
            return Ok(result);
        }
    }
}

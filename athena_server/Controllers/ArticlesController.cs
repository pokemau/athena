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
            if (articles == null)
            {
                return NoContent(); 
            }

            return Ok(articles);
        }

        [HttpGet]
        [Route("{id}", Name = "GetArticleByID")]
        public IActionResult GetArticleByID(int id)
        {
            var result = _articleService.GetArticleById(id);
            if (result == null)
            {
                return NotFound($"Article {id} not found.");
            }
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateArticle(ArticleRequestDTO.Create articleDTO)
        {
            var createdArticle = _articleService.CreateArticle(articleDTO);
            return CreatedAtRoute("GetArticleByID", new { id=createdArticle.Id }, articleDTO);
        }

    }
}

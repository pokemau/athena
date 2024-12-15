using athena_server.Models;
using athena_server.Models.DTO;
using athena_server.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace athena_server.Controllers
{
    [ApiController]
    [Route("api/articles")]
    public class ArticlesController(IArticleService articleService) : ControllerBase
    {
        private readonly IArticleService _articleService = articleService;

        [HttpPost]
        public async Task<IActionResult> CreateArticle([FromBody] ArticleRequestDTO.Create articleDTO)
        {
            if (articleDTO == null)
            {
                return BadRequest("Article data is required.");
            }
            var createdArticle = await _articleService.CreateArticle(articleDTO);
            return CreatedAtAction(nameof(GetArticleByID), new { id = createdArticle.id }, createdArticle);
        }

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

        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateArticle(int id, [FromBody] ArticleRequestDTO.Update articleUpdate)
        {
            var result = _articleService.UpdateArticle(id, articleUpdate);
            return Ok(new { Message = "Update successful.", UpdatedArticle = result });
        }
    }
}

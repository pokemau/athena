using athena_server.Models;
using athena_server.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace athena_server.Controllers
{
    [ApiController]
    [Route("api/articles")]
    public class ArticlesController: ControllerBase
    {
        [HttpGet]
        public IActionResult GetArticles()
        {
            return Ok(TempDB1.Articles);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetArticleByID(int id)
        {
            var product = TempDB1.Articles.SingleOrDefault(x => x.ID == id);
            if (product == null)
                return NotFound($"Article {id} does not exist");
            return Ok(product);
        }

        [HttpPost]
        public IActionResult CreateArticle(ArticleRequestDTO.Create article)
        {
            int id = TempDB1.Articles.Max(x => x.ID) + 1;

            ArticleRequestDTO.Create newArticle = new ArticleRequestDTO.Create()
            {
                WikiID = article.WikiID,
                CreatorID = article.CreatorID,
                Name = article.Name,
                Content = article.Content,
            };
            return CreatedAtRoute("CreateProduct", new {ID = id}, newArticle);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateProduct(int id, ArticleRequestDTO.Update article)
        {
            var exists = TempDB1.Articles.SingleOrDefault(x => x.ID == id);
            if (exists == null)
            {
                return NotFound($"Article {id} does not exist.");
            }
            exists.Name = article.Name;
            exists.Content = article.Content;

            return Ok(exists);
        }
    }
}

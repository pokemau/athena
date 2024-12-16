using athena_server.Models.DTO;
using athena_server.Services;
using athena_server.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace athena_server.Controllers
{
    [ApiController]
    [Route("api/comments")]
    public class CommentsController : Controller
    {
        private readonly ICommentService _commentService;

        public CommentsController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpGet]
        public IActionResult GetComments()
        {
            var articles = _commentService.GetComments();
            return Ok(articles);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetArticleByID(int id)
        {
            var result = _commentService.GetCommentById(id);
            if (result == null)
            {
                return NotFound($"Comment {id} not found.");
            }
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateComment([FromBody] CommentDTO commentDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdComment = _commentService.CreateComment(commentDTO);
            return CreatedAtAction(nameof(GetArticleByID), new { id = createdComment.ID }, createdComment);
        }

        [HttpGet("article/{articleId}/comments")]
        public IActionResult GetCommentsByArticleId(int articleId)
        {
            var comments = _commentService.GetCommentsByArticleId(articleId);

            if (comments == null || !comments.Any())
            {
                return NotFound(new { Message = "No comments found for this article." });
            }

            return Ok(comments);
        }

    }
}

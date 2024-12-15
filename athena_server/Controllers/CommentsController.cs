using athena_server.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace athena_server.Controllers
{
    public class CommentsController : Controller
    {
        private readonly ICommentService _commentService;

        public CommentsController(ICommentService commentService)
        {
            _commentService = commentService;
        }
    }
}

using athena_server.Models;
using athena_server.Models.DTO;

namespace athena_server.Services.Interfaces
{
    public interface ICommentService
    {
        public CommentResponseDTO CreateComment(CommentDTO commentDTO);
        public List<CommentResponseDTO> GetComments();
        public List<CommentResponseDTO> GetCommentsByArticleId(int articleId);
        public CommentResponseDTO? GetCommentById(int id);
    }
}

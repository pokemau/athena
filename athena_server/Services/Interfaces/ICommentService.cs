using athena_server.Models.DTO;

namespace athena_server.Services.Interfaces
{
    public interface ICommentService
    {
        public CommentResponseDTO CreateComment(CommentDTO commentDTO);
        public List<CommentResponseDTO> GetComments();
        public CommentResponseDTO? GetCommentById(int id);
    }
}

using athena_server.Models.DTO;

namespace athena_server.Services.Interfaces
{
    public interface ICommentService
    {
        public Task<CommentDTO> CreateComment();
        public List<CommentDTO> GetComments();
        public CommentDTO? GetCommentById(int id);
    }
}

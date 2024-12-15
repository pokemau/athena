using athena_server.Models.DTO;
using athena_server.Repositories.Interfaces;
using athena_server.Services.Interfaces;

namespace athena_server.Services
{
    public class CommentService(ICommentRepository commentRepository) : ICommentService
    {
        private readonly ICommentRepository _commentRepository = commentRepository;

        public Task<CommentDTO> CreateComment()
        {
            throw new NotImplementedException();
        }

        public CommentDTO? GetCommentById(int id)
        {
            throw new NotImplementedException();
        }

        public List<CommentDTO> GetComments()
        {
            throw new NotImplementedException();
        }
    }
}

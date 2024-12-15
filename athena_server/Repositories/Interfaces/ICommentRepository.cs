using athena_server.Models;

namespace athena_server.Repositories.Interfaces
{
    public interface ICommentRepository
    {
        public Task<Comment> CreateComment(Comment comment);
        public List<Comment> GetComments();
        public Comment? GetCommentById(int id);
        public Task<Comment> UpdateComment(Comment comment);
    }
}

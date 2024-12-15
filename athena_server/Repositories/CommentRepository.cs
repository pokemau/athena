using athena_server.Models;
using athena_server.Repositories.Interfaces;

namespace athena_server.Repositories
{
    public class CommentRepository(AthenaDbContext athenaDbContext) : ICommentRepository
    {
        private readonly AthenaDbContext _athenaDbContext = athenaDbContext;

        public Task<Comment> CreateComment(Comment comment)
        {
            throw new NotImplementedException();
        }

        public Comment? GetCommentById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Comment> GetComments()
        {
            throw new NotImplementedException();
        }

        public Task<Comment> UpdateComment(Comment comment)
        {
            throw new NotImplementedException();
        }
    }
}

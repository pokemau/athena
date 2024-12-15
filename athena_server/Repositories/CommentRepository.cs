using athena_server.Models;
using athena_server.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace athena_server.Repositories
{
    public class CommentRepository(AthenaDbContext athenaDbContext) : ICommentRepository
    {
        private readonly AthenaDbContext _athenaDbContext = athenaDbContext;

        public Comment CreateComment(Comment comment)
        {
            _athenaDbContext.Comments.Add(comment);
            _athenaDbContext.SaveChanges();
            return comment;
        }

        public Comment? GetCommentById(int id)
        {
            return _athenaDbContext.Comments.SingleOrDefault(x => x.ID == id);
        }

        public List<Comment> GetComments()
        {
            return _athenaDbContext.Comments.ToList();
        }

        public Task<Comment> UpdateComment(Comment comment)
        {
            throw new NotImplementedException();
        }
    }
}

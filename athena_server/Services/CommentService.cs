using athena_server.Models;
using athena_server.Models.DTO;
using athena_server.Repositories;
using athena_server.Repositories.Interfaces;
using athena_server.Services.Interfaces;

namespace athena_server.Services
{
    public class CommentService(ICommentRepository commentRepository) : ICommentService
    {
        private readonly ICommentRepository _commentRepository = commentRepository;

        public CommentResponseDTO CreateComment(CommentDTO commentDTO)
        {
            var comment = new Comment
            {
                CommentContent = commentDTO.CommentContent,
                DateTimeSent = DateTime.Now,
                SenderID = commentDTO.SenderID,
                ArticleID = commentDTO.ArticleID,
            };

            var createdComment = _commentRepository.CreateComment(comment);

            return new CommentResponseDTO
            {
                ID = createdComment.ID,
                CommentContent = createdComment.CommentContent,
                DateTimeSent = createdComment.DateTimeSent,
                SenderID = createdComment.SenderID,
                ArticleID = createdComment.ArticleID,
            };
        }

        public CommentResponseDTO? GetCommentById(int id)
        {
            var comment = _commentRepository.GetCommentById(id);

            if (comment == null)
            {
                return null;
            }

            return new CommentResponseDTO()
            {
                ID = comment.ID,
                CommentContent = comment.CommentContent,
                DateTimeSent = comment.DateTimeSent,
                SenderID = comment.SenderID,
                ArticleID = comment.ArticleID,
            };
        }

        public List<CommentResponseDTO> GetComments()
        {
            List<CommentResponseDTO> result = new List<CommentResponseDTO>();

            var comments = _commentRepository.GetComments();

            foreach (Comment comment in comments)
            {
                result.Add(new CommentResponseDTO()
                {
                    ID = comment.ID,
                    CommentContent = comment.CommentContent,
                    DateTimeSent = comment.DateTimeSent,
                    SenderID = comment.SenderID,
                    ArticleID = comment.ArticleID,
                });
            }

            return result;
        }

        public List<CommentResponseDTO> GetCommentsByArticleId(int articleId)
        {
            List<CommentResponseDTO> result = new List<CommentResponseDTO>();

            var comments = _commentRepository.GetCommentsByArticleId(articleId);

            foreach (Comment comment in comments)
            {
                result.Add(new CommentResponseDTO()
                {
                    ID = comment.ID,
                    CommentContent = comment.CommentContent,
                    DateTimeSent = comment.DateTimeSent,
                    SenderID = comment.SenderID,
                    ArticleID = comment.ArticleID,
                });
            }

            return result;
        }
    }
}

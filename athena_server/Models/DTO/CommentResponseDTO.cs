namespace athena_server.Models.DTO
{
    public class CommentResponseDTO
    {
        public int ID { get; set; }
        public required string CommentContent { get; set; }
        public DateTime DateTimeSent { get; set; }
        public required int ArticleID { get; set; }
    }
}

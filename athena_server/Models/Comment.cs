namespace athena_server.Models
{
    public class Comment
    {
        public int ID { get; set; }

        public int ArticleID { get; set; }

        public int SenderID { get; set; }

        public required string CommentContent { get; set; }

        public DateTime DateTimeSent { get; set; }

        // Navigation property for the associated Article
        public Article Article { get; set; } = null!;
    }
}

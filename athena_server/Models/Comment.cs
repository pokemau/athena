namespace athena_server.Models
{
    public class Comment
    {
        public int ID { get; set; }

        public int ArticleID { get; set; }

        public string SenderID { get; set; }

        public required string CommentContent { get; set; }

        public DateTime DateTimeSent { get; set; }

        public Article Article { get; set; } = null!;

        public ApplicationUser Sender { get; set; } = null!;
    }
}

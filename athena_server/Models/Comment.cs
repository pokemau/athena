namespace athena_server.Models
{
    public class Comments
    {
        public int ID { get; set; }

        public int SenderID { get; set; }

        public required string CommentContent { get; set; }

        public DateOnly Date { get; set; }
        
    }
}

namespace athena_server.Models.DTO
{
    public class CommentDTO
    {
        public required string CommentContent { get; set; }
        public DateTime DateTimeSent { get; set; }
    }
}

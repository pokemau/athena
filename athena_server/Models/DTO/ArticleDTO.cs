namespace athena_server.Models.DTO
{
    public class ArticleRequestDTO
    {
        public class Create
        {
            public required int wikiID { get; set; }
            public required string creatorID { get; set; }
            public required string articleTitle { get; set; }
            public required string articleContent { get; set; }
        }
        public class Update {
            public required string articleTitle { get; set; }
            public required string articleContent { get; set; }
        }
    }

    public class ArticleResponseDTO
    {
        public int id { get; set; }
        public int wikiID { get; set; }
        public required string? wikiName { get; set; }
        public string creatorID { get; set; }
        public required string? articleTitle { get; set; }
        public required string? articleContent { get; set; }
    }
}

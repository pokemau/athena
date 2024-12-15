namespace athena_server.Models.DTO
{
    public class ArticleRequestDTO
    {
        public class Create
        {
            public required int wikiID { get; set; }
            public required int creatorID { get; set; }
            public required String articleTitle { get; set; }
            public required String articleContent { get; set; }
        }
        public class Update {
            public required String articleTitle { get; set; }
            public required String articleContent { get; set; }
        }
    }

    public class ArticleResponseDTO
    {
        public int id { get; set; }
        public int wikiID { get; set; }
        public int creatorID { get; set; }
        public required String? articleTitle { get; set; }
        public required String? articleContent { get; set; }
    }
}

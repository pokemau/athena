namespace athena_server.Models.DTO
{
    public class ArticleRequestDTO
    {
        public class Create
        {
            public required int WikiID { get; set; }
            public required string CreatorID { get; set; }
            public required string ArticleTitle { get; set; }
            public required string ArticleContent { get; set; }
        }
        public class Update {
            public required string ArticleTitle { get; set; }
            public required string ArticleContent { get; set; }
        }
        public class Display
        {
            public required string CreatorID { get; set; }
            public required string ArticleTitle { get; set; }
            public required string ArticleContent { get; set; }
        }
    }

    public class ArticleResponseDTO
    {
        public int Id { get; set; }
        public int WikiID { get; set; }
        public required string? WikiName { get; set; }
        public string? CreatorID { get; set; }
        public required string? ArticleTitle { get; set; }
        public required string? ArticleContent { get; set; }
    }
}
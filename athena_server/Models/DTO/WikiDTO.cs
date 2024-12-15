namespace athena_server.Models.DTO
{
    public class WikiDTO
    {
        public class CreateRequest
        {
            public required int creatorID { get; set; }
            public required string wikiName { get; set; }
            public string description { get; set; }
        }
        public class UpdateDetailsRequest
        {
            public required string wikiName { get; set; }
            public string description { get; set; }
        }
        public class UpdateArticlesRequest
        {
            public ICollection<Article> articles { get; set; }

        }
        public class DisplayRequest
        {
            public int id { get; set; }
            public string wikiName { get; set; }
            public string creatorName { get; set; }
            public string description { get; set; }
            public ICollection<Article> articles { get; set; }
        }
    }
}
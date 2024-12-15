namespace athena_server.Models.DTO
{
    public class WikiRequestDTO
    {
        public class Create
        {
            public required int creatorID { get; set; }
            public required string wikiName { get; set; }
            public string description { get; set; }
        }
        public class UpdateDetails
        {
            public required string wikiName { get; set; }
            public string description { get; set; }
        }
        public class UpdateArticles
        {
            public ICollection<Article> articles { get; set; }

        }
        public class Display
        {
            public int id { get; set; }
            public string wikiName { get; set; }
            public string creatorName { get; set; }
            public string description { get; set; }
            public ICollection<Article> articles { get; set; }
        }
    }
}
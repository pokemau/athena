namespace athena_server.Models.DTO
{
    public class WikiDTO
    {
        public int id { get; set; }
        public required string wikiName { get; set; }
        public ICollection<Article> articles { get; set; }
    }
}

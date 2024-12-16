
namespace athena_server.Models
{
    public class Wiki
    {
        public int id { get; set; }
        public required string creatorID { get; set; }
        public required string wikiName { get; set; }
        public string creatorName { get; set; }
        public string description { get; set; }
        public ICollection<Article> articles { get; set; }
    }
}
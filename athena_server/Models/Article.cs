using System.Text.Json.Serialization;

namespace athena_server.Models
{
    public class Article
    {
        public required int id { get; set; }
        public required int wikiID { get; set; }
        [JsonIgnore]
        public Wiki wiki { get; set; }
        public required int creatorID { get; set; }
        public required String articleTitle { get; set; }
        public String articleContent { get; set; }
    }
}
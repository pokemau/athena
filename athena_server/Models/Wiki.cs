using System.Text.Json.Serialization;

namespace athena_server.Models
{
    public class Wiki
    {
        public required int id { get; set; }
        public required int creatorID { get; set; }
        public required string wikiName { get; set; }
        [JsonIgnore]
        public ICollection<Article> articles { get; set; }
    }
}
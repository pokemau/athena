using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace athena_server.Models
{
    public class Article
    {
        public int Id { get; set; }
        public required int WikiID { get; set; }
        [JsonIgnore]
        public Wiki? Wiki { get; set; }
        public required string CreatorID { get; set; }
        public required string ArticleTitle { get; set; }
        public string ArticleContent { get; set; }

        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
}

namespace athena_server.Models
{
    public class Wiki
    {
        public int Id { get; set; }
        public required string CreatorID { get; set; }
        public required string WikiName { get; set; }
        public string CreatorName { get; set; }
        public string Description { get; set; }
        public ICollection<Article> Articles { get; set; }
    }
}
namespace athena_server.Models
{
    public class Article
    {
        public int ID { get; set; }
        public required String ArticleName { get; set; }
        public int CreatorID { get; set; }
    }
}

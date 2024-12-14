namespace athena_server.Models
{
    public class Article
    {
        public int ID { get; set; }
        public int WikiID { get; set; }
        public int CreatorID { get; set; }
        public required String Name { get; set; }
        public required String Content { get; set; }
    }
}

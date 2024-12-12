namespace athena_server.Models
{
    public class Wiki
    {
        public int ID { get; set; }
        public int ArticleID { get; set; } // ID on which article this belongs
        public int CreatorID { get; set; }
        public int WikiName { get; set; }
        public String? Content { get; set; }
    }
}

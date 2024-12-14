namespace athena_server.Models.DTO
{
    public class ArticleRequestDTO
    {
        public class Create
        {
            public int WikiID { get; set; }
            public int CreatorID { get; set; }
            public required String Name { get; set; }
            public required String Content { get; set; }
        }
        public class Update {
            public required String Name { get; set; }
            public required String Content { get; set; }
        }
    }
}

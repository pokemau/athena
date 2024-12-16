namespace athena_server.Models.DTO
{
    public class WikiDTO
    {
        public class CreateRequest
        {
            public required string CreatorID { get; set; }
            public required string WikiName { get; set; }
            public string Description { get; set; }
        }
        public class UpdateDetailsRequest
        {
            public required string WikiName { get; set; }
            public string Description { get; set; }
        }
        public class DisplayRequest
        {
            public int Id { get; set; }
            public string WikiName { get; set; }
            public string CreatorID { get; set; }
            public string CreatorName { get; set; }
            public string Description { get; set; }
            public ICollection<ArticleRequestDTO.WikiPreview> Articles { get; set; }
        }
    }
}
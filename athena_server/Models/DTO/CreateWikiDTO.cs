namespace athena_server.Models.DTO
{
    public class CreateWikiDTO
    {
        public required int creatorID { get; set; }
        public required string wikiName { get; set; }
    }
}

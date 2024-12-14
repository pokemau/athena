using athena_server.Models;

namespace athena_server
{
    public class TempDb
    {
        public static List<Wiki> Wikis = new List<Wiki>()
        {
            new Wiki()
                {
                    id = 1,
                    creatorID = 1,
                    wikiName = "Yahallo"
                },
                new Wiki()
                {
                    id = 2,
                    creatorID = 1,
                    wikiName = "CS"
                },
                new Wiki()
                {
                    id = 3,
                    creatorID = 1,
                    wikiName = "IT"
                },
                new Wiki()
                {
                    id = 4,
                    creatorID = 2,
                    wikiName = "Polytopio"
                }
        };

        public static List<Article> Articles = new List<Article>()
        {
            new Article()
                {
                    id = 1,
                    wikiID = 1,
                    creatorID = 1,
                    articleTitle = "Chasers",
                    articleContent = "Chasers are the ralph a el"
                },
                new Article()
                {
                    id = 2,
                    wikiID = 1,
                    creatorID = 1,
                    articleTitle = "Slummd",
                    articleContent = "Slammdunk"
                }
        };
    }
}

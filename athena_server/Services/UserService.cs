using athena_server.Models.DTO;
using athena_server.Models;

namespace athena_server.Services
{
    public class UserService
    {
        private readonly AthenaDbContext _athenaDbContext;

        public UserService(AthenaDbContext athenaDbContext)
        {
            _athenaDbContext = athenaDbContext;
        }

        // Method to get a list of articles by user ID
        public List<Article> GetArticlesByUserId(string userId)
        {
            throw new NotImplementedException();
            //var articles = _athenaDbContext.Articles
            //    .Where(a => a.UserId == userId) // Assuming your Article model has a UserId field
            //    .ToList();
            //return articles;
        }

        // Method to get an ApplicationUser with articles, returning a DTO
        public ApplicationUserDTO GetUserWithArticles(string userId)
        {
            throw new NotImplementedException();
            //var user = _athenaDbContext.Users
            //                           .FirstOrDefault(u => u.Id == userId);

            //if (user == null) return null;

            //var articles = GetArticlesByUserId(userId);

            //var userDTO = new ApplicationUserDTO
            //{
            //    Id = user.Id,
            //    UserName = user.UserName,
            //    // Add other fields if needed
            //};

            //// You could also return the articles if you want as part of the response
            //return userDTO;
        }
    }

}

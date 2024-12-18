﻿using athena_server.Models;
using athena_server.Models.DTO;
using athena_server.Repositories.Interfaces;

namespace athena_server.Repositories
{
    public class ArticleRepository(AthenaDbContext athenaDbContext) : IArticleRepository
    {
        private readonly AthenaDbContext _athenaDbContext = athenaDbContext;

        public async Task<Article> CreateArticle(Article article)
        {
            _athenaDbContext.Add(article);
            await _athenaDbContext.SaveChangesAsync();
            return article;
        }
        public List<Article> GetArticles()
        {
            return _athenaDbContext.Articles.ToList();
        }

        public Article? GetArticleById(int id)
        {
            return _athenaDbContext.Articles.SingleOrDefault(x => x.Id == id);
        }

        public async Task<Article> UpdateArticle(Article article)
        {
            _athenaDbContext.Articles.Update(article);
            await _athenaDbContext.SaveChangesAsync();
            return article;
        }

        public async Task<bool> DeleteArticle(int id)
        {
            var article = _athenaDbContext.Articles.FirstOrDefault(w => w.Id == id);

            if (article == null)
                return false;

            _athenaDbContext.Articles.Remove(article);
            await _athenaDbContext.SaveChangesAsync();
            return true;
        }
    }
}

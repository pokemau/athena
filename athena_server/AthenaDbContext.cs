using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using athena_server.Models;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Xml.Linq;

namespace athena_server
{
    public class AthenaDbContext: IdentityDbContext<ApplicationUser>
    {
        public AthenaDbContext(DbContextOptions<AthenaDbContext> options) : base(options) { }

        // Register tables
        public DbSet<Wiki> Wikis{ get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Comment> Comments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); 

            modelBuilder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey }); 
            });

            modelBuilder.Entity<Wiki>().HasData(
                new Wiki()
                {
                    id = 1,
                    creatorID = 1,
                    creatorName = "Default",
                    wikiName = "Yahallo",
                    description = "This is the original"
                },
                new Wiki()
                {
                    id = 2,
                    creatorID = 1,
                    creatorName = "Default",
                    wikiName = "CS",
                    description = "For tryhards only"
                },
                new Wiki()
                {
                    id = 3,
                    creatorID = 1,
                    creatorName = "Default",
                    wikiName = "IT",
                    description = "chill"
                },
                new Wiki()
                {
                    id = 4,
                    creatorID = 2,
                    creatorName = "Default",
                    wikiName = "Polytopio",
                    description = "I am still learning"
                }
            );

            modelBuilder.Entity<Article>().HasData(
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
             );

            modelBuilder.Entity<Article>()
                .HasOne(a => a.wiki) 
                .WithMany(w => w.articles) 
                .HasForeignKey(a => a.wikiID) 
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Comment>().HasData(
                new Comment()
                {
                    ID = 1,
                    ArticleID = 1,
                    SenderID = "6a064981-b6c5-468d-b5c3-312e537d3cf0",
                    CommentContent = "Hello comment",
                    DateTimeSent = new DateTime(2024, 1, 1, 12, 0, 0),
                }
            );

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Sender)
                .WithMany()
                .HasForeignKey(c => c.SenderID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Article)
                .WithMany(a => a.Comments)
                .HasForeignKey(c => c.ArticleID)
                .OnDelete(DeleteBehavior.Cascade);

        }

    }
}
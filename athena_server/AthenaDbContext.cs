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
            base.OnModelCreating(modelBuilder); // Ensure this is called first

            // Optional: Customize the Identity entities' configuration
            modelBuilder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey }); // Set composite key for IdentityUserLogin
            });

            modelBuilder.Entity<Wiki>().HasData(
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
                .HasOne(a => a.wiki) // Article has one Wiki
                .WithMany(w => w.articles) // Wiki has many Articles
                .HasForeignKey(a => a.wikiID) // Foreign key in Article table
                .OnDelete(DeleteBehavior.Cascade); // Optional: Cascade delete

            modelBuilder.Entity<Comment>().HasData(
                new Comment()
                {
                    ID = 1,
                    ArticleID = 1,
                    SenderID = "caa56dca-255e-49b8-8c89-d41d7ce99687",
                    CommentContent = "Hello comment",
                    DateTimeSent = new DateTime(2024, 1, 1, 12, 0, 0),
                }
            );

            // Configure relationship between Comment and ApplicationUser (SenderID)
            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Sender)
                .WithMany()
                .HasForeignKey(c => c.SenderID)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure relationship between Comment and Article (ArticleID)
            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Article)
                .WithMany(a => a.Comments)
                .HasForeignKey(c => c.ArticleID)
                .OnDelete(DeleteBehavior.Cascade);

        }

    }
}
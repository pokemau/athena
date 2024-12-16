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

            //modelBuilder.Entity<Wiki>().HasData(
            //    new Wiki()
            //    {
            //        Id = 1,
            //        CreatorID = "1",
            //        CreatorName = "Default",
            //        WikiName = "Yahallo",
            //        Description = "This is the original"
            //    },
            //    new Wiki()
            //    {
            //        Id = 2,
            //        CreatorID = "1",
            //        CreatorName = "Default",
            //        WikiName = "CS",
            //        Description = "For tryhards only"
            //    },
            //    new Wiki()
            //    {
            //        Id = 3,
            //        CreatorID = "1",
            //        CreatorName = "Default",
            //        WikiName = "IT",
            //        Description = "chill"
            //    },
            //    new Wiki()
            //    {
            //        Id = 4,
            //        CreatorID = "1",
            //        CreatorName = "Default",
            //        WikiName = "Polytopio",
            //        Description = "I am still learning"
            //    }
            //);

            //modelBuilder.Entity<Article>().HasData(
            //    new Article()
            //    {
            //        Id = 1,
            //        WikiID = 1,
            //        CreatorID = "6a064981-b6c5-468d-b5c3-312e537d3cf0",
            //        ArticleTitle = "Chasers",
            //        ArticleContent = "Chasers are the ralph a el"
            //    },
            //    new Article()
            //    {
            //        Id = 2,
            //        WikiID = 1,
            //        CreatorID = "6a064981-b6c5-468d-b5c3-312e537d3cf0",
            //        ArticleTitle = "Slummd",
            //        ArticleContent = "Slammdunk"
            //    }
            // );

            modelBuilder.Entity<Article>()
                .HasOne(a => a.Wiki) 
                .WithMany(w => w.Articles) 
                .HasForeignKey(a => a.WikiID) 
                .OnDelete(DeleteBehavior.Cascade);

            //modelBuilder.Entity<Comment>().HasData(
            //    new Comment()
            //    {
            //        ID = 1,
            //        ArticleID = 1,
            //        SenderID = "6a064981-b6c5-468d-b5c3-312e537d3cf0",
            //        CommentContent = "Hello comment",
            //        DateTimeSent = new DateTime(2024, 1, 1, 12, 0, 0),
            //    }
            //);

            //modelBuilder.Entity<Comment>()
            //    .HasOne(c => c.Sender)
            //    .WithMany()
            //    .HasForeignKey(c => c.SenderID)
            //    .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<Comment>()
            //    .HasOne(c => c.Article)
            //    .WithMany(a => a.Comments)
            //    .HasForeignKey(c => c.ArticleID)
            //    .OnDelete(DeleteBehavior.Cascade);

        }

    }
}
﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace athena_server.Models
{
    public class Article
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public required int wikiID { get; set; }
        [JsonIgnore]
        public Wiki wiki { get; set; }
        public required int creatorID { get; set; }
        public required String articleTitle { get; set; }
        public String articleContent { get; set; }

        // Navigation property for related comments
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace apcurs.Models
{
    public class ArticleModel
    {
        public int id { get; set; }
        public User user { get; set; }
        public SubCategory subCategory { get; set; }
        public string articleText { get; set; }
        public DateTime? createdDate { get; set; } 
        public Category category { get; set; }
        public int? viewCount { get; set; }
        public int? likeCount { get; set; }
        public string shortTitle { get; set; }
        public ArticleComment comment { get; set; }
        public bool status { get; set; }
    }
}
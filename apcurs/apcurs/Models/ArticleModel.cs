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
        public string articleText { get; set; }
        public DateTime? createdDate { get; set; } 
        public int? viewCount { get; set; }
        public int? likeCount { get; set; }
        public string shortTitle { get; set; }
        public List<ArticleComment> comment { get; set; }
        public bool status { get; set; }
        public string articlePicture { get; set; }
    }
}
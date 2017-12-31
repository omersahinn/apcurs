using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace apcurs.Models
{
    public class QuestionModel
    {
        public int id { get; set; }
        public User user { get; set; }
        public SubCategory subCategory { get; set; }
        public string questionText { get; set; }
        public DateTime? createdDate { get; set; }
        public bool? isReply { get; set; }
        public Category category { get; set; }
        public int? viewCount { get; set; }
        public int? voteCount { get; set; }
        public string shortTitle { get; set; }
        public List<Answer> answers { get; set; }
        public bool? status { get; set; }
    }
}
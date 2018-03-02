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
        public string questionText { get; set; }
        public DateTime? createdDate { get; set; }
        public bool? isReply { get; set; }
        public int? viewCount { get; set; }
        public int? voteCount { get; set; }
        public string shortTitle { get; set; }
        public List<AnswerModel> answers { get; set; }
        public List<Tag> tags { get; set; }
        public bool? status { get; set; }
        public List<VotedQuestion> votedUsers { get; set; }
        public List<MyFavourite> favouritedUsers { get; set; }
        public int? favoriCount { get; set; }

    }
}
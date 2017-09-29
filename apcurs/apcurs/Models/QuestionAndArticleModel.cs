using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace apcurs.Models
{
   

    public class QuestionAndArticleModel
    {
        public IEnumerable<QuestionModel> lastQuestions { get; set; }
        public IEnumerable<QuestionModel> mostVotedQuestion { get; set; }
        public IEnumerable<QuestionModel> mostViewedQuestion { get; set; }

        public IEnumerable<ArticleModel> lastArticles { get; set; }
        public IEnumerable<ArticleModel> mostLikedArticles { get; set; }
        public IEnumerable<ArticleModel> mostViewedArticles { get; set; }
    }
}
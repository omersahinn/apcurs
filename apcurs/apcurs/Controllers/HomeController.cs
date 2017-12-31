using apcurs.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace apcurs.Controllers
{
    public class homeController : Controller
    {
        Paging pg = new Paging();
        DbDataContext db = new DbDataContext();
        public string GetErrorMessage(Exception ex)
        {
            StringBuilder errorMessage = new StringBuilder(200);

            errorMessage.AppendFormat("<div class=\"validation-summary-error\" title=\"Server Error\">{0}</div>", ex.GetBaseException().Message);
            Response.StatusCode = (int)HttpStatusCode.InternalServerError;  //jquerymodal'a 500 hata kodunu gönderiyor

            return errorMessage.ToString();
        }
        public static string TimeAgo(DateTime dt)
        {
            string result = string.Empty;
            var timeSpan = DateTime.Now.Subtract(dt);

            //var timeSpan = DateTime.Now-dt;

            if (timeSpan <= TimeSpan.FromSeconds(60))
            {
                result = string.Format("{0} saniye önce", timeSpan.Seconds);
            }
            else if (timeSpan <= TimeSpan.FromMinutes(60))
            {
                result = timeSpan.Minutes > 1 ?
                    String.Format("yaklaşık {0} dakika önce", timeSpan.Minutes) :
                    "yaklaşık 1 dakika önce";
            }
            else if (timeSpan <= TimeSpan.FromHours(24))
            {
                result = timeSpan.Hours > 1 ?
                    String.Format("yaklaşık {0} saat önce", timeSpan.Hours) :
                    "yaklaşık 1 saat önce";
            }
            else if (timeSpan <= TimeSpan.FromDays(30))
            {
                result = timeSpan.Days > 1 ?
                    String.Format("yaklaşık {0} gün önce", timeSpan.Days) :
                    "dün";
            }
            else if (timeSpan <= TimeSpan.FromDays(365))
            {
                result = timeSpan.Days > 30 ?
                    String.Format("yaklaşık {0} ay önce", timeSpan.Days / 30) :
                    "yaklaşık 1 ay önce";
            }
            else
            {
                result = timeSpan.Days > 365 ?
                    String.Format("yaklaşık {0} yıl önce", timeSpan.Days / 365) :
                    "yaklaşık 1 yıl önce";
            }

            return result;
        }
        public ActionResult index()
        {
            QuestionAndArticleModel model = new QuestionAndArticleModel();
            QuestionModel qmodel = new QuestionModel();
            ArticleModel amodel = new ArticleModel();


            var temp = (from q in db.GetTable<Question>()
                        select new QuestionModel()
                        {
                            
                            id = q.id,
                            user = q.User,
                            subCategory = q.SubCategory,
                            category = q.Category,
                            questionText = q.QuestionText,
                            createdDate = q.CreatedDate,
                            isReply = q.IsReply,
                            viewCount = q.ViewCount,
                            voteCount = q.VoteCount,
                            shortTitle = q.ShortTitle,
                            status=q.Status

                        }).Where(a => a.status == true).ToList();



            foreach (var item in temp)
            {
                item.answers = db.Answers.Where(a => a.Questionid == item.id).ToList();
            }


            var temp2 = (from q in db.Articles.ToList()
                         select new ArticleModel
                         {
                             id = q.id,
                             user = q.User,
                             subCategory = q.SubCategory,
                             category = q.Category,
                             articleText = q.ArticleText,
                             createdDate = q.CreatedDate,
                             viewCount = q.ViewCount,
                             likeCount = q.LikeCount,
                             shortTitle = q.ShortTitle,      
                             articlePicture=q.ArticlePicture,
                             status=q.Status
                         }).Where(a => a.status == true).ToList();
            foreach (var item2 in temp2)
            {
                item2.comment = db.ArticleComments.Where(a => a.Articleid == item2.id).ToList();
            }


            var Lastquestion = temp.OrderByDescending(a => a.createdDate).Take(20);        
            var NotAnsweredQuestion =temp.Where(c=>c.answers.Count==0).OrderByDescending(a => a.createdDate).Take(20);
            var Viewedanswer = temp.OrderByDescending(a => a.viewCount).Take(20);
            var answeredQuestion = temp.OrderByDescending(a => a.answers.Count()).Take(20);

            var Lastarticle = temp2.OrderByDescending(a => a.createdDate).Take(10);
            var Likedarticle = temp2.OrderByDescending(a => a.likeCount).Take(20);
            var Viewedarticle = temp2.OrderByDescending(a => a.viewCount).Take(20);



            model.lastQuestions = Lastquestion;
            model.notAnsweredQuestion = NotAnsweredQuestion;
            model.mostViewedQuestion = Viewedanswer;
            model.mostAnsweredQuestion = answeredQuestion;

            model.lastArticles = Lastarticle;
            model.mostLikedArticles = Likedarticle;
            model.mostViewedArticles = Viewedarticle;


            var items = (from ar in db.ArticleComments.ToList()
                         select new CommentModel
                         {
                             id = ar.id,
                             User = ar.User,
                             Article = ar.Article,
                             CreatedDate = ar.CreatedDate,
                             CommentText = ar.CommentText,
                             Status = ar.Status

                         }).Where(a => a.Status == true).OrderByDescending(a => a.CreatedDate).ToList();
            var catItems = (from s in db.Categories.ToList()
                            select new CategoryModel
                            {
                                id = s.id,
                                Count = s.Articles.Count(),
                                CategoryName = s.CategoryName,
                                SubCategory = s.SubCategories.ToList(),
                                Status = s.Status
                            }).Where(a => a.Status == true).ToList();
            ViewBag.categories = catItems;
            ViewBag.comments = items;
            return View(model);
        }
    }
}
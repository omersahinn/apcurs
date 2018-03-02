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
        QuestionPaging pg = new QuestionPaging();
        DbDataContext db = new DbDataContext();
        public string GetErrorMessage(Exception ex)
        {
            StringBuilder errorMessage = new StringBuilder(200);

            errorMessage.AppendFormat("<div class=\"validation-summary-error\" title=\"Server Error\">{0}</div>", ex.GetBaseException().Message);
            Response.StatusCode = (int)HttpStatusCode.InternalServerError;  //jquerymodal'a 500 hata kodunu gönderiyor

            return errorMessage.ToString();
        }

        public ActionResult index()
        {
            QuestionAndArticleModel model = new QuestionAndArticleModel();
            QuestionModel qmodel = new QuestionModel();
            ArticleModel amodel = new ArticleModel();
            Tag t = new Tag();
            List<Tag> lt = new List<Tag>();

            var temp = (from q in db.GetTable<Question>()
                        select new QuestionModel()
                        {

                            id = q.id,
                            user = q.User,
                            questionText = q.QuestionText,
                            createdDate = q.CreatedDate,
                            isReply = q.IsReply,
                            viewCount = q.ViewCount,
                            voteCount = q.VoteCount,
                            shortTitle = q.ShortTitle,
                            status = q.Status

                        }).Where(a => a.status == true).ToList();



            foreach (var item in temp)
            {
                var ansTemp = (from q in db.GetTable<Answer>()
                               select new AnswerModel()
                               {

                                   id = q.id,
                                   User = q.User,
                                   AnswerText = q.AnswerText,
                                   CreatedDate = q.CreatedDate,
                                   IsSolved = q.IsSolved,
                                   VoteCount = q.VoteCount,
                                   Question = q.Question,
                                   Status = q.Status,
                                   VotedAnswers = q.VotedAnswers.ToList()

                               }).Where(x => x.Status == true && x.Question.id == item.id).ToList();
                lt.Clear();

               item.answers = ansTemp;
               
                var a = db.QuestionTags.Where(z => z.QuestionId == item.id).Select(x => new { x.TagId }).ToList();
                if (a != null)
                {
                    foreach (var item1 in a)
                    {
                        t = db.Tags.Where(q => q.id == item1.TagId).FirstOrDefault();
                        lt.Add(t);
                    }
                    item.tags = lt.ToList();
                }

            }
            var asd = temp;



            var temp2 = (from q in db.Articles.ToList()
                         select new ArticleModel
                         {
                             id = q.id,
                             user = q.User,
                             articleText = q.ArticleText,
                             createdDate = q.CreatedDate,
                             viewCount = q.ViewCount,
                             likeCount = q.LikeCount,
                             shortTitle = q.ShortTitle,
                             articlePicture = q.ArticlePicture,
                             status = q.Status
                         }).Where(a => a.status == true).ToList();
            foreach (var item2 in temp2)
            {
                item2.comment = db.ArticleComments.Where(a => a.Articleid == item2.id).ToList();
            }


            var Lastquestion = temp.OrderByDescending(a => a.createdDate).Take(20);
            var NotAnsweredQuestion = temp.Where(c => c.answers.Count == 0).OrderByDescending(a => a.createdDate).Take(20);
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
            //var catItems = (from s in db.Categories.ToList()
            //                select new CategoryModel
            //                {
            //                    id = s.id,
            //                    Count = s.Articles.Count(),
            //                    CategoryName = s.CategoryName,
            //                    SubCategory = s.SubCategories.ToList(),
            //                    Status = s.Status
            //                }).Where(a => a.Status == true).ToList();
            //ViewBag.categories = catItems;
            ViewBag.comments = items;
            return View(model);
        }
        public ActionResult Chat()
        {

            return View();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Moravia.Shouter.Core.Services;
using Moravia.Shouter.Core.Model;

namespace Shouter.Controllers
{
    public class CommentsController : Controller
    {
        //
        // GET: /Comments/

        public ActionResult Index()
        {
            return View(CommentServices.GetComments());
        }

        [HttpPost]
        public ActionResult Index(string commentText)
        {
            Comment newComment = new Comment();
            newComment.email = Session["email"].ToString();
            newComment.comment = commentText;
            CommentServices.InsertComment(newComment);
            return RedirectToAction("Index", "Comments");
        }
    }
}

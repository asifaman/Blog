using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Blog.Models;

namespace Blog.Controllers
{
    public class HomeController : Controller
    {
        private Gateway db = new Gateway();
        public ActionResult Index(string searchString)
        {
            
            var blog = (from p in db.Blog where p.Status=="Publish"
                        orderby p.BlogId  descending
                        select p).Take(5).ToList();

            ViewBag.TopPost =(from p in db.Blog
             where p.Status == "Publish"
             orderby p.VisitorCount descending
             select p).Take(5).ToList();
                
             //db.Blog.Where(x => x.Status == "Publish").OrderByDescending(x => x.VisitorCount).Take(5).ToList();

            if (!String.IsNullOrEmpty(searchString))
            {
                blog = db.Blog.Where(s => s.BlogTitle.Contains(searchString)).ToList();
            }
            
            return View(blog);
        }

        public ActionResult DetailView(int? id)
        {
            base.Session["Id"] = id;
            id = (int?) base.Session["Id"];
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var count = from c in db.Blog where c.BlogId == id select c.VisitorCount;
            var countrow = db.Blog.Where(x=>x.BlogId==id).ToList();
            foreach (var item in count)
            {
                double view =1+ Convert.ToDouble(item);
                foreach (var row in countrow)
                {
                    row.VisitorCount = (int) view;
                }
                
            }
            db.SaveChanges(); 
            MyBlog myBlog = db.Blog.Find(id);
            if (myBlog == null)
            {
                return HttpNotFound();
            }
           
            return View(myBlog);
           
        }
       
        public ActionResult Comment(string comment)
        {
            var users = User.Identity.Name;
            var id = (int?)base.Session["Id"];

            if (users != "")
            {
                if (comment != null)
                {
                    if (comment != "")
                    {
                        var user = User.Identity.Name;
                        Comment aComment = new Comment();
                        aComment.BlogId = id.ToString();
                        aComment.UserId = user;
                        aComment.UserComment = comment;
                        aComment.Date = DateTime.Now.ToString();
                        db.Comment.Add(aComment);
                        db.SaveChanges();
                    }
                }
            }
            var UserComment = db.Comment.Where(x => x.BlogId == id.ToString()).ToList();
            return Json(UserComment, JsonRequestBehavior.AllowGet);
        }
    

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
       
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
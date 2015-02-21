using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Blog.Models;
using WebMatrix.WebData;

namespace Blog.Controllers
{  
    [Authorize]
    public class MyBlogController : Controller 
    {
        private Gateway db = new Gateway();
        public ActionResult Index()
        {        
             var username = User.Identity.Name;
            return View(db.Blog.Where(x=>x.UserId==username).ToList());

        }

        public ActionResult Publish(int? id)
        {
            var query = from d in db.Blog where d.BlogId == id select d;
            foreach (var item in query)
            {
                item.Date = DateTime.Now.ToString();
                item.Status = "Publish";
            }
            try
            {
                
                db.SaveChanges();
            }
            catch (Exception e)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
        public ActionResult Unpublish(int? id)
        {
            var query = from d in db.Blog where d.BlogId == id select d;
            foreach (var item in query)
            {
                item.Date = DateTime.Now.ToString();
                item.Status = "Unpublish";
            }
            try
            {

                db.SaveChanges();
            }
            catch (Exception e)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
        // GET: MyBlog/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MyBlog myBlog = db.Blog.Find(id);
            if (myBlog == null)
            {
                return HttpNotFound();
            }
            return View(myBlog);
        }

        // GET: MyBlog/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MyBlog/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BlogId,UserId,BlogTitle,BlogDescription,BloggerImg")] MyBlog myBlog, HttpPostedFileBase BlogImg)
        {
            try
            {
                var filename = Path.GetFileName(BlogImg.FileName);
                var path = Path.Combine(Server.MapPath("~/Image"), filename);
                BlogImg.SaveAs(path);
                var username = User.Identity.Name;
                if (ModelState.IsValid)
                {
                    myBlog.UserId = username;
                    myBlog.BloggerImg = filename;
                    db.Blog.Add(myBlog);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }catch (NullReferenceException ex)
            {
                return RedirectToAction("Index");
            }
            return View(myBlog);
        }

        // GET: MyBlog/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MyBlog myBlog = db.Blog.Find(id);
            if (myBlog == null)
            {
                return HttpNotFound();
            }
            return View(myBlog);
        }

        // POST: MyBlog/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BlogId,UserId,BlogTitle,BlogDescription,BloggerImg")] MyBlog myBlog, HttpPostedFileBase BlogImg)
        {
            try
            {
                var filename = Path.GetFileName(BlogImg.FileName);
                var path = Path.Combine(Server.MapPath("~/Image"), filename);
                BlogImg.SaveAs(path);

                if (ModelState.IsValid)
                {
                    myBlog.BloggerImg = filename;
                    db.Entry(myBlog).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (NullReferenceException ex)
            {
                return RedirectToAction("Index");
            }
            return View(myBlog);
        }

        // GET: MyBlog/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MyBlog myBlog = db.Blog.Find(id);
            if (myBlog == null)
            {
                return HttpNotFound();
            }
            return View(myBlog);
        }

        // POST: MyBlog/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MyBlog myBlog = db.Blog.Find(id);
            db.Blog.Remove(myBlog);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

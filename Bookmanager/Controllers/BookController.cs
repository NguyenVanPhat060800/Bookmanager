using Bookmanager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Bookmanager.Controllers
{
    public class BookController : Controller
    {
        BookManagerContext conText = new BookManagerContext();
        public string HelloTeacher()
        {
            return " Hello Nguyễn Văn Phát";
        }
        public ActionResult LisBook()
        {

            var listBook = conText.Books.ToList();

            return View(listBook);

        }
        [Authorize]
        public ActionResult Buy(int id)
        {
            Book Book = conText.Books.SingleOrDefault(p => p.ID == id);
            if(Book == null)
            {
                return HttpNotFound();
            }

            return View(Book);
        }
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Book.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Arthor,Title,Description,ImageCover,Price")] Book book)
        {
            if (ModelState.IsValid)
            {
                db.Book.Add(book);
                db.SaveChanges();
                return RedirectToAction("ListBook");
            }

            return View(book);
        }
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Arthor,Title,Description,ImageCover,Price")] Book book)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(book).State = EntityState.Modified;
                //db.SaveChanges();
                Book dbUpdate = db.Books.FirstOrDefault(p => p.Id.Equals(book.Id));
                if (dbUpdate != null)
                {
                    db.Books.AddOrUpdate(book); //Add or Update Book b 
                    db.SaveChanges();
                }
                return RedirectToAction("ListBook");
            }
            return View(book);
        }

        // GET: Books/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Book book = db.Books.Find(id);
            db.Books.Remove(book);
            db.SaveChanges();
            return RedirectToAction("ListBook");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        // GET: Book
        public ActionResult Index()
        {
            return View();
        }
    }
}
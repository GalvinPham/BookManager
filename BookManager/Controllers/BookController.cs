using BookManager.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookManager.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public ActionResult ListBook()
        {
            BookManagerContext context = new BookManagerContext();
            var listBook = context.BookMen.ToList();
            return View(listBook);
        }
        //Mua
        [Authorize]
        public ActionResult Buy(int id)
        {
            BookManagerContext context = new BookManagerContext();
            BookMan book = context.BookMen.SingleOrDefault(p => p.ID == id);
            if(book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }
        //Thêm
        public ActionResult AddBook()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddBook(BookMan b)
        {
                BookManagerContext context = new BookManagerContext();
                List<BookMan> listbook = context.BookMen.ToList();                
                //BookMan db = context.BookMen.FirstOrDefault(p => p.ID == BookID);           
                context.BookMen.AddOrUpdate(b);
                context.SaveChanges();               
                return RedirectToAction("ListBook");
        }
        //Sửa
        public ActionResult Edit(int? id)
        {
            BookManagerContext context = new BookManagerContext();
            BookMan book = context.BookMen.Find(id);
            if (id == null)
            {
                return HttpNotFound();
            }
            if (book == null)
            {
                return HttpNotFound();
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BookMan book)
        {
            BookManagerContext c = new BookManagerContext();
            if (ModelState.IsValid)
            {
                c.BookMen.AddOrUpdate(book);
                c.SaveChanges();

            }
            return RedirectToAction("ListBook");
        }
        //Xoá
        public ActionResult Delete(int? id)
        {
            BookManagerContext context = new BookManagerContext();
            BookMan book = context.BookMen.Find(id);
            if (id == null)
            {
                return new HttpStatusCodeResult(BookManagerContext.BadRequest);
            }
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            BookManagerContext con = new BookManagerContext();
            List<BookMan> listBook = con.BookMen.ToList();
            BookMan book = con.BookMen.Find(id);
            if (ModelState.IsValid)
            {
                con.BookMen.Remove(book);
                con.SaveChanges();
            }
            return RedirectToAction("ListBook", listBook);
        }
    }
}
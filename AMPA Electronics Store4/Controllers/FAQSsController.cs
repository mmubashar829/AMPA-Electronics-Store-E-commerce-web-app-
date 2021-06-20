using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AMPA_Electronics_Store4.Models;

namespace AMPA_Electronics_Store4.Controllers
{
    public class FAQSsController : Controller
    {
        private Model1 db = new Model1();

        // GET: Companies
        public ActionResult Index()
        {
            return View(db.FAQSs.ToList());
        }

        // GET: Companies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FAQS faqs = db.FAQSs.Find(id);
            if (faqs == null)
            {
                return HttpNotFound();
            }
            return View(faqs);
        }

        // GET: Companies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Companies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FAQS faqs)
        {
            if (ModelState.IsValid)
            {
                _ = db.FAQSs.Add(faqs);
                _ = db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(faqs);
        }

        // GET: Companies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FAQS faqs = db.FAQSs.Find(id);
            if (faqs == null)
            {
                return HttpNotFound();
            }
            return View(faqs);
        }

        // POST: Companies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FAQS faqs)
        {
            if (ModelState.IsValid)
            {
                db.Entry(faqs).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(faqs);
        }

        // GET: Companies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FAQS faqs = db.FAQSs.Find(id);
            if (faqs == null)
            {
                return HttpNotFound();
            }
            return View(faqs);
        }

        // POST: Companies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FAQS faqs = db.FAQSs.Find(id);
            db.FAQSs.Remove(faqs);
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

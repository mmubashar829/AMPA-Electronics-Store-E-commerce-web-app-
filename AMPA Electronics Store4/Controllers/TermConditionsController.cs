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
    public class TermConditionsController : Controller
    {
        private Model1 db = new Model1();

        // GET: Companies
        public ActionResult Index()
        {
            return View(db.TermConditions.ToList());
        }

        // GET: Companies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TermCondition tc = db.TermConditions.Find(id);
            if (tc == null)
            {
                return HttpNotFound();
            }
            return View(tc);
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
        public ActionResult Create(TermCondition tc)
        {
            if (ModelState.IsValid)
            {
                _ = db.TermConditions.Add(tc);
                _ = db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tc);
        }

        // GET: Companies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TermCondition tc = db.TermConditions.Find(id);
            if (tc == null)
            {
                return HttpNotFound();
            }
            return View(tc);
        }

        // POST: Companies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TermCondition tc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tc);
        }

        // GET: Companies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TermCondition tc = db.TermConditions.Find(id);
            if (tc == null)
            {
                return HttpNotFound();
            }
            return View(tc);
        }

        // POST: Companies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TermCondition tc = db.TermConditions.Find(id);
            db.TermConditions.Remove(tc);
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

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobReportingApp.Models;

namespace JobReportingApp.Controllers
{
    public class JobsController : Controller
    {
        private JobDBContext db = new JobDBContext();

        //
        // GET: /Jobs/

        public ActionResult Index()
        {
            return View(db.Jobs.ToList());
        }

        //
        // GET: /Jobs/Details/5

        public ActionResult Details(int id = 0)
        {
            Job job = db.Jobs.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }

        //
        // GET: /Jobs/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Jobs/Create

        [HttpPost]
        public ActionResult Create(Job job)
        {
            if (ModelState.IsValid)
            {
                db.Jobs.Add(job);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(job);
        }

        //
        // GET: /Jobs/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Job job = db.Jobs.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }

        //
        // POST: /Jobs/Edit/5

        [HttpPost]
        public ActionResult Edit(Job job)
        {
            if (ModelState.IsValid)
            {
                db.Entry(job).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(job);
        }

        //
        // GET: /Jobs/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Job job = db.Jobs.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }

        //
        // POST: /Jobs/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Job job = db.Jobs.Find(id);
            db.Jobs.Remove(job);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        public ActionResult SearchIndex(string searchString)
        {
            var jobs = from m in db.Jobs
                       select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                jobs = jobs.Where(s => s.JobNumber.Contains(searchString));
            }

            return View(jobs);
        }
    }
}
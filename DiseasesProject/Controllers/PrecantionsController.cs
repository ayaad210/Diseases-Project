using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DiseasesProject.Models;

namespace DiseasesProject.Controllers
{
    [Authorize(Roles = "Admins")]

    public class PrecantionsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Precantions
        public ActionResult Index()
        {
            return View(db.Precantions.ToList());
        }

        // GET: Precantions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Precantion precantion = db.Precantions.Find(id);
            if (precantion == null)
            {
                return HttpNotFound();
            }
            return View(precantion);
        }

        // GET: Precantions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Precantions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Info,Name")] Precantion precantion)
        {
            if (ModelState.IsValid)
            {
                db.Precantions.Add(precantion);
                db.SaveChanges();
                if (precantion.Name == "" || precantion.Name == null)
                {
                    precantion.Name = precantion.id.ToString();
                    db.Entry(precantion).State = EntityState.Modified;
                    db.SaveChanges();

                }
                return RedirectToAction("Index");
            }

            return View(precantion);
        }

        // GET: Precantions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Precantion precantion = db.Precantions.Find(id);
            if (precantion == null)
            {
                return HttpNotFound();
            }
            return View(precantion);
        }

        // POST: Precantions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Info,Name")] Precantion precantion)
        {
            if (ModelState.IsValid)
            {
                if (precantion.Name == "" || precantion.Name == null)
                {
                    precantion.Name = precantion.id.ToString();
               

                }
                db.Entry(precantion).State = EntityState.Modified;
                db.SaveChanges();


                return RedirectToAction("Index");
            }
            return View(precantion);
        }

        // GET: Precantions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Precantion precantion = db.Precantions.Find(id);
            if (precantion == null)
            {
                return HttpNotFound();
            }
            return View(precantion);
        }

        // POST: Precantions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Precantion precantion = db.Precantions.Find(id);
                db.Precantions.Remove(precantion);
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            catch (Exception)
            {

                throw; return RedirectToAction("Index");

            }
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

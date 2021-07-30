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

    public class DietsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Diets
        public ActionResult Index()
        {
            return View(db.Diets.ToList());
        }

        // GET: Diets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Diet diet = db.Diets.Find(id);
            if (diet == null)
            {
                return HttpNotFound();
            }
            return View(diet);
        }

        // GET: Diets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Diets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Diet1,Name")] Diet diet)
        {
            if (ModelState.IsValid)
            {
            
                db.Diets.Add(diet);
              
                db.SaveChanges();

                if (diet.Name == "" || diet.Name == null)
                {
                    diet.Name = diet.ID.ToString();
                    db.Entry(diet).State = EntityState.Modified;
                    db.SaveChanges();

                }

                return RedirectToAction("Index");
            }

            return View(diet);
        }

        // GET: Diets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Diet diet = db.Diets.Find(id);
            if (diet == null)
            {
                return HttpNotFound();
            }
            return View(diet);
        }

        // POST: Diets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Diet1,Name")] Diet diet)
        {
            if (ModelState.IsValid)
            {
                if (diet.Name == "" || diet.Name == null)
                {
                    diet.Name = diet.ID.ToString();
                  

                }
                db.Entry(diet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(diet);
        }

        // GET: Diets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Diet diet = db.Diets.Find(id);
            if (diet == null)
            {
                return HttpNotFound();
            }
            return View(diet);
        }

        // POST: Diets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
  Diet diet = db.Diets.Find(id);
            db.Diets.Remove(diet);
            db.SaveChanges();
            return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return RedirectToAction("Index");

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

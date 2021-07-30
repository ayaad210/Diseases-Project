using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace DiseasesProject.Models
{
    [Authorize(Roles = "Admins")]

    public class DiseasesController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Diseases

        public ActionResult Index()
        {
            return View(db.Diseases.ToList());
        }

        // GET: Diseases/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Disease disease = db.Diseases.Find(id);
            if (disease == null)
            {
                return HttpNotFound();
            }
            return View(disease);
        }

        // GET: Diseases/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Diseases/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,GeneralInfo")] Disease disease)
        {
            if (ModelState.IsValid)
            {
                db.Diseases.Add(disease);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(disease);
        }

        // GET: Diseases/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Disease disease = db.Diseases.Find(id);
            if (disease == null)
            {
                return HttpNotFound();
            }
            return View(disease);
        }

        // POST: Diseases/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,GeneralInfo")] Disease disease)
        {
            if (ModelState.IsValid)
            {
                db.Entry(disease).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(disease);
        }

        // GET: Diseases/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Disease disease = db.Diseases.Find(id);
            if (disease == null)
            {
                return HttpNotFound();
            }
            return View(disease);
        }

        // POST: Diseases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Disease disease = db.Diseases.Find(id);
                db.Diseases.Remove(disease);
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


        public PartialViewResult EditDiseaseDiets(int Disid)
        {
            Disease model;//= db.Diseases.Find(id);
            model = db.Diseases.Where(s => s.ID == Disid)
                   .Include(s => s.DiseaseDiets).FirstOrDefault();
            ViewBag.Diets = new SelectList(db.Diets.ToList(), "ID", "Name");
            ViewBag.pres = new SelectList(db.Precantions.ToList(), "ID","Name");
            ViewBag.sports = new SelectList(db.Sports.ToList(),  "ID","Name");

            return PartialView("PartialDiseasDiets", model);
        }

       // [HttpPost]
        public string InsertDiseasDiet(string DiseaseID, string PreID, string Sportsid, string dlID, string AgeFrom, string ageto, string gender)
        {

            try
            {
               DiseaseDiet obb = new DiseaseDiet { Disease = db.Diseases.Find(Convert.ToInt32(DiseaseID)), Precantion = db.Precantions.Find(Convert.ToInt32(PreID)), Sport = db.Sports.Find(Convert.ToInt32(Sportsid)), Diet = db.Diets.Find(Convert.ToInt32(dlID)), AgeTo = Convert.ToInt32(ageto), AgeFrom = Convert.ToInt32(AgeFrom), Gender = (gender == "0" ? false : true) };
                db.DiseaseDiets.Add(obb);
                db.SaveChanges();
                DiseaseDiet ob = db.DiseaseDiets.Where(s => s.ID == obb.ID).FirstOrDefault();
                StringBuilder sb = new StringBuilder();
                sb.AppendLine(" <input type='button' class='btndelete'  id='btndelete'  value='-' />");
                sb.AppendLine("<input type = 'hidden' value='" + ob.ID + "' />");
                string x = "  <tr> <td> " + ob.Disease.Name + "</td> <td> " + ob.AgeFrom + " </td> <td> " + ob.AgeTo + "</td><td> " + (ob.Gender == false ? "انثى" : "ذكر") + " </td> <td> " + ob.Precantion.Name + " </td> <td> " + ob.Sport.Name + " </td> <td> " + ob.Diet.Name + " </td> <td>" + sb + "</td> </tr>";
                return x;
            }
            catch (Exception)
            {

                return "";
            }
        }
        public string DeleteDisDiet(string DDiD)
        {
            try
            {
                DiseaseDiet ob = db.DiseaseDiets.Find(Convert.ToInt32(DDiD));
                db.DiseaseDiets.Remove(ob);
                db.SaveChanges();
                return "1";
            }
            catch (Exception)
            {

                return "-1";

                    }
         
        }
    }
}

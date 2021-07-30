using DiseasesProject.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DiseasesProject.Controllers
{
    [Authorize]

    public class VisitorsController : Controller
    {
        // GET: Visitors
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View(db.Diseases.ToList());
        }
        public PartialViewResult SearchByName(string SearchName)
        {
            List<Disease> model = db.Diseases.Where(d=>d.Name.Contains(SearchName)).ToList();

            return PartialView("ParialDiseases",model);
        }

        public ActionResult MoreInfo(string DisID)
        {
            DiseaseDiet ob = new Models.DiseaseDiet(); ;
            ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            Disease dis = db.Diseases.Find(Convert.ToInt32(DisID));
            if (dis!=null&&user!=null)
            {
                 ob = db.DiseaseDiets.Include(dt=>dt.Disease).Include(dt=>dt.Diet).Include(dt=>dt.Sport).Include(dt=>dt.Precantion).Where(d => d.AgeTo >= user.Age && d.AgeFrom <= user.Age &&d.Disease.ID==dis.ID).FirstOrDefault();
            }
            if (ob==null)
            {
                ob = new DiseaseDiet() {Disease=dis, Diet = new Diet(), Precantion = new Models.Precantion(), Sport = new Models.Sport() };

            }


            return View(ob);
        }

    }
}
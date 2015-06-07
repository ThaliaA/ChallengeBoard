using ProjectFuchsia.Core;
using ProjectFuchsia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ProjectFuchsia.Controllers
{
    public class AdminController : BaseController
    {
        //
        // GET: /Admin/

        public ActionResult Index()
        {
            //get all challenges from database
            var model = new List<Challenge>();
            model = RavenService.GetAllChallenges(RavenSession);
            return View(model);
        }

        public ActionResult AddChallenge()
        {
            var model = new Challenge();
            return View(model);
        }

        [HttpPost]
        public ActionResult AddChallenge(Challenge challenge)
        {

            RavenService.SaveChallenge(RavenSession, challenge);

            return RedirectToAction("Index");
        }

    }
}

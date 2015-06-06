using ProjectFuchsia.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
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
            return View();
        }

        public ActionResult AddChallenge()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddChallenge(Challenge challenge)
        {
            RavenSession.Store(challenge);
            return View();
        }

    }
}

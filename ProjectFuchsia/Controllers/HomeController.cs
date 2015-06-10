using ProjectFuchsia.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectFuchsia.Controllers
{
    public class HomeController : BaseController
    {
        //
        // GET: /Home/

        public ActionResult Index(string name)
        {
            var user = RavenService.GetUser(RavenSession, name);
            
            if (user == null)
            {
                user = RavenService.CreateUser(RavenSession, name);
            }

            //var test = RavenService.UpdateUser(RavenSession, name);

            return View(user);
        }

    }
}

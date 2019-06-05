using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Data.Entity;
using CodingChallengeGreenSlate.Model;
using CodingChallengeGreenSlate.Service;

namespace CodingChallengeGreenSlate.Controllers
{
    public class HomeController : Controller
    {
        //private ContextEF db = new ContextEF();
        IUserProjectService _userProjectService;
        IUserService _userService;
        IProjectService _projectService;

        public HomeController(IUserProjectService userProjectService, IUserService userService, IProjectService projectService)
        {
            _userProjectService = userProjectService;
            _userService = userService;
            _projectService = projectService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult getUsers()
        {
            try
            {
                //if (Request.IsAjaxRequest())
                //{
                    var data = _userService.GetAll();
                    var d = Json(data, JsonRequestBehavior.AllowGet);
                    return Json(data, JsonRequestBehavior.AllowGet);
                //}
                //else
                //{
                //    throw new HttpException(404, "");
                //}
            }
            catch
            {
                throw new HttpException(404, "");
            }
        }

        // GET: Home/DetailsUserProjects/5
        public ActionResult DetailsUserProjects(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            var listProjectsForUser = _userProjectService.GetProjectsByUserId(id);

            var data = listProjectsForUser;
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}